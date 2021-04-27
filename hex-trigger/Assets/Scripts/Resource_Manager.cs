using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : Singleton<Resource_Manager>
{
    public int AvailableHexes//TODO this will need its own formula for 'buying' new hexes
    {
        get
        {
            return AvailableHexes;
        }
        set
        {
            if(AvailableHexes - value <= 0)
            {
                AvailableHexes = 0;
            }
            else
            {
                AvailableHexes -= value;
            }
        }
    }

    public int AvailableFood
    {
        get
        {
            return AvailableFood;
        }
        set
        {
            if(AvailableFood - value <= 0)
            {
                AvailableFood = 0;
            }
            else
            {
                AvailableFood -= value;
            }
        }
    }

    public int AvailableHousing
    {
        get
        {
            return AvailableHousing;
        }
        set
        {
            if (AvailableHousing - value <= 0)
            {
                AvailableHousing = 0;
            }
            else
            {
                AvailableHousing -= value;
            }
        }
    }

    public int AvailablePopulation
    {
        get
        {
            return AvailablePopulation;
        }
        set
        {
            if (AvailablePopulation - value <= 0)
            {
                AvailablePopulation = 0;
            }
            else
            {
                AvailablePopulation -= value;
            }
        }
    }

    public int AvailableIndustry
    {
        get
        {
            return AvailableIndustry;
        }
        set
        {
            if (AvailableIndustry - value <= 0)
            {
                AvailableIndustry = 0;
            }
            else
            {
                AvailableIndustry -= value;
            }
        }
    }

    public int AvailableIsolium
    {
        get
        {
            return AvailableIsolium;
        }
        set
        {
            if (AvailableIsolium - value <= 0)
            {
                AvailableIsolium = 0;
            }
            else
            {
                AvailableIsolium -= value;
            }
        }
    }

    public int AvailableMilitary
    {
        get
        {
            return AvailableMilitary;
        }
        set
        {
            if (AvailableMilitary - value <= 0)
            {
                AvailableMilitary = 0;
            }
            else
            {
                AvailableMilitary -= value;
            }
        }
    }

    public static void DEV_AddResources()
    {
        Instance.AvailableHexes = 1000;
        Instance.AvailableFood = 1000;
        Instance.AvailableHousing = 1000;
        Instance.AvailablePopulation = 1000;
        Instance.AvailableIndustry = 1000;
        Instance.AvailableIsolium = 1000;
        Instance.AvailableMilitary = 1000;
    }

    public static bool HaveRequiredBuildingCosts(BuildingCost cost)
    {
        if(cost.RequiredHexes > Instance.AvailableHexes)
        {
            return false;
        }

        if(cost.RequiredFood > Instance.AvailableFood)
        {
            return false;
        }

        if(cost.RequiredPopulation > Instance.AvailablePopulation)
        {
            return false;
        }

        if(cost.RequiredIndustry > Instance.AvailableIndustry)
        {
            return false;
        }

        if(cost.RequiredIsolium > Instance.AvailableIsolium)
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
    }
}
