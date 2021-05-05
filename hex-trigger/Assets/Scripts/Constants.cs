using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static Vector2Int[] EVEN_ROW_OFFSETS = new Vector2Int[6]
    {
        new Vector2Int(-1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(+1, 0),
        new Vector2Int(0, +1),
        new Vector2Int(-1, +1),
        new Vector2Int(-1, 0)
    };

    public static Vector2Int[] ODD_ROW_OFFSETS = new Vector2Int[6]
    {
        new Vector2Int(0, -1),
        new Vector2Int(+1, -1),
        new Vector2Int(+1, 0),
        new Vector2Int(+1, +1),
        new Vector2Int(0, +1),
        new Vector2Int(-1, 0)
    };

    public static float HEX_X_OFFSET = 0.866f;
    public static float HEX_Y_OFFSET = 0.75f;

    public static float TICK_SPEED = 1f;

    #region Buidling Costs
    #region Food
    public static BuildingCost GardenCost =  new BuildingCost(1, 1, 0, 0, 0, 0);
    public static BuildingCost FarmCost =    new BuildingCost(1, 2, 0, 1, 2, 0);
    public static BuildingCost OrchardCost = new BuildingCost(1, 3, 0, 2, 3, 0);
    public static BuildingCost RanchCost =   new BuildingCost(1, 4, 0, 3, 4, 0);
    #endregion
    #region Housing
    public static BuildingCost HovelCost =     new BuildingCost(1, 0, 1, 0, 0, 0);
    public static BuildingCost CottageCost =   new BuildingCost(1, 0, 2, 1, 1, 0);
    public static BuildingCost ApartmentCost = new BuildingCost(1, 0, 3, 2, 2, 0);
    public static BuildingCost CondoCost =     new BuildingCost(1, 0, 4, 3, 3, 0);
    #endregion
    #region Industry
    public static BuildingCost WorkshopCost = new BuildingCost(1, 1, 0, 0, 0, 0);
    public static BuildingCost ForgeCost =    new BuildingCost(1, 2, 0, 1, 0, 0);
    public static BuildingCost MillCost =     new BuildingCost(1, 3, 0, 2, 0, 0);
    public static BuildingCost FoundryCost =  new BuildingCost(1, 4, 0, 3, 0, 0);
    #endregion
    #region Military
    public static BuildingCost BarracksCost =  new BuildingCost(1, 2, 1, 1, 1, 0);
    public static BuildingCost DormitoryCost = new BuildingCost(1, 3, 2, 2, 2, 0);
    public static BuildingCost GarrisonCost =  new BuildingCost(1, 4, 3, 3, 3, 0);
    public static BuildingCost QuartersCost =  new BuildingCost(1, 5, 4, 4, 4, 0);
    #endregion
    #region Defense
    public static BuildingCost WatchTowerCost = new BuildingCost(1, 1, 0, 1, 1, 1);
    public static BuildingCost MissileComplexCost = new BuildingCost(1, 2, 0, 2, 2, 2);
    public static BuildingCost LaserTowerCost = new BuildingCost(1, 3, 0, 3, 3, 3);
    public static BuildingCost AutoMissileComplexCost = new BuildingCost(1, 0, 0, 4, 4, 4);
    public static BuildingCost AutoLaserTowerCost = new BuildingCost(1, 0, 0, 6, 6, 6);
    #endregion
    #region Research
    public static BuildingCost ResearchLabCost = new BuildingCost(1, 2, 0, 2, 2, 0);
    public static BuildingCost ResearchCollegeCost = new BuildingCost(1, 3, 0, 3, 3, 0);
    public static BuildingCost ResearchInstituteCost = new BuildingCost(1, 4, 0, 4, 4, 0);
    public static BuildingCost MultiBrainCost = new BuildingCost(1, 5, 0, 5, 5, 0);
    #endregion
    #region Isolium
    public static BuildingCost StockpileCost = new BuildingCost(1, 1, 0, 0, 1, 0);
    public static BuildingCost StorehouseCost = new BuildingCost(1, 2, 0, 0, 2, 1);
    public static BuildingCost WarehouseCost = new BuildingCost(1, 3, 0, 0, 3, 2);
    public static BuildingCost DepotCost = new BuildingCost(1, 4, 0, 0, 4, 3);
    #endregion
    #endregion

    #region Production Values
    #region Tier Bonuses
    public static float TIER_I_BONUS = 1.0f;
    public static float TIER_II_BONUS = 1.25f;
    public static float TIER_III_BONUS = 1.5f;
    public static float TIER_IV_BONUS = 2.0f;
    public static float TIER_V_BONUS = 3.0f;
    #endregion
    #region Food Production
    public static int FOOD_I_PROD = 1;
    public static int FOOD_II_PROD = 2;
    public static int FOOD_III_PROD = 3;
    public static int FOOD_IV_PROD = 4;
    public static int FOOD_V_PROD = 5;
    #endregion
    //these values will need to be rebalanced
    #region Housing Production
    public static int POP_GROWTH_RATE = 2;
    public static int HOUSING_I_PROD = 1;
    public static int HOUSING_II_PROD = 2;
    public static int HOUSING_III_PROD = 3;
    public static int HOUSING_IV_PROD = 4;
    public static int HOUSING_V_PROD = 5;
    #endregion
    #region Industry Production
    public static int INDUSTRY_I_PROD = 1;
    public static int INDUSTRY_II_PROD = 2;
    public static int INDUSTRY_III_PROD = 3;
    public static int INDUSTRY_IV_PROD = 4;
    public static int INDUSTRY_V_PROD = 5;
    #endregion
    //these values will need to be rebalanced
    #region Military Production
    public static int MILITARY_I_PROD = 1;
    public static int MILITARY_II_PROD = 2;
    public static int MILITARY_III_PROD = 3;
    public static int MILITARY_IV_PROD = 4;
    public static int MILITARY_V_PROD = 5;
    #endregion
    //these values will need to be rebalanced
    #region Research Production
    public static int RESEARCH_I_PROD = 1;
    public static int RESEARCH_II_PROD = 2;
    public static int RESEARCH_III_PROD = 3;
    public static int RESEARCH_IV_PROD = 4;
    public static int RESEARCH_V_PROD = 5;
    #endregion
    #region Isolium Production
    public static int ISOLIUM_I_PROD = 1;
    public static int ISOLIUM_II_PROD = 2;
    public static int ISOLIUM_III_PROD = 3;
    public static int ISOLIUM_IV_PROD = 4;
    public static int ISOLIUM_V_PROD = 5;
    #endregion
    #endregion

    #region Combat Unit Values
    public static float MAXIMUM_TRAINING_COST_REDUCTION = 0.25f;
    #endregion

}
//new BuildingCost(HEX, POP, FOOD, ISO, IND, MIL)
public struct BuildingCost
{
    public int RequiredHexes
    {
        get;
    }

    public int RequiredFood
    {
        get;
    }

    public int RequiredPopulation
    {
        get;
    }

    public int RequiredIndustry
    {
        get;
    }

    public int RequiredIsolium
    {
        get;
    }

    public int RequiredMilitary
    {
        get;
    }

    public BuildingCost(int hexes, int population, int food, int isolium, int industry, int military)
    {
        RequiredHexes = hexes;
        RequiredFood = food;
        RequiredPopulation = population;
        RequiredIndustry = industry;
        RequiredIsolium = isolium;
        RequiredMilitary = military;
    }
}
