using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : Singleton<Resource_Manager>
{
    public int AvailableHexes;//TODO this will need its own formula for 'buying' new hexes

    public int AvailableFood;//currently available food, increases based on food production

    public int AvailableHousing;//maximum population, increases as new building hexes are built

    public int AvailablePopulation;//population should increase over time and deduct based on building costs

    public int AvailableIndustry;//currently available industry, increase based on industry production

    public int AvailableIsolium;//currently available isolium, increases based on isolium production

    public int AvailableMilitary;//should only increase when the player allocates more

    public int MaximumMilitary;//maximum military population, shoud increase as new military hexes are built

    public int MaximumAces;//maximum number of aces, should increase as new Ace's Arena hexes are built

    public int MaximumCannoneers;//maximum number of cannoneers, should increase as new Cannoneer's Tower hexes are built

    public int MaximumGuardians;//maximum number of aces, should increase as new Guardian's Last Stand hexes are built

    [SerializeField] private int FoodProduction;
    [SerializeField] private int IndustryProduction;
    [SerializeField] private int IsoliumProduction;
    [SerializeField] private int ResearchProduction;
    [SerializeField] private int PopulationGrowthRate = Constants.POP_GROWTH_RATE;//TODO should be modified by how 'happy' city is
    [SerializeField] private float ShooterTrainingCostReduction = 1;
    [SerializeField] private float DefenderTrainingCostReduction = 1;
    [SerializeField] private float GunnerTrainingCostReduction = 1;
    [SerializeField] private float SniperTrainingCostReduction = 1;
    [SerializeField] private float ScoutTrainingCostReduction = 1;

    public bool ResourcesTickPaused = false;

    public static void DEV_MaxOutResources()
    {
        Instance.AvailableHexes = 1000;
        Instance.AvailableFood = 1000;
        Instance.AvailableHousing = 1000;
        Instance.AvailablePopulation = 1000;
        Instance.AvailableIndustry = 1000;
        Instance.AvailableIsolium = 1000;
        Instance.AvailableMilitary = 1000;
        Instance.MaximumMilitary = 1000;
    }

    public static bool HaveRequiredBuildingCosts(BuildingCost cost)
    {
        if (cost.RequiredHexes > Instance.AvailableHexes)
        {
            return false;
        }

        if (cost.RequiredFood > Instance.AvailableFood)
        {
            return false;
        }

        if (cost.RequiredPopulation > Instance.AvailablePopulation)
        {
            return false;
        }

        if (cost.RequiredIndustry > Instance.AvailableIndustry)
        {
            return false;
        }

        if (cost.RequiredMilitary > Instance.AvailableMilitary)
        {
            return false;
        }

        if (cost.RequiredIsolium > Instance.AvailableIsolium)
        {
            return false;
        }

        return true;
    }

    public static BuildingCost GetBuildingCost(Enums.Building_Type type)//TODO update this to include combat unit hexes
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
            case Enums.Building_Type.STOCKPILE:
                return Constants.StockpileCost;
            case Enums.Building_Type.STOREHOUSE:
                return Constants.StorehouseCost;
            case Enums.Building_Type.WAREHOUSE:
                return Constants.WarehouseCost;
            case Enums.Building_Type.DEPOT:
                return Constants.DepotCost;
            case Enums.Building_Type.HYDROPONICS_TOWER:
            case Enums.Building_Type.VILLA:
            case Enums.Building_Type.FACTORY:
            case Enums.Building_Type.HEADQUARTERS:
            case Enums.Building_Type.QUANTUM_BRAIN:
            case Enums.Building_Type.DISTRIBUTION_CENTER:
            case Enums.Building_Type.GOD_SEAT:
            default:
                return new BuildingCost(0, 0, 0, 0, 0, 0);
        }
    }

    public static void DeductResources(BuildingCost cost)
    {
        Instance.AvailableHexes -= cost.RequiredHexes;
        Instance.AvailablePopulation -= cost.RequiredPopulation;
        Instance.AvailableFood -= cost.RequiredFood;
        Instance.AvailableIndustry -= cost.RequiredIndustry;
        Instance.AvailableIsolium -= cost.RequiredIsolium;
        Instance.AvailableMilitary -= cost.RequiredMilitary;

        UI_Manager.UpdateResourcesText();
    }

    public static void AddProduction(Enums.Hex_Types type, int value)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                Instance.FoodProduction += value;
                break;
            case Enums.Hex_Types.HOUSING:
                Instance.AvailableHousing += value;
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
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                break;
        }
    }

    public static void RemoveProduction(Enums.Hex_Types type, int value)
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
                if (Instance.AvailableHousing - value <= 0)
                {
                    Instance.AvailableHousing = 0;
                }
                else
                {
                    Instance.AvailableHousing -= value;
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
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                break;
        }
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
                if(Instance.ShooterTrainingCostReduction + amount >= 1f)
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
        AvailableFood += FoodProduction;
        AvailableIndustry += IndustryProduction;
        AvailableIsolium += IsoliumProduction;
    }

    private void AddResearchProgress()
    {
        //TODO tick research progress based on ResearchProduction
    }

    private void AddPopulation()
    {
        if (AvailablePopulation < AvailableHousing)
        {
            AvailablePopulation += PopulationGrowthRate;
        }
    }

    private IEnumerator TickResources()
    {
        while (true)
        {
            if (!ResourcesTickPaused)
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

}