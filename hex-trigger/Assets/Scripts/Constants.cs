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

    #region Buidling Costs
    #region Food
    public static BuildingCost FarmCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Housing
    public static BuildingCost HovelCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Industry
    public static BuildingCost WorkshopCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Isolium
    public static BuildingCost WarehouseCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Research
    public static BuildingCost LabCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Military
    public static BuildingCost BarracksCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #region Defense
    public static BuildingCost WatchTowerCost = new BuildingCost(1, 1, 1, 1, 1);
    #endregion
    #endregion

}

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

    public BuildingCost(int hexes, int food, int population, int industry, int isolium)
    {
        RequiredHexes = hexes;
        RequiredFood = food;
        RequiredPopulation = population;
        RequiredIndustry = industry;
        RequiredIsolium = isolium;
    }
}
