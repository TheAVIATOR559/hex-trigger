using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : Singleton<Resource_Manager>
{
    public int AvailableHexes;

    public int AvailableFood;

    public int AvailableHousing;

    public int AvailablePopulation;

    public int AvailableIndustry;

    public int AvailableIsolium;

    public static void DEV_AddResources()
    {
        Instance.AvailableHexes = 1000;
        Instance.AvailableFood = 1000;
        Instance.AvailableHousing = 1000;
        Instance.AvailablePopulation = 1000;
        Instance.AvailableIndustry = 1000;
        Instance.AvailableIsolium = 1000;
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
        switch(type)
        {
            case Enums.Building_Type.FOOD_I:
                return Constants.FarmCost;
            case Enums.Building_Type.HOUSING_I:
                return Constants.HovelCost;
            case Enums.Building_Type.INDUSTRY_I:
                return Constants.WorkshopCost;
            case Enums.Building_Type.MILITARY_I:
                return Constants.BarracksCost;
            case Enums.Building_Type.DEFENSE_I:
                return Constants.WatchTowerCost;
            case Enums.Building_Type.RESEARCH_I:
                return Constants.LabCost;
            case Enums.Building_Type.ISOLIUM_I:
                return Constants.WarehouseCost;
            default:
                Debug.LogError("Building Type Cost Switch Fallthrough :: " + type);
                return new BuildingCost(0, 0, 0, 0, 0);
        }
    }
}
