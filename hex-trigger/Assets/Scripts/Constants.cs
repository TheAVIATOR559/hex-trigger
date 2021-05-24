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

    public static BuildingCost ShootingRangeCost =      new BuildingCost(1, 0, 3, 3, 3, 3);
    public static BuildingCost DefendersWallCost =      new BuildingCost(1, 0, 4, 4, 4, 4);
    public static BuildingCost GunnersAlleyCost =       new BuildingCost(1, 0, 4, 4, 4, 4);
    public static BuildingCost SnipersNestCost =        new BuildingCost(1, 0, 5, 5, 5, 5);
    public static BuildingCost ScoutCampCost =          new BuildingCost(1, 0, 5, 5, 5, 5);
    public static BuildingCost AcesArenaCost =          new BuildingCost(1, 0, 6, 6, 6, 6);
    public static BuildingCost CannoneersTowerCost =    new BuildingCost(1, 0, 6, 6, 6, 6);
    public static BuildingCost GuardiansLastStandCost = new BuildingCost(1, 0, 6, 6, 6, 6);
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
    #region Defense Tower Values
    #region Watch Tower Values
    public static int WATCH_TOWER_DEFENSE_RADIUS = 1;
    public static int WATCH_TOWER_DAMAGE = 1;
    public static int WATCH_TOWER_RELOAD_TIME = 3;
    #endregion
    #region Missile Complex Values
    public static int MISSILE_COMPLEX_DEFENSE_RADIUS = 3;
    public static int MISSILE_COMPLEX_DAMAGE = 5;
    public static int MISSILE_COMPLEX_RELOAD_TIME = 5;
    #endregion
    #region Laser Tower Values
    public static int LASER_TOWER_DEFENSE_RADIUS = 5;
    public static int LASER_TOWER_DAMAGE = 3;
    public static int LASER_TOWER_RELOAD_TIME = 3;
    #endregion
    #region Auto Missile Complex Values
    public static int AUTO_MISSILE_COMPLEX_DEFENSE_RADIUS = 3;
    public static int AUTO_MISSILE_COMPLEX_DAMAGE = 5;
    public static int AUTO_MISSILE_COMPLEX_RELOAD_TIME = 3;
    #endregion
    #region Auto Laser Tower Values
    public static int AUTO_LASER_TOWER_DEFENSE_RADIUS = 5;
    public static int AUTO_LASER_TOWER_DAMAGE = 3;
    public static int AUTO_LASER_TOWER_RELOAD_TIME = 1;
    #endregion
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
    public static float TRAINING_COST_REDUCTION_PER_HEX = 0.05f;
    #region Unit Training Costs
    public static UnitTrainingCost GRUNT_TRAINING_COST = new UnitTrainingCost(1, 1, 1, 1);
    public static UnitTrainingCost SHOOTER_TRAINING_COST = new UnitTrainingCost(1, 1, 2, 2);
    public static UnitTrainingCost DEFENDER_TRAINING_COST = new UnitTrainingCost(1, 2, 3, 3);
    public static UnitTrainingCost GUNNER_TRAINING_COST = new UnitTrainingCost(1, 2, 3, 3);
    public static UnitTrainingCost SNIPER_TRAINING_COST = new UnitTrainingCost(1, 3, 4, 4);
    public static UnitTrainingCost SCOUT_TRAINING_COST = new UnitTrainingCost(1, 3, 4, 4);
    public static UnitTrainingCost ACE_TRAINING_COST = new UnitTrainingCost(1, 10, 10, 10, 1);
    public static UnitTrainingCost CANNONEER_TRAINING_COST = new UnitTrainingCost(1, 10, 10, 10, 2);
    public static UnitTrainingCost GUARDIAN_TRAINING_COST = new UnitTrainingCost(1, 10, 10, 10, 3);
    #endregion
    #region Grunt Values
    public static int GRUNT_ATTACK = 1;
    public static int GRUNT_DEFENSE = 1;
    public static int GRUNT_SPEED = 1;
    public static int GRUNT_RANGE = 1;
    #endregion
    #region Shooter Values
    public static int SHOOTER_ATTACK = 1;
    public static int SHOOTER_DEFENSE = 1;
    public static int SHOOTER_SPEED = 1;
    public static int SHOOTER_RANGE = 1;
    #endregion
    #region Defender Values
    public static int DEFENEDER_ATTACK = 1;
    public static int DEFENDER_DEFENSE = 1;
    public static int DEFENDER_SPEED = 1;
    public static int DEFENDER_RANGE = 1;
    #endregion
    #region Gunner Values
    public static int GUNNER_ATTACK = 1;
    public static int GUNNER_DEFENSE = 1;
    public static int GUNNER_SPEED = 1;
    public static int GUNNER_RANGE = 1;
    #endregion
    #region Sniper Values
    public static int SNIPER_ATTACK = 1;
    public static int SNIPER_DEFENSE = 1;
    public static int SNIPER_SPEED = 1;
    public static int SNIPER_RANGE = 1;
    #endregion
    #region Scout Values
    public static int SCOUT_ATTACK = 1;
    public static int SCOUT_DEFENSE = 1;
    public static int SCOUT_SPEED = 1;
    public static int SCOUT_RANGE = 1;
    #endregion
    #region Ace Values
    public static int ACES_PER_HEX = 1;
    public static int ACE_ATTACK = 1;
    public static int ACE_DEFENSE = 1;
    public static int ACE_SPEED = 1;
    public static int ACE_RANGE = 1;
    #endregion
    #region Cannoneer Values
    public static int CANNONEERS_PER_HEX = 1;
    public static int CANNONEER_ATTACK = 1;
    public static int CANNONEER_DEFENSE = 1;
    public static int CANNONEER_SPEED = 1;
    public static int CANNONEER_RANGE = 1;
    #endregion
    #region Guardian Values
    public static int GUARDIANS_PER_HEX = 1;
    public static int GUARDIAN_ATTACK = 1;
    public static int GUARDIAN_DEFENSE = 1;
    public static int GUARDIAN_SPEED = 1;
    public static int GUARDIAN_RANGE = 1;
    #endregion
    #endregion

    #region Building Names
    public static string GARDEN_NAME = "Garden";
    public static string FARM_NAME = "Farm";
    public static string ORCHARD_NAME = "Orchard";
    public static string RANCH_NAME = "Ranch";
    public static string HOVEL_NAME = "Hovel";
    public static string COTTAGE_NAME = "Cottage";
    public static string APARTMENT_NAME = "Apartment";
    public static string CONDO_NAME = "Condominium";
    public static string WORKSHOP_NAME = "Workshop";
    public static string FORGE_NAME = "Forge";
    public static string MILL_NAME = "Mill";
    public static string FOUNDRY_NAME = "Foundry";
    public static string BARRACKS_NAME = "Barracks";
    public static string DORMITORY_NAME = "Dormitory";
    public static string GARRISON_NAME = "Garrison";
    public static string QUARTERS_NAME = "Quarters";
    public static string WATCHTOWER_NAME = "Watch Tower";
    public static string MISSILE_COMPLEX_NAME = "Missile Complex";
    public static string LASER_TOWER_NAME = "Laser Tower";
    public static string AUTO_MISSILE_COMPLEX_NAME = "Auto Missile Complex";
    public static string AUTO_LASER_TOWER_NAME = "Auto Laser Tower";
    public static string RESEARCH_LAB_NAME = "Research Lab";
    public static string RESEARCH_COLLEGE_NAME = "Research College";
    public static string RESEARCH_INSTITUTE_NAME = "Research Institute";
    public static string MULTIBRAIN_COMPLEX_NAME = "Multi Brain Complex";
    public static string STOCKPILE_NAME = "Stockpile";
    public static string STOREHOUSE_NAME = "Storehouse";
    public static string WAREHOUSE_NAME = "Warehouse";
    public static string DEPOT_NAME = "Depot";
    public static string SHOOTING_RANGE_NAME = "Shooting Range";
    public static string DEFENDERS_WALL_NAME = "Defender's Wall";
    public static string GUNNERS_ALLEY_NAME = "Gunner's Alley";
    public static string SNIPERS_NEST_NAME = "Sniper's Nest";
    public static string SCOUT_CAMP_NAME = "Scout Camp";
    public static string ACES_ARENA_NAME = "Ace's Arena";
    public static string CANNONEERS_TOWER_NAME = "Cannoneer's Tower";
    public static string GUARDIANS_LAST_STAND_NAME = "Guardian's Last Stand";
    #endregion

    #region Unit Names
    public static string GRUNT_NAME = "Grunt";
    public static string SHOOTER_NAME = "Shooter";
    public static string DEFENDER_NAME = "Defender";
    public static string GUNNER_NAME = "Gunner";
    public static string SNIPER_NAME = "Sniper";
    public static string SCOUT_NAME = "Scout";
    public static string ACE_NAME = "Ace";
    public static string CANNONEER_NAME = "Cannoneer";
    public static string GUARDIAN_NAME = "Guardian";
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

//new UnitTrainingCost(MIL, FOOD, IND, ISO, SpecialCount)
//special count :: 0 = not, 1 = ace, 2 = cannoneer, 3 = guardian
public struct UnitTrainingCost
{
    public int RequiredMilitary
    {
        get;
    }

    public int RequiredFood
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

    public int SpecialUnitType
    {
        get;
    }

    public UnitTrainingCost(int military, int food, int industry, int isolium, int specialType = 0)
    {
        RequiredMilitary = military;
        RequiredFood = food;
        RequiredIndustry = industry;
        RequiredIsolium = isolium;
        SpecialUnitType = specialType;
    }
}
