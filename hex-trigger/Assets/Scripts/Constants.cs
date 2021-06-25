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
    public static BuildingCost ExtractorMKICost = new BuildingCost(1, 1, 0, 0, 1, 0);
    public static BuildingCost ExtractorMKIICost = new BuildingCost(1, 2, 0, 0, 2, 1);
    public static BuildingCost ExtractorMKIIICost = new BuildingCost(1, 3, 0, 0, 3, 2);
    public static BuildingCost ExtractorMKIVCost = new BuildingCost(1, 4, 0, 0, 4, 3);
    #endregion
    #region Storage
    public static BuildingCost StockpileCost = new BuildingCost(1, 1, 0, 0, 1, 0);
    public static BuildingCost StorehouseCost = new BuildingCost(1, 2, 0, 1, 2, 0);
    public static BuildingCost WarehouseCost = new BuildingCost(1, 3, 0, 2, 3, 0);
    public static BuildingCost DepotCost = new BuildingCost(1, 0, 0, 3, 4, 0);
    #endregion
    #endregion

    #region Production Values
    #region Tier Bonuses
    public static float TIER_I_BONUS = 0.0f;
    public static float TIER_II_BONUS = 0.25f;
    public static float TIER_III_BONUS = 0.5f;
    public static float TIER_IV_BONUS = 1.0f;
    public static float TIER_V_BONUS = 2.0f;
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
    #region Storage Values
    public static int STORAGE_I_PROD = 10;
    public static int STORAGE_II_PROD = 15;
    public static int STORAGE_III_PROD = 25;
    public static int STORAGE_IV_PROD = 50;
    public static int STORAGE_V_PROD = 200;
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
    public static string GOD_SEAT_NAME = "God Seat";
    public static string GARDEN_NAME = "Garden";
    public static string FARM_NAME = "Farm";
    public static string ORCHARD_NAME = "Orchard";
    public static string RANCH_NAME = "Ranch";
    public static string HYDROPONICS_TOWER_NAME = "Hydroponics Tower";
    public static string HOVEL_NAME = "Hovel";
    public static string COTTAGE_NAME = "Cottage";
    public static string APARTMENT_NAME = "Apartment";
    public static string CONDO_NAME = "Condominium";
    public static string VILLA_NAME = "Villa";
    public static string WORKSHOP_NAME = "Workshop";
    public static string FORGE_NAME = "Forge";
    public static string MILL_NAME = "Mill";
    public static string FOUNDRY_NAME = "Foundry";
    public static string FACTORY_NAME = "Factory";
    public static string BARRACKS_NAME = "Barracks";
    public static string DORMITORY_NAME = "Dormitory";
    public static string GARRISON_NAME = "Garrison";
    public static string QUARTERS_NAME = "Quarters";
    public static string HEADQUARTERS_NAME = "Head Quarters";
    public static string WATCHTOWER_NAME = "Watch Tower";
    public static string MISSILE_COMPLEX_NAME = "Missile Complex";
    public static string LASER_TOWER_NAME = "Laser Tower";
    public static string AUTO_MISSILE_COMPLEX_NAME = "Auto Missile Complex";
    public static string AUTO_LASER_TOWER_NAME = "Auto Laser Tower";
    public static string RESEARCH_LAB_NAME = "Research Lab";
    public static string RESEARCH_COLLEGE_NAME = "Research College";
    public static string RESEARCH_INSTITUTE_NAME = "Research Institute";
    public static string MULTIBRAIN_COMPLEX_NAME = "Multi Brain Complex";
    public static string QUANTUM_BRAIN_NAME = "Quantum Brain";
    public static string EXTRACTOR_MK_I_NAME = "Extractor MK I";
    public static string EXTRACTOR_MK_II_NAME = "Extractor MK II";
    public static string EXTRACTOR_MK_III_NAME = "Extractor MK III";
    public static string EXTRACTOR_MK_IV_NAME = "Extractor MK IV";
    public static string EXTRACTOR_MK_V_NAME = "Extractor MK V";
    public static string STOCKPILE_NAME = "Stockpile";
    public static string STOREHOUSE_NAME = "Storehouse";
    public static string WAREHOUSE_NAME = "Warehouse";
    public static string DEPOT_NAME = "Depot";
    public static string DISTRIBUTION_CENTER_NAME = "Distribution Center";
    public static string SHOOTING_RANGE_NAME = "Shooting Range";
    public static string DEFENDERS_WALL_NAME = "Defender's Wall";
    public static string GUNNERS_ALLEY_NAME = "Gunner's Alley";
    public static string SNIPERS_NEST_NAME = "Sniper's Nest";
    public static string SCOUT_CAMP_NAME = "Scout Camp";
    public static string ACES_ARENA_NAME = "Ace's Arena";
    public static string CANNONEERS_TOWER_NAME = "Cannoneer's Tower";
    public static string GUARDIANS_LAST_STAND_NAME = "Guardian's Last Stand";
    #endregion

    #region Building Descs
    public static string GOD_SEAT_DESC = "Here resides the seat of power and the power core keeping the city together. Should it be lost, all will quickly follow so its protection must be prioritized above all else.";
    public static string GARDEN_DESC = "A simple community garden. It wont feed too many people and those it does feed will have to wait a while.";
    public static string FARM_DESC = "A large farm capable of feeding more people than a garden at the cost of necessary infastructure.";
    public static string ORCHARD_DESC = "An orchard full of different types of trees and produces as many different types of fruit. Variety is the spice of life and helps to avoid scurvy.";
    public static string RANCH_DESC = "A ranch for raising cute, tasty animals. It takes a while but nothing beats a nice steak, or bacon, or jerky, or …";
    public static string HYDROPONICS_TOWER_DESC = "A large tower capable of rapidly growing almost any type of food while only using a fraction of the space. A perfect marriage of advanced technology and ancient history.";
    public static string HOVEL_DESC = "A shack with four walls and a roof. It counts as a home, though the holes in the roof limit the comfort to almost nothing.";
    public static string COTTAGE_DESC = "A cozy log cabin that whistles slightly in the wind. Perfect for a mountain vacaction.";
    public static string APARTMENT_DESC = "An apartment complex allowing many people to live in close proximity at the cost of privacy and backyards.";
    public static string CONDO_DESC = "Similar to an apartment but now with better furniture and snobbier neighbors.";
    public static string VILLA_DESC = "A large ornate family home. Pretty to look at, even prettier to live in.";
    public static string WORKSHOP_DESC = "A simple workshop for creating simple things. Sounds of hammering and swearing can be heard from inside.";
    public static string FORGE_DESC = "A forge for making metal things out of metal by heating and shaping metal. ";
    public static string MILL_DESC = "Capable of producing lots of simple things by automating away the manual labor.";
    public static string FOUNDRY_DESC = "A bunch of forges collected together to melt large amounts of metal and make things out of it.";
    public static string FACTORY_DESC = "A fully automated combination of workshops, forges, mills, and foundries. Capable of making almost anything.";
    public static string BARRACKS_DESC = "A place for military members to live. Everyone gets a cot, a footlocker, and no privacy.";
    public static string DORMITORY_DESC = "A barracks where everyone gets their own room to share with two or three others.";
    public static string GARRISON_DESC = "A place for the military to wait when not defending places. Not very comfortable but has plenty of beds.";
    public static string QUARTERS_DESC = "Housing for officers and their families. Very nice even though they are carbon copies of each other.";
    public static string HEADQUARTERS_DESC = "A place for military leaders to give orders and watch the carnage from a safe distance.";
    public static string WATCHTOWER_DESC = "A simple watchtower that must be manned and can only provide protection for the immediate area.";
    public static string MISSILE_COMPLEX_DESC = "A missile launcher complex capable of dealing high damage to the surrounding area, though much time is needed to reload the launchers.";
    public static string LASER_TOWER_DESC = "A large tower capable of firing lasers made of highly consentrated isolium at long ranges for decent damage.";
    public static string AUTO_MISSILE_COMPLEX_DESC = "An upgraded version of the Missile Complex. Without the need for manual reloading, it is capable of firing noticably faster.";
    public static string AUTO_LASER_TOWER_DESC = "An upgrade version of the Laser Tower. Without the need for manual targeting, it is capable of firing at more targets noticably faster.";
    public static string RESEARCH_LAB_DESC = "A lab where intelligent citizens can test new ideas and build prototypes of new technologies.";
    public static string RESEARCH_COLLEGE_DESC = "A college for intelligent citizens to teach others and have them aid in research.";
    public static string RESEARCH_INSTITUTE_DESC = "An institute for intelligent citizens to persue new ideas and research without the distractions of the outside world.";
    public static string MULTIBRAIN_COMPLEX_DESC = "A borderline unethical creation made from an amalgamation of multiple brains capable of persuing research much more efficiently due to its lack of need for food or rest.";
    public static string QUANTUM_BRAIN_DESC = "The brain of a creature on the verge of transcending the material plain that was captured and coerced into researching new topics. ";
    public static string EXTRACTOR_MK_I_DESC = "A place for basic production of Isolium.Does not require much but in turn does not produce much Isolium.";
    public static string EXTRACTOR_MK_II_DESC = "A facility where Isolium is produced more efficiently than a MK I.";
    public static string EXTRACTOR_MK_III_DESC = "A large facility for producing Isolium.Due to its size, the MK III requires more upkeep than a MK II.";
    public static string EXTRACTOR_MK_IV_DESC = "A very large complex for producing Isolium.It is also capable of sending the Isolium out more efficently.";
    public static string EXTRACTOR_MK_V_DESC = "A large, fully automated structure for producing and storing Isolium.Due to its wildly complex structure, it does not lend itself to manual oversight.";
    public static string SHOOTING_RANGE_DESC = "A training area for shooters to learn and practice how to shoot fancily. Reduces training cost for shooters.";
    public static string DEFENDERS_WALL_DESC = "A training area for defenders to learn and practice how to defend like a solid wall. Reduces training cost for defenders.";
    public static string GUNNERS_ALLEY_DESC = "A training area for gunners to learn and practice how to suppress enemies with a hail of bullets. Reduces training cost for gunners.";
    public static string SNIPERS_NEST_DESC = "A training area for snipers to learn and practice how to attack enemies from vast distances. Reduces training cost for snipers.";
    public static string SCOUT_CAMP_DESC = "A training are for scouts to learn and practice how to notice and report on enemies without being seen. Reduces training cost for scouts.";
    public static string ACES_ARENA_DESC = "A monument to a long lost hero. The Ace has long been considered the greatest melee fighter to ever engage in combat. Increases the maximum number of Aces that can be trained.";
    public static string CANNONEERS_TOWER_DESC = "A monument to a long lost hero. The Cannoneer was considered too destructive to be a sniper but that destructive power proved impossible to defend against. Increases the maximum number of Cannoneers that can be trained.";
    public static string GUARDIANS_LAST_STAND_DESC = "A monument to a long lost hero. The Guardian sacrificed themselves to buy time for their comrades again and again, gaining truly impressive strength and constitution. Increases the maximum number of Guardians that can be trained.";
    public static string STOCKPILE_DESC = "A place where a small amount of items can be stored in a slightly organized pile.";
    public static string STOREHOUSE_DESC = "A small structure for storing items out of the elements in an organized manner.";
    public static string WAREHOUSE_DESC = "A large building for storing many items on tall shelves in a very organized manner.";
    public static string DEPOT_DESC = "A large fully automated building capable of storing many items using complex storage algorithms.";
    public static string DISTRIBUTION_CENTER_DESC = "An upgraded version of the depot capable of not only receiving items to store but also sending out items before the items were even requested.";
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
