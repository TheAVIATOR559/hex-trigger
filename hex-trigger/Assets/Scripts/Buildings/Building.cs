using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Building : MonoBehaviour
{
    [SerializeField] protected bool IsPowered = false;

    public Enums.Hex_Types HexType;
    public Enums.Building_Tier BuildingTier;
    public Enums.Building_Type BuildingType;

    protected Hex connectedHex;

    //[SerializeField] protected GameObject model;

    public float AdjustedProduction = 0;
    protected float ReducedProduction = 0;
    protected float FullProduction = 0;
    public float BonusFromNeighbors = 1;

    private Enums.Building_Tier prevTier;

    private BuildingUpkeep upkeep;
    private Action<EventParam> UpkeepTickListener;
    private Action<EventParam> UpgradeTickListener;

    [SerializeField]private bool CanUpgrade = false;

    private void Awake()
    {

        connectedHex = GetComponent<Hex>();
    }

    public virtual void Initalize()
    {
        EventParam eventParam = new EventParam();
        eventParam.hex = connectedHex;

        Event_Manager.TriggerEvent(Events.ADD_POWER_DISTRIBUTION, eventParam);

        upkeep = GetUpkeepCosts(BuildingType);
        UpkeepTickListener = new Action<EventParam>(TickUpkeep);
        Event_Manager.AddListener(Events.TICK_UPKEEP, UpkeepTickListener);

        UpgradeTickListener = new Action<EventParam>(TryUpgrade);
    }

    public virtual void DetermineBuildingTier()
    {
        int similarHexes = 0;

        prevTier = BuildingTier;

        foreach(Hex hex in connectedHex.Neighbors)
        {
            if(hex.ConnectedBuilding.HexType == HexType)
            {
                similarHexes++;
            }
        }

        if(similarHexes < 2 && prevTier < Enums.Building_Tier.I)
        {
            BuildingTier = Enums.Building_Tier.I;
        }
        else if(similarHexes == 2 && prevTier < Enums.Building_Tier.II)
        {
            BuildingTier = Enums.Building_Tier.II;
        }
        else if(similarHexes == 3 && prevTier < Enums.Building_Tier.III)
        {
            BuildingTier = Enums.Building_Tier.III;
        }
        else if(similarHexes > 3 && similarHexes < 6 && prevTier < Enums.Building_Tier.IV)
        {
            BuildingTier = Enums.Building_Tier.IV;
        }
        else if(similarHexes == 6 && prevTier < Enums.Building_Tier.V)
        {
            BuildingTier = Enums.Building_Tier.V;
        }
        //else
        //{
        //    Debug.LogError("similarHexes is greater than 6 :: " + connectedHex.Position);
        //}

        BuildingType = Enums.HexTypeAndTierToBuildingType(HexType, BuildingTier);

        if(BuildingTier != prevTier && !CanUpgrade)
        {
            CanUpgrade = true;
            TryUpgrade(new EventParam());
        }
    }

    private void TryUpgrade(EventParam eventParam)
    {
        if(!CanUpgrade)
        {
            return;
        }

        Debug.Log("ATTEMPTING UPGRADE");

        DetermineBuildingTier();

        if (connectedHex.IsBuilding || connectedHex.IsUpgrading)
        {
            //wait for next tick and try again
            Event_Manager.AddListener(Events.TICK, UpgradeTickListener);
            Debug.Log("ATTEMPTING UPGRADE :: WAITING FOR NEXT TICK");
        }
        else
        {
            Debug.Log("ATTEMPTING UPGRADE :: SUCCESS");
            Event_Manager.RemoveListener(Events.TICK, UpgradeTickListener);
            connectedHex.UpdateOverviewTier(BuildingTier);
            connectedHex.UpdateModel(BuildingType);
            UpdateProductionValue();
            UpdateNeighborProductionValues();
            CanUpgrade = false;
        }
    }

    public virtual void UpdateProductionValue()
    {
        BonusFromNeighbors = 0;

        RemoveFromResourceProduction();
        AdjustedProduction = GetProductionValue(BuildingTier, HexType);
        ReducedProduction = AdjustedProduction * Constants.REDUCED_PRODUCTION_PERCENT;
        FullProduction = AdjustedProduction;

        foreach(Hex neighbor in connectedHex.Neighbors)
        {
            if(neighbor.ConnectedBuilding.HexType == this.HexType)
            {
                BonusFromNeighbors += GetProductionBonus(neighbor.ConnectedBuilding.BuildingTier);
            }   
        }

        //Debug.Log("new prod bonus :: " + BonusFromNeighbors);

        AdjustedProduction += (AdjustedProduction * BonusFromNeighbors);

        AddToResourceProduction();
    }

    public virtual void UpdateNeighborProductionValues()
    {
        foreach(Hex neighbor in connectedHex.Neighbors)
        {
            neighbor.ConnectedBuilding.UpdateProductionValue();
        }
    }

    protected virtual void AddToResourceProduction()
    {
        if(IsPowered)
        {
            Resource_Manager.AddProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
        }
    }

    protected virtual void RemoveFromResourceProduction()
    {
        Resource_Manager.RemoveProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
    }

    public virtual void SetPowered(bool powerState)
    {
        IsPowered = powerState;

        if(IsPowered)
        {
            AddToResourceProduction();
        }
        else
        {
            RemoveFromResourceProduction();
        }
    }    

    protected void TickUpkeep(EventParam eventParam)
    {
        RemoveFromResourceProduction();

        Debug.Log("TICKING UPKEEP");
        if (Resource_Manager.HaveUpkeepCosts(upkeep))
        {
            Resource_Manager.DeductResources(upkeep);
            AdjustedProduction = FullProduction;
            
        }
        else
        {
            Debug.Log("lowering production");
            AdjustedProduction = ReducedProduction;
        }

        AddToResourceProduction();
    }

    public static float GetProductionBonus(Enums.Building_Tier tier)
    {
        switch (tier)
        {
            case Enums.Building_Tier.I:
                return Constants.TIER_I_BONUS;
            case Enums.Building_Tier.II:
                return Constants.TIER_II_BONUS;
            case Enums.Building_Tier.III:
                return Constants.TIER_III_BONUS;
            case Enums.Building_Tier.IV:
                return Constants.TIER_IV_BONUS;
            case Enums.Building_Tier.V:
                return Constants.TIER_V_BONUS;
            default:
                return Constants.TIER_I_BONUS;
        }
    }

    public static int GetProductionValue(Enums.Building_Tier tier, Enums.Hex_Types type)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.FOOD_I_PROD,
                    Enums.Building_Tier.II => Constants.FOOD_II_PROD,
                    Enums.Building_Tier.III => Constants.FOOD_III_PROD,
                    Enums.Building_Tier.IV => Constants.FOOD_IV_PROD,
                    Enums.Building_Tier.V => Constants.FOOD_V_PROD,
                    _ => Constants.FOOD_I_PROD,
                };
            case Enums.Hex_Types.HOUSING:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.HOUSING_I_PROD,
                    Enums.Building_Tier.II => Constants.HOUSING_II_PROD,
                    Enums.Building_Tier.III => Constants.HOUSING_III_PROD,
                    Enums.Building_Tier.IV => Constants.HOUSING_IV_PROD,
                    Enums.Building_Tier.V => Constants.HOUSING_V_PROD,
                    _ => Constants.HOUSING_I_PROD,
                };
            case Enums.Hex_Types.INDUSTRY:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.INDUSTRY_I_PROD,
                    Enums.Building_Tier.II => Constants.INDUSTRY_II_PROD,
                    Enums.Building_Tier.III => Constants.INDUSTRY_III_PROD,
                    Enums.Building_Tier.IV => Constants.INDUSTRY_IV_PROD,
                    Enums.Building_Tier.V => Constants.INDUSTRY_V_PROD,
                    _ => Constants.INDUSTRY_I_PROD,
                };
            case Enums.Hex_Types.MILITARY:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.MILITARY_I_PROD,
                    Enums.Building_Tier.II => Constants.MILITARY_II_PROD,
                    Enums.Building_Tier.III => Constants.MILITARY_III_PROD,
                    Enums.Building_Tier.IV => Constants.MILITARY_IV_PROD,
                    Enums.Building_Tier.V => Constants.MILITARY_V_PROD,
                    _ => Constants.MILITARY_I_PROD,
                };
            case Enums.Hex_Types.RESEARCH:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.RESEARCH_I_PROD,
                    Enums.Building_Tier.II => Constants.RESEARCH_II_PROD,
                    Enums.Building_Tier.III => Constants.RESEARCH_III_PROD,
                    Enums.Building_Tier.IV => Constants.RESEARCH_IV_PROD,
                    Enums.Building_Tier.V => Constants.RESEARCH_V_PROD,
                    _ => Constants.RESEARCH_I_PROD,
                };
            case Enums.Hex_Types.ISOLIUM:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.ISOLIUM_I_PROD,
                    Enums.Building_Tier.II => Constants.ISOLIUM_II_PROD,
                    Enums.Building_Tier.III => Constants.ISOLIUM_III_PROD,
                    Enums.Building_Tier.IV => Constants.ISOLIUM_IV_PROD,
                    Enums.Building_Tier.V => Constants.ISOLIUM_V_PROD,
                    _ => Constants.ISOLIUM_I_PROD,
                };
            case Enums.Hex_Types.STORAGE:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.STORAGE_I_PROD,
                    Enums.Building_Tier.II => Constants.STORAGE_II_PROD,
                    Enums.Building_Tier.III => Constants.STORAGE_III_PROD,
                    Enums.Building_Tier.IV => Constants.STORAGE_IV_PROD,
                    Enums.Building_Tier.V => Constants.STORAGE_V_PROD,
                    _ => Constants.STORAGE_I_PROD,
                };
            case Enums.Hex_Types.POWER:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.POWER_I_PROD,
                    Enums.Building_Tier.II => Constants.POWER_II_PROD,
                    Enums.Building_Tier.III => Constants.POWER_III_PROD,
                    Enums.Building_Tier.IV => Constants.POWER_IV_PROD,
                    Enums.Building_Tier.V => Constants.POWER_V_PROD,
                    _ => Constants.POWER_I_PROD,
                };
            case Enums.Hex_Types.ENTERTAINMENT:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.ENTERTAINMENT_I_PROD,
                    Enums.Building_Tier.II => Constants.ENTERTAINMENT_II_PROD,
                    Enums.Building_Tier.III => Constants.ENTERTAINMENT_III_PROD,
                    Enums.Building_Tier.IV => Constants.ENTERTAINMENT_IV_PROD,
                    Enums.Building_Tier.V => Constants.ENTERTAINMENT_V_PROD,
                    _ => Constants.ENTERTAINMENT_I_PROD,
                };
            case Enums.Hex_Types.MONUMENT:
            case Enums.Hex_Types.SPECIAL:
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                return 1;
        }
    }

    public static int GetProductionValue(Enums.Building_Type type)
    {
        switch (type)
        {
            case Enums.Building_Type.GARDEN:
                return Constants.FOOD_I_PROD;
            case Enums.Building_Type.FARM:
                return Constants.FOOD_II_PROD;
            case Enums.Building_Type.ORCHARD:
                return Constants.FOOD_III_PROD;
            case Enums.Building_Type.RANCH:
                return Constants.FOOD_IV_PROD;
            case Enums.Building_Type.HYDROPONICS_TOWER:
                return Constants.FOOD_V_PROD;
            case Enums.Building_Type.HOVEL:
                return Constants.HOUSING_I_PROD;
            case Enums.Building_Type.COTTAGE:
                return Constants.HOUSING_II_PROD;
            case Enums.Building_Type.APARTMENT:
                return Constants.HOUSING_III_PROD;
            case Enums.Building_Type.CONDOMINIUM:
                return Constants.HOUSING_IV_PROD;
            case Enums.Building_Type.VILLA:
                return Constants.HOUSING_V_PROD;
            case Enums.Building_Type.WORKSHOP:
                return Constants.INDUSTRY_I_PROD;
            case Enums.Building_Type.FORGE:
                return Constants.INDUSTRY_II_PROD;
            case Enums.Building_Type.MILL:
                return Constants.INDUSTRY_III_PROD;
            case Enums.Building_Type.FOUNDRY:
                return Constants.INDUSTRY_IV_PROD;
            case Enums.Building_Type.FACTORY:
                return Constants.INDUSTRY_V_PROD;
            case Enums.Building_Type.BARRACKS:
                return Constants.MILITARY_I_PROD;
            case Enums.Building_Type.DORMITORY:
                return Constants.MILITARY_II_PROD;
            case Enums.Building_Type.GARRISON:
                return Constants.MILITARY_III_PROD;
            case Enums.Building_Type.QUARTERS:
                return Constants.MILITARY_IV_PROD;
            case Enums.Building_Type.HEADQUARTERS:
                return Constants.MILITARY_V_PROD;
            case Enums.Building_Type.RESEARCH_LAB:
                return Constants.RESEARCH_I_PROD;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                return Constants.RESEARCH_II_PROD;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                return Constants.RESEARCH_III_PROD;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                return Constants.RESEARCH_IV_PROD;
            case Enums.Building_Type.QUANTUM_BRAIN:
                return Constants.RESEARCH_V_PROD;
            case Enums.Building_Type.EXTRACTOR_MK_I:
                return Constants.ISOLIUM_I_PROD;
            case Enums.Building_Type.EXTRACTOR_MK_II:
                return Constants.ISOLIUM_II_PROD;
            case Enums.Building_Type.EXTRACTOR_MK_III:
                return Constants.ISOLIUM_III_PROD;
            case Enums.Building_Type.EXTRACTOR_MK_IV:
                return Constants.ISOLIUM_IV_PROD;
            case Enums.Building_Type.EXTRACTOR_MK_V:
                return Constants.ISOLIUM_V_PROD;
            case Enums.Building_Type.STOCKPILE:
                return Constants.STORAGE_I_PROD;
            case Enums.Building_Type.STOREHOUSE:
                return Constants.STORAGE_II_PROD;
            case Enums.Building_Type.WAREHOUSE:
                return Constants.STORAGE_III_PROD;
            case Enums.Building_Type.DEPOT:
                return Constants.STORAGE_IV_PROD;
            case Enums.Building_Type.DISTRIBUTION_CENTER:
                return Constants.STORAGE_V_PROD;
            case Enums.Building_Type.WATERWHEEL_GENERATOR:
                return Constants.POWER_I_PROD;
            case Enums.Building_Type.COAL_FIRED_POWER_PLANT:
                return Constants.POWER_II_PROD;
            case Enums.Building_Type.HYDROELECTRIC_DAM:
                return Constants.POWER_III_PROD;
            case Enums.Building_Type.NUCLEAR_POWER_PLANT:
                return Constants.POWER_IV_PROD;
            case Enums.Building_Type.QUANTUM_POWER_PLANT:
                return Constants.POWER_V_PROD;
            case Enums.Building_Type.PUBLIC_PARK:
                return Constants.ENTERTAINMENT_I_PROD;
            case Enums.Building_Type.CIRCUS:
                return Constants.ENTERTAINMENT_II_PROD;
            case Enums.Building_Type.THEATER_COMPLEX:
                return Constants.ENTERTAINMENT_III_PROD;
            case Enums.Building_Type.VIRTUAL_REALITY_CAFE:
                return Constants.ENTERTAINMENT_IV_PROD;
            case Enums.Building_Type.QUANTUM_HOLOGRAM_THEATER:
                return Constants.ENTERTAINMENT_V_PROD;
            case Enums.Building_Type.DIPLO_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.DIPLO_MONUMENT);
            case Enums.Building_Type.SCI_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.SCI_MONUMENT);
            case Enums.Building_Type.HAPP_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.HAPP_MONUMENT);
            case Enums.Building_Type.IND_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.IND_MONUMENT);
            case Enums.Building_Type.ISO_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.ISO_MONUMENT);
            case Enums.Building_Type.MIL_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.MIL_MONUMENT);
            case Enums.Building_Type.FOOD_MONUMENT:
                return Resource_Manager.GetMonumentProduction(Enums.Building_Type.FOOD_MONUMENT);
            case Enums.Building_Type.GOD_SEAT:
            case Enums.Building_Type.WATCHTOWER:
            case Enums.Building_Type.MISSILE_COMPLEX:
            case Enums.Building_Type.LASER_TOWER:
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
            case Enums.Building_Type.AUTO_LASER_TOWER:
            case Enums.Building_Type.SHOOTING_RANGE:
            case Enums.Building_Type.DEFENDERS_WALL:
            case Enums.Building_Type.GUNNERS_ALLEY:
            case Enums.Building_Type.SNIPERS_NEST:
            case Enums.Building_Type.SCOUT_CAMP:
            case Enums.Building_Type.ACES_ARENA:
            case Enums.Building_Type.CANNONEERS_TOWER:
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
            case Enums.Building_Type.VOID_PORTAL:
            case Enums.Building_Type.VOID_COMMUNICATOR:
            case Enums.Building_Type.VOID_RADAR_ARRAY:
            case Enums.Building_Type.FACTION_EMBASSY:
            case Enums.Building_Type.ABYSSAL_PATHFINDER:
            case Enums.Building_Type.VOID_RUDDER:
            case Enums.Building_Type.WEATHER_MANIPULATOR:
            default:
                return 1;
        }
    }

    public static BuildingUpkeep GetUpkeepCosts(Enums.Building_Type type)
    {
        switch (type)
        {
            case Enums.Building_Type.GARDEN:
                return Constants.GardenUpkeep;
            case Enums.Building_Type.FARM:
                return Constants.FarmUpkeep;
            case Enums.Building_Type.ORCHARD:
                return Constants.OrchardUpkeep;
            case Enums.Building_Type.RANCH:
                return Constants.RanchUpkeep;
            case Enums.Building_Type.HOVEL:
                return Constants.HovelUpkeep;
            case Enums.Building_Type.COTTAGE:
                return Constants.CottageUpkeep;
            case Enums.Building_Type.APARTMENT:
                return Constants.ApartmentUpkeep;
            case Enums.Building_Type.CONDOMINIUM:
                return Constants.CondoUpkeep;
            case Enums.Building_Type.WORKSHOP:
                return Constants.WorkshopUpkeep;
            case Enums.Building_Type.FORGE:
                return Constants.ForgeUpkeep;
            case Enums.Building_Type.MILL:
                return Constants.MillUpkeep;
            case Enums.Building_Type.FOUNDRY:
                return Constants.FoundryUpkeep;
            case Enums.Building_Type.BARRACKS:
                return Constants.BarracksUpkeep;
            case Enums.Building_Type.DORMITORY:
                return Constants.DormitoryUpkeep;
            case Enums.Building_Type.GARRISON:
                return Constants.GardenUpkeep;
            case Enums.Building_Type.QUARTERS:
                return Constants.QuartersUpkeep;
            case Enums.Building_Type.SHOOTING_RANGE:
                return Constants.ShootingRangeUpkeep;
            case Enums.Building_Type.DEFENDERS_WALL:
                return Constants.DefendersWallUpkeep;
            case Enums.Building_Type.GUNNERS_ALLEY:
                return Constants.GunnersAlleyUpkeep;
            case Enums.Building_Type.SNIPERS_NEST:
                return Constants.SnipersNestUpkeep;
            case Enums.Building_Type.SCOUT_CAMP:
                return Constants.ScoutCampUpkeep;
            case Enums.Building_Type.ACES_ARENA:
                return Constants.AcesArenaUpkeep;
            case Enums.Building_Type.CANNONEERS_TOWER:
                return Constants.CannoneersTowerUpkeep;
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
                return Constants.GuardiansLastStandUpkeep;
            case Enums.Building_Type.WATCHTOWER:
                return Constants.WatchTowerUpkeep;
            case Enums.Building_Type.MISSILE_COMPLEX:
                return Constants.MissileComplexUpkeep;
            case Enums.Building_Type.LASER_TOWER:
                return Constants.LaserTowerUpkeep;
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
                return Constants.AutoMissileComplexUpkeep;
            case Enums.Building_Type.AUTO_LASER_TOWER:
                return Constants.AutoLaserTowerUpkeep;
            case Enums.Building_Type.RESEARCH_LAB:
                return Constants.ResearchLabUpkeep;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                return Constants.ResearchCollegeUpkeep;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                return Constants.ResearchInstituteUpkeep;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                return Constants.MultiBrainUpkeep;
            case Enums.Building_Type.PUBLIC_PARK:
                return Constants.PublicParkUpkeep;
            case Enums.Building_Type.CIRCUS:
                return Constants.CircusUpkeep;
            case Enums.Building_Type.THEATER_COMPLEX:
                return Constants.TheaterUpkeep;
            case Enums.Building_Type.VIRTUAL_REALITY_CAFE:
                return Constants.VirtualRealityCafeUpkeep;

            case Enums.Building_Type.HYDROPONICS_TOWER:
            case Enums.Building_Type.VILLA:
            case Enums.Building_Type.FACTORY:
            case Enums.Building_Type.HEADQUARTERS:
            case Enums.Building_Type.QUANTUM_BRAIN:
            case Enums.Building_Type.EXTRACTOR_MK_I:
            case Enums.Building_Type.EXTRACTOR_MK_II:
            case Enums.Building_Type.EXTRACTOR_MK_III:
            case Enums.Building_Type.EXTRACTOR_MK_IV:
            case Enums.Building_Type.EXTRACTOR_MK_V:
            case Enums.Building_Type.STOCKPILE:
            case Enums.Building_Type.STOREHOUSE:
            case Enums.Building_Type.WAREHOUSE:
            case Enums.Building_Type.DEPOT:
            case Enums.Building_Type.DISTRIBUTION_CENTER:
            case Enums.Building_Type.WATERWHEEL_GENERATOR:
            case Enums.Building_Type.COAL_FIRED_POWER_PLANT:
            case Enums.Building_Type.HYDROELECTRIC_DAM:
            case Enums.Building_Type.NUCLEAR_POWER_PLANT:
            case Enums.Building_Type.QUANTUM_POWER_PLANT:
            case Enums.Building_Type.QUANTUM_HOLOGRAM_THEATER:
            case Enums.Building_Type.DIPLO_MONUMENT:
            case Enums.Building_Type.SCI_MONUMENT:
            case Enums.Building_Type.HAPP_MONUMENT:
            case Enums.Building_Type.IND_MONUMENT:
            case Enums.Building_Type.ISO_MONUMENT:
            case Enums.Building_Type.MIL_MONUMENT:
            case Enums.Building_Type.FOOD_MONUMENT:
            case Enums.Building_Type.GOD_SEAT:
            case Enums.Building_Type.VOID_PORTAL:
            case Enums.Building_Type.VOID_COMMUNICATOR:
            case Enums.Building_Type.VOID_RADAR_ARRAY:
            case Enums.Building_Type.FACTION_EMBASSY:
            case Enums.Building_Type.ABYSSAL_PATHFINDER:
            case Enums.Building_Type.VOID_RUDDER:
            case Enums.Building_Type.WEATHER_MANIPULATOR:
            default:
                return new BuildingUpkeep(0,0,0);
        }
    }
}