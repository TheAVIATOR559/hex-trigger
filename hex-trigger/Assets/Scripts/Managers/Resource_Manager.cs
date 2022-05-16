using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : Singleton<Resource_Manager>
{
    public int MaximumHexRange = Constants.DEFAULT_HEX_RADIUS;

    public int CurrentFood;//currently available food, increases based on food production
    public int MaximumFood = Constants.DEFAULT_RESOURCE_STORAGE;//Maximum storable food

    public int CurrentPopulation;//population should increase over time and deduct based on building costs
    public int MaximumPopulation = Constants.DEFAULT_RESOURCE_STORAGE;//maximum population, increases as new building hexes are built

    public int CurrentIndustry;//currently available industry, increase based on industry production 
    public int MaximumIndustry = Constants.DEFAULT_RESOURCE_STORAGE;

    public int CurrentIsolium;//currently available isolium, increases based on isolium production
    public int MaximumIsolium = Constants.DEFAULT_RESOURCE_STORAGE;

    public int CurrentMilitary//should only increase when the player allocates more
    {
        get
        {
            return GruntCount + ShooterCount + DefenderCount + GunnerCount + SniperCount + ScoutCount + AceCount + CannoneerCount + GuardianCount;
        }
        set
        {
            GruntCount = value;
        }
    }

    public int MaximumMilitary;//maximum military population, shoud increase as new military hexes are built

    public int MaximumAces;//maximum number of aces, should increase as new Ace's Arena hexes are built

    public int MaximumCannoneers;//maximum number of cannoneers, should increase as new Cannoneer's Tower hexes are built

    public int MaximumGuardians;//maximum number of aces, should increase as new Guardian's Last Stand hexes are built

    public int GruntCount;
    public int ShooterCount;
    public int DefenderCount;
    public int GunnerCount;
    public int SniperCount;
    public int ScoutCount;
    public int AceCount;
    public int CannoneerCount;
    public int GuardianCount;

    public int FoodProduction = 0;
    public int IndustryProduction = 0;
    public int IsoliumProduction = 0;
    public int ResearchProduction = 0;
    public int PopulationGrowthRate = 0;
    public float ShooterTrainingCostReduction = 1;
    public float DefenderTrainingCostReduction = 1;
    public float GunnerTrainingCostReduction = 1;
    public float SniperTrainingCostReduction = 1;
    public float ScoutTrainingCostReduction = 1;

    public bool ResourcesTickPaused = false;

    public int GodSeatLevel = 1;
    public int GodSeatUpgradeIsoliumCost = Constants.DEFAULT_GOD_SEAT_ISO_COST;
    public int GodSeatUpgradeIndustryCost = Constants.DEFAULT_GOD_SEAT_IND_COST;
    public int GodSeatUpgradeFoodCost = Constants.DEFAULT_GOD_SEAT_FOOD_COST;
    public int GodSeatUpgradePopCost = Constants.DEFAULT_GOD_SEAT_POP_COST;

    private int PrevGodSeatIsoliumCost;
    private int PrevGodSeatIndustryCost;
    private int PrevGodSeatFoodCost;
    private int PrevGodSeatPopCost;

    [SerializeField] private int PopGrowthDecimal = 0;

    private int DiploMonumentPrevBonus = Constants.DEFAULT_DIPLO_MON_BONUS;
    private int SciMonumentPrevBonus = Constants.DEFAULT_SCI_MON_BONUS;
    private int HappMonumentPrevBonus = Constants.DEFAULT_HAPP_MON_BONUS;
    private int IndMonumentPrevBonus = Constants.DEFAULT_IND_MON_BONUS;
    private int IsoMonumentPrevBonus = Constants.DEFAULT_ISO_MON_BONUS;
    private int MilMonumentPrevBonus = Constants.DEFAULT_MIL_MON_BONUS;
    private int FoodMonumentPrevBonus = Constants.DEFAULT_FOOD_MON_BONUS;

    private int DiploMonumentCount = 1;
    private int SciMonumentCount = 1;
    private int HappMonumentCount = 1;
    private int IndMonumentCount = 1;
    private int IsoMonumentCount = 1;
    private int MilMonumentCount = 1;
    private int FoodMonumentCount = 1;

    private void Awake()
    {
        PrevGodSeatIsoliumCost = Instance.GodSeatUpgradeIsoliumCost;
        PrevGodSeatIndustryCost = Instance.GodSeatUpgradeIndustryCost;
        PrevGodSeatFoodCost = Instance.GodSeatUpgradeFoodCost;
        PrevGodSeatPopCost = Instance.GodSeatUpgradePopCost;
    }

    private void Update()//DEV_TOOLS
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DEV_MaxOutResources();
        }
    }

    public static void DEV_MaxOutResources()
    {
        Instance.CurrentFood = 1000;
        Instance.MaximumFood = 1000;
        Instance.MaximumPopulation = 1000;
        Instance.CurrentPopulation = 1000;
        Instance.CurrentIndustry = 1000;
        Instance.CurrentIsolium = 1000;
        //Instance.CurrentMilitary = 1000;
        Instance.MaximumMilitary = 1000;
    }

    public static bool HaveRequiredBuildingCosts(BuildingCost cost)
    {
        if (cost.RequiredFood > Instance.CurrentFood)
        {
            return false;
        }

        if (cost.RequiredPopulation > Instance.CurrentPopulation)
        {
            return false;
        }

        if (cost.RequiredIndustry > Instance.CurrentIndustry)
        {
            return false;
        }

        if (cost.RequiredMilitary > Instance.CurrentMilitary)
        {
            return false;
        }

        if (cost.RequiredIsolium > Instance.CurrentIsolium)
        {
            return false;
        }

        return true;
    }

    public static BuildingCost GetBuildingCost(Enums.Building_Type type)
    {
        switch (type)
        {
            case Enums.Building_Type.GARDEN:
                return Constants.GardenCost;
            case Enums.Building_Type.FARM:
                return Constants.FarmCost;
            case Enums.Building_Type.ORCHARD:
                return Constants.OrchardCost;
            case Enums.Building_Type.RANCH:
                return Constants.RanchCost;
            case Enums.Building_Type.HOVEL:
                return Constants.HovelCost;
            case Enums.Building_Type.COTTAGE:
                return Constants.CottageCost;
            case Enums.Building_Type.APARTMENT:
                return Constants.ApartmentCost;
            case Enums.Building_Type.CONDOMINIUM:
                return Constants.CondoCost;
            case Enums.Building_Type.WORKSHOP:
                return Constants.WorkshopCost;
            case Enums.Building_Type.FORGE:
                return Constants.ForgeCost;
            case Enums.Building_Type.MILL:
                return Constants.MillCost;
            case Enums.Building_Type.FOUNDRY:
                return Constants.FoundryCost;
            case Enums.Building_Type.BARRACKS:
                return Constants.BarracksCost;
            case Enums.Building_Type.DORMITORY:
                return Constants.DormitoryCost;
            case Enums.Building_Type.GARRISON:
                return Constants.GarrisonCost;
            case Enums.Building_Type.QUARTERS:
                return Constants.QuartersCost;
            case Enums.Building_Type.WATCHTOWER:
                return Constants.WatchTowerCost;
            case Enums.Building_Type.MISSILE_COMPLEX:
                return Constants.MissileComplexCost;
            case Enums.Building_Type.LASER_TOWER:
                return Constants.LaserTowerCost;
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
                return Constants.AutoMissileComplexCost;
            case Enums.Building_Type.AUTO_LASER_TOWER:
                return Constants.AutoLaserTowerCost;
            case Enums.Building_Type.RESEARCH_LAB:
                return Constants.ResearchLabCost;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                return Constants.ResearchCollegeCost;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                return Constants.ResearchInstituteCost;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                return Constants.MultiBrainCost;
            case Enums.Building_Type.EXTRACTOR_MK_I:
                return Constants.ExtractorMKICost;
            case Enums.Building_Type.EXTRACTOR_MK_II:
                return Constants.ExtractorMKIICost;
            case Enums.Building_Type.EXTRACTOR_MK_III:
                return Constants.ExtractorMKIIICost;
            case Enums.Building_Type.EXTRACTOR_MK_IV:
                return Constants.ExtractorMKIVCost;
            case Enums.Building_Type.SHOOTING_RANGE:
                return Constants.ShootingRangeCost;
            case Enums.Building_Type.DEFENDERS_WALL:
                return Constants.DefendersWallCost;
            case Enums.Building_Type.GUNNERS_ALLEY:
                return Constants.GunnersAlleyCost;
            case Enums.Building_Type.SNIPERS_NEST:
                return Constants.SnipersNestCost;
            case Enums.Building_Type.SCOUT_CAMP:
                return Constants.ScoutCampCost;
            case Enums.Building_Type.ACES_ARENA:
                return Constants.AcesArenaCost;
            case Enums.Building_Type.CANNONEERS_TOWER:
                return Constants.CannoneersTowerCost;
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
                return Constants.GuardiansLastStandCost;
            case Enums.Building_Type.STOCKPILE:
                return Constants.StockpileCost;
            case Enums.Building_Type.STOREHOUSE:
                return Constants.StorehouseCost;
            case Enums.Building_Type.WAREHOUSE:
                return Constants.WarehouseCost;
            case Enums.Building_Type.DEPOT:
                return Constants.DepotCost;
            case Enums.Building_Type.WATERWHEEL_GENERATOR:
                return Constants.WaterwheelCost;
            case Enums.Building_Type.COAL_FIRED_POWER_PLANT:
                return Constants.CoalfiredCost;
            case Enums.Building_Type.HYDROELECTRIC_DAM:
                return Constants.HydroelectricCost;
            case Enums.Building_Type.NUCLEAR_POWER_PLANT:
                return Constants.NuclearPlantCost;
            case Enums.Building_Type.QUANTUM_POWER_PLANT:
                return Constants.QuantumPlantCost;
            case Enums.Building_Type.PUBLIC_PARK:
                return Constants.PublicParkCost;
            case Enums.Building_Type.CIRCUS:
                return Constants.CircusCost;
            case Enums.Building_Type.THEATER_COMPLEX:
                return Constants.TheaterCost;
            case Enums.Building_Type.VIRTUAL_REALITY_CAFE:
                return Constants.VirtualRealityCafeCost;
            case Enums.Building_Type.VOID_PORTAL:
                return Constants.VoidPortalCost;
            case Enums.Building_Type.VOID_COMMUNICATOR:
                return Constants.VoidCommunicatorCost;
            case Enums.Building_Type.VOID_RADAR_ARRAY:
                return Constants.VoidRadarArrayCost;
            case Enums.Building_Type.FACTION_EMBASSY:
                return Constants.FactionEmbassyCost;
            case Enums.Building_Type.ABYSSAL_PATHFINDER:
                return Constants.AbyssalPathfinderCost;
            case Enums.Building_Type.VOID_RUDDER:
                return Constants.VoidRudderCost;
            case Enums.Building_Type.WEATHER_MANIPULATOR:
                return Constants.WeatherManipulatorCost;
            case Enums.Building_Type.DIPLO_MONUMENT:
                return Constants.DiploMonumentCost;
            case Enums.Building_Type.SCI_MONUMENT:
                return Constants.SciMonumentCost;
            case Enums.Building_Type.HAPP_MONUMENT:
                return Constants.HappMonumentCost;
            case Enums.Building_Type.IND_MONUMENT:
                return Constants.IndMonumentCost;
            case Enums.Building_Type.ISO_MONUMENT:
                return Constants.IsoMonumentCost;
            case Enums.Building_Type.MIL_MONUMENT:
                return Constants.MilMonumentCost;
            case Enums.Building_Type.FOOD_MONUMENT:
                return Constants.FoodMonumentCost;
            case Enums.Building_Type.HYDROPONICS_TOWER:
            case Enums.Building_Type.VILLA:
            case Enums.Building_Type.FACTORY:
            case Enums.Building_Type.HEADQUARTERS:
            case Enums.Building_Type.QUANTUM_BRAIN:
            case Enums.Building_Type.EXTRACTOR_MK_V:
            case Enums.Building_Type.DISTRIBUTION_CENTER:
            case Enums.Building_Type.QUANTUM_HOLOGRAM_THEATER:
            case Enums.Building_Type.GOD_SEAT:
            default:
                return new BuildingCost(0, 0, 0, 0, 0);
        }
    }

    public static void DeductResources(BuildingCost cost)
    {
        Instance.CurrentPopulation -= cost.RequiredPopulation;
        Instance.CurrentFood -= cost.RequiredFood;
        Instance.CurrentIndustry -= cost.RequiredIndustry;
        Instance.CurrentIsolium -= cost.RequiredIsolium;
        Instance.CurrentMilitary -= cost.RequiredMilitary;

        UI_Manager.UpdateResourcesText();
    }

    public static void DeductResources(UnitTrainingCost cost, Enums.Unit_Type type)
    {
        Instance.CurrentFood -= cost.RequiredFood;
        Instance.CurrentIndustry -= cost.RequiredIndustry;
        Instance.CurrentIsolium -= cost.RequiredIsolium;

        Instance.CurrentPopulation -= cost.RequiredMilitary;

        UI_Manager.UpdateResourcesText();
        UI_Manager.UpdateUnitCountText();
    }

    public static void AddProduction(Enums.Hex_Types type, int value, Enums.MonumentType monuType = Enums.MonumentType.DIPLO)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                Instance.FoodProduction += value;
                break;
            case Enums.Hex_Types.HOUSING:
                Instance.MaximumPopulation += value;
                break;
            case Enums.Hex_Types.INDUSTRY:
                Instance.IndustryProduction += value;
                break;
            case Enums.Hex_Types.MILITARY:
                Instance.MaximumMilitary += value;
                break;
            case Enums.Hex_Types.RESEARCH:
                Instance.ResearchProduction += value;
                break;
            case Enums.Hex_Types.ISOLIUM:
                Instance.IsoliumProduction += value;
                break;
            case Enums.Hex_Types.STORAGE:
                Instance.MaximumFood += value;
                Instance.MaximumIndustry += value;
                Instance.MaximumIsolium += value;
                break;
            case Enums.Hex_Types.MONUMENT://TODO THIS IS BREAKING SHIT
                switch(monuType)
                {
                    case Enums.MonumentType.DIPLO:
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.SCI:
                        Instance.ResearchProduction += value;
                        break;
                    case Enums.MonumentType.HAPP://todo this will be tricky
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.IND:
                        Instance.IndustryProduction += value;
                        break;
                    case Enums.MonumentType.ISO:
                        Instance.IsoliumProduction += value;
                        break;
                    case Enums.MonumentType.MIL://todo this will be tricky
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.FOOD:
                        Instance.FoodProduction += value;
                        break;
                }
                break;
            case Enums.Hex_Types.ENTERTAINMENT:
            case Enums.Hex_Types.SPECIAL:
            case Enums.Hex_Types.POWER:
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                break;
        }
    }

    public static void RemoveProduction(Enums.Hex_Types type, int value, Enums.MonumentType monuType = Enums.MonumentType.DIPLO)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                if (Instance.FoodProduction - value <= 0)
                {
                    Instance.FoodProduction = 0;
                }
                else
                {
                    Instance.FoodProduction -= value;
                }
                break;
            case Enums.Hex_Types.HOUSING:
                if (Instance.MaximumPopulation - value <= 0)
                {
                    Instance.MaximumPopulation = 0;
                }
                else
                {
                    Instance.MaximumPopulation -= value;
                }
                break;
            case Enums.Hex_Types.INDUSTRY:
                if (Instance.IndustryProduction - value <= 0)
                {
                    Instance.IndustryProduction = 0;
                }
                else
                {
                    Instance.IndustryProduction -= value;
                }
                break;
            case Enums.Hex_Types.MILITARY:
                if (Instance.MaximumMilitary - value <= 0)
                {
                    Instance.MaximumMilitary = 0;
                }
                else
                {
                    Instance.MaximumMilitary -= value;
                }
                break;
            case Enums.Hex_Types.RESEARCH:
                if (Instance.ResearchProduction - value <= 0)
                {
                    Instance.ResearchProduction = 0;
                }
                else
                {
                    Instance.ResearchProduction -= value;
                }
                break;
            case Enums.Hex_Types.ISOLIUM:
                if (Instance.IsoliumProduction - value <= 0)
                {
                    Instance.IsoliumProduction = 0;
                }
                else
                {
                    Instance.IsoliumProduction -= value;
                }
                break;
            case Enums.Hex_Types.STORAGE:
                if (Instance.MaximumFood - value <= 0)
                {
                    Instance.MaximumFood = 0;
                }
                else
                {
                    Instance.MaximumFood -= value;
                }

                if (Instance.MaximumIndustry - value <= 0)
                {
                    Instance.MaximumIndustry = 0;
                }
                else
                {
                    Instance.MaximumIndustry -= value;
                }

                if (Instance.MaximumIsolium - value <= 0)
                {
                    Instance.MaximumIsolium = 0;
                }
                else
                {
                    Instance.MaximumIsolium -= value;
                }
                break;
            case Enums.Hex_Types.ENTERTAINMENT:
                break;
            case Enums.Hex_Types.SPECIAL:
                break;
            case Enums.Hex_Types.MONUMENT:
                switch (monuType)
                {
                    case Enums.MonumentType.DIPLO:
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.SCI:
                        if (Instance.ResearchProduction - value <= 0)
                        {
                            Instance.ResearchProduction = 0;
                        }
                        else
                        {
                            Instance.ResearchProduction -= value;
                        }
                        break;
                    case Enums.MonumentType.HAPP://todo this will be tricky
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.IND:
                        if (Instance.IndustryProduction - value <= 0)
                        {
                            Instance.IndustryProduction = 0;
                        }
                        else
                        {
                            Instance.IndustryProduction -= value;
                        }
                        break;
                    case Enums.MonumentType.ISO:
                        if (Instance.IsoliumProduction - value <= 0)
                        {
                            Instance.IsoliumProduction = 0;
                        }
                        else
                        {
                            Instance.IsoliumProduction -= value;
                        }
                        break;
                    case Enums.MonumentType.MIL://todo this will be tricky
                        throw new System.NotImplementedException();
                    case Enums.MonumentType.FOOD:
                        if (Instance.FoodProduction - value <= 0)
                        {
                            Instance.FoodProduction = 0;
                        }
                        else
                        {
                            Instance.FoodProduction -= value;
                        }
                        break;
                }
                break;
            case Enums.Hex_Types.POWER:
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                break;
        }
    }

    public static UnitTrainingCost GetUnitCost(Enums.Unit_Type type)
    {
        switch (type)
        {
            case Enums.Unit_Type.GRUNT:
                return Constants.GRUNT_TRAINING_COST;
            case Enums.Unit_Type.SHOOTER:
                return Constants.SHOOTER_TRAINING_COST;
            case Enums.Unit_Type.DEFENDER:
                return Constants.DEFENDER_TRAINING_COST;
            case Enums.Unit_Type.GUNNER:
                return Constants.GUNNER_TRAINING_COST;
            case Enums.Unit_Type.SNIPER:
                return Constants.SNIPER_TRAINING_COST;
            case Enums.Unit_Type.SCOUT:
                return Constants.SCOUT_TRAINING_COST;
            case Enums.Unit_Type.ACE:
                return Constants.ACE_TRAINING_COST;
            case Enums.Unit_Type.CANNONEER:
                return Constants.CANNONEER_TRAINING_COST;
            case Enums.Unit_Type.GUARDIAN:
                return Constants.GUARDIAN_TRAINING_COST;
            default:
                return new UnitTrainingCost(0, 0, 0, 0);
        }
    }

    public static bool HaveRequiredUnitTrainingCosts(Enums.Unit_Type type, UnitTrainingCost cost)
    {
        if (type == Enums.Unit_Type.ACE && Instance.AceCount >= Instance.MaximumAces)
        {
            return false;
        }

        if (type == Enums.Unit_Type.CANNONEER && Instance.CannoneerCount >= Instance.MaximumCannoneers)
        {
            return false;
        }

        if (type == Enums.Unit_Type.GUARDIAN && Instance.GuardianCount >= Instance.MaximumGuardians)
        {
            return false;
        }

        if (cost.RequiredMilitary > Instance.CurrentPopulation)
        {
            return false;
        }
        if (cost.RequiredMilitary + Instance.CurrentMilitary > Instance.MaximumMilitary)
        {
            return false;
        }

        if (cost.RequiredFood > Instance.CurrentFood)
        {
            return false;
        }

        if (cost.RequiredIndustry > Instance.CurrentIndustry)
        {
            return false;
        }

        if (cost.RequiredIsolium > Instance.CurrentIsolium)
        {
            return false;
        }

        return true;
    }

    public static void IncreaseHeroUnitCap(Enums.Unit_Type type, int amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.ACE:
                Instance.MaximumAces += amount;
                break;
            case Enums.Unit_Type.CANNONEER:
                Instance.MaximumCannoneers += amount;
                break;
            case Enums.Unit_Type.GUARDIAN:
                Instance.MaximumGuardians += amount;
                break;
            case Enums.Unit_Type.GRUNT:
            case Enums.Unit_Type.SHOOTER:
            case Enums.Unit_Type.DEFENDER:
            case Enums.Unit_Type.GUNNER:
            case Enums.Unit_Type.SNIPER:
            case Enums.Unit_Type.SCOUT:
            default:
                break;
        }
    }

    public static void DecreaseHeroUnitCap(Enums.Unit_Type type, int amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.ACE:
                Instance.MaximumAces -= amount;
                break;
            case Enums.Unit_Type.CANNONEER:
                Instance.MaximumCannoneers -= amount;
                break;
            case Enums.Unit_Type.GUARDIAN:
                Instance.MaximumGuardians -= amount;
                break;
            case Enums.Unit_Type.GRUNT:
            case Enums.Unit_Type.SHOOTER:
            case Enums.Unit_Type.DEFENDER:
            case Enums.Unit_Type.GUNNER:
            case Enums.Unit_Type.SNIPER:
            case Enums.Unit_Type.SCOUT:
            default:
                break;
        }
    }

    public static void IncreaseUnitCount(Enums.Unit_Type type, int amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.GRUNT:
                Instance.GruntCount += amount;
                UI_Manager.SetGruntCountText(Instance.GruntCount);

                break;
            case Enums.Unit_Type.SHOOTER:
                Instance.ShooterCount += amount;
                UI_Manager.SetShooterCountText(Instance.ShooterCount);

                break;
            case Enums.Unit_Type.DEFENDER:
                Instance.DefenderCount += amount;
                UI_Manager.SetDefenderCountText(Instance.DefenderCount);

                break;
            case Enums.Unit_Type.GUNNER:
                Instance.GunnerCount += amount;
                UI_Manager.SetGunnerCountText(Instance.GunnerCount);

                break;
            case Enums.Unit_Type.SNIPER:
                Instance.SniperCount += amount;
                UI_Manager.SetSniperCountText(Instance.SniperCount);

                break;
            case Enums.Unit_Type.SCOUT:
                Instance.ScoutCount += amount;
                UI_Manager.SetScoutCountText(Instance.ScoutCount);

                break;
            case Enums.Unit_Type.ACE:
                Instance.AceCount += amount;
                UI_Manager.SetAceCountText(Instance.AceCount);

                break;
            case Enums.Unit_Type.CANNONEER:
                Instance.CannoneerCount += amount;
                UI_Manager.SetCannoneerText(Instance.CannoneerCount);

                break;
            case Enums.Unit_Type.GUARDIAN:
                Instance.GuardianCount += amount;
                UI_Manager.SetGuardianText(Instance.GuardianCount);
                break;
            default:
                break;
        }
    }

    public static void DecreaseUnitCount(Enums.Unit_Type type, int amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.GRUNT:
                if (Instance.GruntCount - amount <= 0)
                {
                    Instance.GruntCount = 0;
                }
                else
                {
                    Instance.GruntCount -= amount;
                }
                UI_Manager.SetGruntCountText(Instance.GruntCount);
                break;
            case Enums.Unit_Type.SHOOTER:
                if (Instance.ShooterCount - amount <= 0)
                {
                    Instance.ShooterCount = 0;
                }
                else
                {
                    Instance.ShooterCount -= amount;
                }
                UI_Manager.SetShooterCountText(Instance.ShooterCount);
                break;
            case Enums.Unit_Type.DEFENDER:
                if (Instance.DefenderCount - amount <= 0)
                {
                    Instance.DefenderCount = 0;
                }
                else
                {
                    Instance.DefenderCount -= amount;
                }
                UI_Manager.SetDefenderCountText(Instance.DefenderCount);
                break;
            case Enums.Unit_Type.GUNNER:
                if (Instance.GunnerCount - amount <= 0)
                {
                    Instance.GunnerCount = 0;
                }
                else
                {
                    Instance.GunnerCount -= amount;
                }
                UI_Manager.SetGunnerCountText(Instance.GunnerCount);
                break;
            case Enums.Unit_Type.SNIPER:
                if (Instance.SniperCount - amount <= 0)
                {
                    Instance.SniperCount = 0;
                }
                else
                {
                    Instance.SniperCount -= amount;
                }
                UI_Manager.SetSniperCountText(Instance.SniperCount);
                break;
            case Enums.Unit_Type.SCOUT:
                if (Instance.ScoutCount - amount <= 0)
                {
                    Instance.ScoutCount = 0;
                }
                else
                {
                    Instance.ScoutCount -= amount;
                }
                UI_Manager.SetScoutCountText(Instance.ScoutCount);
                break;
            case Enums.Unit_Type.ACE:
                if (Instance.AceCount - amount <= 0)
                {
                    Instance.AceCount = 0;
                }
                else
                {
                    Instance.AceCount -= amount;
                }
                UI_Manager.SetAceCountText(Instance.AceCount);
                break;
            case Enums.Unit_Type.CANNONEER:
                if (Instance.CannoneerCount - amount <= 0)
                {
                    Instance.CannoneerCount = 0;
                }
                else
                {
                    Instance.CannoneerCount -= amount;
                }
                UI_Manager.SetCannoneerText(Instance.CannoneerCount);
                break;
            case Enums.Unit_Type.GUARDIAN:
                if (Instance.GuardianCount - amount <= 0)
                {
                    Instance.GuardianCount = 0;
                }
                else
                {
                    Instance.GuardianCount -= amount;
                }
                UI_Manager.SetGuardianText(Instance.GuardianCount);
                break;
            default:
                break;
        }
    }

    public static void AddUnitCostReduction(Enums.Unit_Type type, float amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.SHOOTER:
                if (Instance.ShooterTrainingCostReduction - amount <= Constants.MAXIMUM_TRAINING_COST_REDUCTION)
                {
                    Instance.ShooterTrainingCostReduction = Constants.MAXIMUM_TRAINING_COST_REDUCTION;
                }
                else
                {
                    Instance.ShooterTrainingCostReduction -= amount;
                }
                break;
            case Enums.Unit_Type.DEFENDER:
                if (Instance.DefenderTrainingCostReduction - amount <= Constants.MAXIMUM_TRAINING_COST_REDUCTION)
                {
                    Instance.DefenderTrainingCostReduction = Constants.MAXIMUM_TRAINING_COST_REDUCTION;
                }
                else
                {
                    Instance.DefenderTrainingCostReduction -= amount;
                }
                break;
            case Enums.Unit_Type.GUNNER:
                if (Instance.GunnerTrainingCostReduction - amount <= Constants.MAXIMUM_TRAINING_COST_REDUCTION)
                {
                    Instance.GunnerTrainingCostReduction = Constants.MAXIMUM_TRAINING_COST_REDUCTION;
                }
                else
                {
                    Instance.GunnerTrainingCostReduction -= amount;
                }
                break;
            case Enums.Unit_Type.SNIPER:
                if (Instance.SniperTrainingCostReduction - amount <= Constants.MAXIMUM_TRAINING_COST_REDUCTION)
                {
                    Instance.SniperTrainingCostReduction = Constants.MAXIMUM_TRAINING_COST_REDUCTION;
                }
                else
                {
                    Instance.SniperTrainingCostReduction -= amount;
                }
                break;
            case Enums.Unit_Type.SCOUT:
                if (Instance.ScoutTrainingCostReduction - amount <= Constants.MAXIMUM_TRAINING_COST_REDUCTION)
                {
                    Instance.ScoutTrainingCostReduction = Constants.MAXIMUM_TRAINING_COST_REDUCTION;
                }
                else
                {
                    Instance.ScoutTrainingCostReduction -= amount;
                }
                break;
            case Enums.Unit_Type.GRUNT:
            case Enums.Unit_Type.ACE:
            case Enums.Unit_Type.CANNONEER:
            case Enums.Unit_Type.GUARDIAN:
            default:
                break;
        }
    }

    public static void RemoveUnitCostReduction(Enums.Unit_Type type, float amount)
    {
        switch (type)
        {
            case Enums.Unit_Type.SHOOTER:
                if (Instance.ShooterTrainingCostReduction + amount >= 1f)
                {
                    Instance.ShooterTrainingCostReduction = 1f;
                }
                else
                {
                    Instance.ShooterTrainingCostReduction += amount;
                }
                break;
            case Enums.Unit_Type.DEFENDER:
                if (Instance.DefenderTrainingCostReduction + amount >= 1f)
                {
                    Instance.DefenderTrainingCostReduction = 1f;
                }
                else
                {
                    Instance.DefenderTrainingCostReduction += amount;
                }
                break;
            case Enums.Unit_Type.GUNNER:
                if (Instance.GunnerTrainingCostReduction + amount >= 1f)
                {
                    Instance.GunnerTrainingCostReduction = 1f;
                }
                else
                {
                    Instance.GunnerTrainingCostReduction += amount;
                }
                break;
            case Enums.Unit_Type.SNIPER:
                if (Instance.SniperTrainingCostReduction + amount >= 1f)
                {
                    Instance.SniperTrainingCostReduction = 1f;
                }
                else
                {
                    Instance.SniperTrainingCostReduction += amount;
                }
                break;
            case Enums.Unit_Type.SCOUT:
                if (Instance.ScoutTrainingCostReduction + amount >= 1f)
                {
                    Instance.ScoutTrainingCostReduction = 1f;
                }
                else
                {
                    Instance.ScoutTrainingCostReduction += amount;
                }
                break;
            case Enums.Unit_Type.GRUNT:
            case Enums.Unit_Type.ACE:
            case Enums.Unit_Type.CANNONEER:
            case Enums.Unit_Type.GUARDIAN:
            default:
                break;
        }
    }

    private void AddProductionResources()
    {
        if (CurrentFood + FoodProduction < MaximumFood)
        {
            CurrentFood += FoodProduction;
        }
        else if (CurrentFood < MaximumFood)
        {
            CurrentFood = MaximumFood;
        }

        if (CurrentIndustry + IndustryProduction < MaximumIndustry)
        {
            CurrentIndustry += IndustryProduction;
        }
        else if (CurrentIndustry < MaximumIndustry)
        {
            CurrentIndustry = MaximumIndustry;
        }

        if (CurrentIsolium + IsoliumProduction < MaximumIsolium)
        {
            CurrentIsolium += IsoliumProduction;
        }
        else if (CurrentIsolium < MaximumIsolium)
        {
            CurrentIsolium = MaximumIsolium;
        }
    }

    private void AddResearchProgress()
    {
        //TODO tick research progress based on ResearchProduction
    }

    private void AddPopulation()
    {
        if (CurrentPopulation < MaximumPopulation)
        {
            CurrentPopulation += PopulationGrowthRate;
        }
    }

    public static void AddPopGrowth(int amount)
    {
        if(Instance.PopGrowthDecimal + amount >= 100)
        {
            Instance.PopulationGrowthRate++;
            Instance.PopGrowthDecimal = (Instance.PopGrowthDecimal + amount) - 100;
        }
        else
        {
            Instance.PopGrowthDecimal += amount;
        }
    }

    public static void RemovePopGrowth(int amount)
    {
        if(Instance.PopGrowthDecimal - amount <= -100)
        {
            Instance.PopulationGrowthRate--;
            Instance.PopGrowthDecimal = (Instance.PopGrowthDecimal - amount) + 100;
        }
        else
        {
            Instance.PopGrowthDecimal -= amount;
        }
    }

    private IEnumerator TickResources()
    {
        while (true)
        {
            if (!ResourcesTickPaused || !Event_Manager.IsGamePaused)
            {
                //Debug.Log("Ticking Resources");
                AddProductionResources();
                AddPopulation();
                AddResearchProgress();
                UI_Manager.UpdateResourcesText();
            }

            yield return new WaitForSeconds(Constants.TICK_SPEED);
        }
    }

    public static void StartResourcesTick()
    {
        Instance.StartCoroutine(Instance.TickResources());
    }

    public static void PauseResourcesTick()
    {
        Instance.ResourcesTickPaused = true;
    }

    public static void UnpauseResourcesTick()
    {
        Instance.ResourcesTickPaused = false;
    }

    public static void StopResourcesTick()
    {
        Instance.StopCoroutine(Instance.TickResources());
    }

    public static void UpgradeGodSeat()
    {
        //deduct resources
        if (Instance.GodSeatUpgradeIsoliumCost > Instance.CurrentIsolium
            || Instance.GodSeatUpgradeIndustryCost > Instance.CurrentIndustry
            || Instance.GodSeatUpgradeFoodCost > Instance.CurrentFood
            || Instance.GodSeatUpgradePopCost > Instance.CurrentPopulation)
        {
            UI_Manager.FlashMissingResources(new BuildingCost(Instance.GodSeatUpgradePopCost, Instance.GodSeatUpgradeFoodCost, Instance.GodSeatUpgradeIsoliumCost, Instance.GodSeatUpgradeIndustryCost, 0));
            return;
        }

        Instance.MaximumHexRange += Constants.HEX_RANGE_UPGRADE;
        Instance.GodSeatLevel++;

        Instance.PrevGodSeatIsoliumCost = Instance.GodSeatUpgradeIsoliumCost;
        Instance.PrevGodSeatIndustryCost = Instance.GodSeatUpgradeIndustryCost;
        Instance.PrevGodSeatFoodCost = Instance.GodSeatUpgradeFoodCost;
        Instance.PrevGodSeatPopCost = Instance.GodSeatUpgradePopCost;

        //PrevCost + (Random(PrevCost, 5 * PrevCost) / Level)
        Instance.GodSeatUpgradeIsoliumCost = Instance.PrevGodSeatIsoliumCost + (Random.Range(Instance.PrevGodSeatIsoliumCost, 5 * Instance.PrevGodSeatIsoliumCost) / Instance.GodSeatLevel);
        Instance.GodSeatUpgradeIndustryCost = Instance.PrevGodSeatIndustryCost + (Random.Range(Instance.PrevGodSeatIndustryCost, 5 * Instance.PrevGodSeatIndustryCost) / Instance.GodSeatLevel);
        Instance.GodSeatUpgradeFoodCost = Instance.PrevGodSeatFoodCost + (Random.Range(Instance.PrevGodSeatFoodCost, 5 * Instance.PrevGodSeatFoodCost) / Instance.GodSeatLevel);
        Instance.GodSeatUpgradePopCost = Instance.PrevGodSeatPopCost + (Random.Range(Instance.PrevGodSeatPopCost, 5 * Instance.PrevGodSeatPopCost) / Instance.GodSeatLevel);

        UI_Manager.UpdateInfoPanel(Enums.Building_Type.GOD_SEAT);
    }

    public static int GetMonumentProduction(Enums.Building_Type type)
    {
        switch (type)
        {
            case Enums.Building_Type.DIPLO_MONUMENT:
                return Instance.DiploMonumentPrevBonus;
            case Enums.Building_Type.SCI_MONUMENT:
                return Instance.SciMonumentPrevBonus;
            case Enums.Building_Type.HAPP_MONUMENT:
                return Instance.HappMonumentPrevBonus;
            case Enums.Building_Type.IND_MONUMENT:
                return Instance.IndMonumentPrevBonus;
            case Enums.Building_Type.ISO_MONUMENT:
                return Instance.IsoMonumentPrevBonus;
            case Enums.Building_Type.MIL_MONUMENT:
                return Instance.MilMonumentPrevBonus;
            case Enums.Building_Type.FOOD_MONUMENT:
                return Instance.FoodMonumentPrevBonus;
            default:
                return -1;//this is dangerous
        }
    }

    public static int UpdateMonumentProduction(Enums.Building_Type type)
    {
        switch (type)//Rand(PrevBonus * LowerBound, PrevBonus * UpperBound)
        {
            case Enums.Building_Type.DIPLO_MONUMENT://add to diplo cost modifier
                return Instance.DiploMonumentPrevBonus = (int)Random.Range(Instance.DiploMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.DiploMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.SCI_MONUMENT://add to research speed
                return Instance.SciMonumentPrevBonus = (int)Random.Range(Instance.SciMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.SciMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.HAPP_MONUMENT://add to popgrowthdecimal
                return Instance.HappMonumentPrevBonus = (int)Random.Range(Instance.HappMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.HappMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.IND_MONUMENT://add to industrial prod
                return Instance.IndMonumentPrevBonus = (int)Random.Range(Instance.IndMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.IndMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.ISO_MONUMENT://add to iso prod
                return Instance.IsoMonumentPrevBonus = (int)Random.Range(Instance.IsoMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.IsoMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.MIL_MONUMENT://add to a stat modifier
                return Instance.MilMonumentPrevBonus = (int)Random.Range(Instance.MilMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.MilMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            case Enums.Building_Type.FOOD_MONUMENT://add to food prod
                return Instance.FoodMonumentPrevBonus = (int)Random.Range(Instance.FoodMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_LOWER_BOUND, Instance.FoodMonumentPrevBonus * Constants.MONUMENT_PRODUCTION_UPPER_BOUND);
            default:
                Debug.LogError("Monument Production Fallthrough Error");
                return 0;
        }
    }

    public static void UpdateMonumentCost(Enums.Building_Type type)
    {
        switch (type)//PrevCost + (Rand(PrevCost, PrevCost * 2) / Count)
        {
            case Enums.Building_Type.DIPLO_MONUMENT:
                Constants.DiploMonumentCost.RequiredIndustry = Constants.DiploMonumentCost.RequiredIndustry + (Random.Range(Constants.DiploMonumentCost.RequiredIndustry, Constants.DiploMonumentCost.RequiredIndustry * 2) / Instance.DiploMonumentCount);
                Constants.DiploMonumentCost.RequiredIsolium = Constants.DiploMonumentCost.RequiredIsolium + (Random.Range(Constants.DiploMonumentCost.RequiredIsolium, Constants.DiploMonumentCost.RequiredIsolium * 2) / Instance.DiploMonumentCount);
                break;
            case Enums.Building_Type.SCI_MONUMENT:
                Constants.SciMonumentCost.RequiredIndustry = Constants.SciMonumentCost.RequiredIndustry + (Random.Range(Constants.SciMonumentCost.RequiredIndustry, Constants.SciMonumentCost.RequiredIndustry * 2) / Instance.SciMonumentCount);
                Constants.SciMonumentCost.RequiredIsolium = Constants.SciMonumentCost.RequiredIsolium + (Random.Range(Constants.SciMonumentCost.RequiredIsolium, Constants.SciMonumentCost.RequiredIsolium * 2) / Instance.SciMonumentCount);
                break;
            case Enums.Building_Type.HAPP_MONUMENT:
                Constants.HappMonumentCost.RequiredFood = Constants.HappMonumentCost.RequiredFood + (Random.Range(Constants.HappMonumentCost.RequiredFood, Constants.HappMonumentCost.RequiredFood * 2) / Instance.HappMonumentCount);
                Constants.HappMonumentCost.RequiredIndustry = Constants.HappMonumentCost.RequiredIndustry + (Random.Range(Constants.HappMonumentCost.RequiredIndustry, Constants.HappMonumentCost.RequiredIndustry * 2) / Instance.HappMonumentCount);
                Constants.HappMonumentCost.RequiredIsolium = Constants.HappMonumentCost.RequiredIsolium + (Random.Range(Constants.HappMonumentCost.RequiredIsolium, Constants.HappMonumentCost.RequiredIsolium * 2) / Instance.HappMonumentCount);
                break;
            case Enums.Building_Type.IND_MONUMENT:
                Constants.IndMonumentCost.RequiredIndustry = Constants.IndMonumentCost.RequiredIndustry + (Random.Range(Constants.IndMonumentCost.RequiredIndustry, Constants.IndMonumentCost.RequiredIndustry * 2) / Instance.IndMonumentCount);
                Constants.IndMonumentCost.RequiredIsolium = Constants.IndMonumentCost.RequiredIsolium + (Random.Range(Constants.IndMonumentCost.RequiredIsolium, Constants.IndMonumentCost.RequiredIsolium * 2) / Instance.IndMonumentCount);
                break;
            case Enums.Building_Type.ISO_MONUMENT:
                Constants.IsoMonumentCost.RequiredIndustry = Constants.IsoMonumentCost.RequiredIndustry + (Random.Range(Constants.IsoMonumentCost.RequiredIndustry, Constants.IsoMonumentCost.RequiredIndustry * 2) / Instance.IsoMonumentCount);
                Constants.IsoMonumentCost.RequiredIsolium = Constants.IsoMonumentCost.RequiredIsolium + (Random.Range(Constants.IsoMonumentCost.RequiredIsolium, Constants.IsoMonumentCost.RequiredIsolium * 2) / Instance.IsoMonumentCount);
                break;
            case Enums.Building_Type.MIL_MONUMENT:
                Constants.MilMonumentCost.RequiredIndustry = Constants.MilMonumentCost.RequiredIndustry + (Random.Range(Constants.MilMonumentCost.RequiredIndustry, Constants.MilMonumentCost.RequiredIndustry * 2) / Instance.MilMonumentCount);
                Constants.MilMonumentCost.RequiredIsolium = Constants.MilMonumentCost.RequiredIsolium + (Random.Range(Constants.MilMonumentCost.RequiredIsolium, Constants.MilMonumentCost.RequiredIsolium * 2) / Instance.MilMonumentCount);
                Constants.MilMonumentCost.RequiredMilitary = Constants.MilMonumentCost.RequiredMilitary + (Random.Range(Constants.MilMonumentCost.RequiredMilitary, Constants.MilMonumentCost.RequiredMilitary * 2) / Instance.MilMonumentCount);
                break;
            case Enums.Building_Type.FOOD_MONUMENT:
                Constants.FoodMonumentCost.RequiredFood = Constants.FoodMonumentCost.RequiredFood + (Random.Range(Constants.FoodMonumentCost.RequiredFood, Constants.FoodMonumentCost.RequiredFood * 2) / Instance.FoodMonumentCount);
                Constants.FoodMonumentCost.RequiredIndustry = Constants.FoodMonumentCost.RequiredIndustry + (Random.Range(Constants.FoodMonumentCost.RequiredIndustry, Constants.FoodMonumentCost.RequiredIndustry * 2) / Instance.FoodMonumentCount);
                Constants.FoodMonumentCost.RequiredIsolium = Constants.FoodMonumentCost.RequiredIsolium + (Random.Range(Constants.FoodMonumentCost.RequiredIsolium, Constants.FoodMonumentCost.RequiredIsolium * 2) / Instance.FoodMonumentCount);
                break;
            default:
                break;
        }
    }

    public static void UpdateMonumentCount(Enums.Building_Type type, bool increase)
    {
        switch (type)
        {
            case Enums.Building_Type.DIPLO_MONUMENT:
                if(increase)
                {
                    Instance.DiploMonumentCount++;
                }
                else
                {
                    Instance.DiploMonumentCount--;
                }
                break;
            case Enums.Building_Type.SCI_MONUMENT:
                if (increase)
                {
                    Instance.SciMonumentCount++;
                }
                else
                {
                    Instance.SciMonumentCount--;
                }
                break;
            case Enums.Building_Type.HAPP_MONUMENT:
                if (increase)
                {
                    Instance.HappMonumentCount++;
                }
                else
                {
                    Instance.HappMonumentCount--;
                }
                break;
            case Enums.Building_Type.IND_MONUMENT:
                if (increase)
                {
                    Instance.IndMonumentCount++;
                }
                else
                {
                    Instance.IndMonumentCount--;
                }
                break;
            case Enums.Building_Type.ISO_MONUMENT:
                if (increase)
                {
                    Instance.IsoMonumentCount++;
                }
                else
                {
                    Instance.IsoMonumentCount--;
                }
                break;
            case Enums.Building_Type.MIL_MONUMENT:
                if (increase)
                {
                    Instance.MilMonumentCount++;
                }
                else
                {
                    Instance.MilMonumentCount--;
                }
                
                break;
            case Enums.Building_Type.FOOD_MONUMENT:
                if (increase)
                {
                    Instance.FoodMonumentCount++;
                }
                else
                {
                    Instance.FoodMonumentCount--;
                }
                break;
            default:
                break;
        }
    }
}