using System.Collections;
using System.Collections.Generic;


public static class Enums
{
    public enum Prefabs
    {
        HEX_GHOST,
        HEX_GOD_SEAT,
        HEX_GARDEN,
        HEX_FARM,
        HEX_ORCHARD,
        HEX_RANCH,
        HEX_HYDROPONICS_TOWER,
        HEX_HOVEL,
        HEX_COTTAGE,
        HEX_APARTMENT,
        HEX_CONDOMINIUM,
        HEX_VILLA,
        HEX_WORKSHOP,
        HEX_FORGE,
        HEX_MILL,
        HEX_FOUNDRY,
        HEX_FACTORY,
        HEX_BARRACKS,
        HEX_DORMITORY,
        HEX_GARRISON,
        HEX_QUARTERS,
        HEX_HEADQUARTERS,
        HEX_WATCHTOWER,
        HEX_MISSILE_COMPLEX,
        HEX_LASER_TOWER,
        HEX_AUTO_MISSILE_COMPLEX,
        HEX_AUTO_LASER_TOWER,
        HEX_RESEARCH_LAB,
        HEX_RESEARCH_COLLEGE,
        HEX_RESEARCH_INSTITUTE,
        HEX_MULTIBRAIN_COMPLEX,
        HEX_QUANTUM_BRAIN,
        HEX_EXTRACTOR_MK_I,
        HEX_EXTRACTOR_MK_II,
        HEX_EXTRACTOR_MK_III,
        HEX_EXTRACTOR_MK_IV,
        HEX_EXTRACTOR_MK_V,
        HEX_STOCKPILE,
        HEX_STOREHOUSE,
        HEX_WAREHOUSE,
        HEX_DEPOT,
        HEX_DISTRIBUTION_CENTER,
        HEX_SHOOTING_RANGE,
        HEX_DEFENDERS_WALL,
        HEX_GUNNERS_ALLEY,
        HEX_SNIPER_NEST,
        HEX_SCOUT_CAMP,
        HEX_ACES_ARENA,
        HEX_CANNONEERS_TOWER,
        HEX_GUARDIANS_LAST_STAND,
        HEX_WATERWHEEL,
        HEX_COAL_FIRED_POWER_PLANT,
        HEX_HYDROELECTRIC_DAM,
        HEX_NUCLEAR_POWER_PLANT,
        HEX_QUANTUM_POWER_PLANT,
        MODEL_GARDEN,
        MODEL_FARM,
        MODEL_ORCHARD,
        MODEL_RANCH,
        MODEL_HYDROPONICS_TOWER,
        MODEL_HOVEL,
        MODEL_COTTAGE,
        MODEL_APARTMENT,
        MODEL_CONDOMINIUM,
        MODEL_VILLA,
        MODEL_WORKSHOP,
        MODEL_FORGE,
        MODEL_MILL,
        MODEL_FOUNDRY,
        MODEL_FACTORY,
        MODEL_BARRACKS,
        MODEL_DORMITORY,
        MODEL_GARRISON,
        MODEL_QUARTERS,
        MODEL_HEADQUARTERS,
        MODEL_RESEARCH_LAB,
        MODEL_RESEARCH_COLLEGE,
        MODEL_RESEARCH_INSTITUTE,
        MODEL_MULTIBRAIN_COMPLEX,
        MODEL_QUANTUM_BRAIN,
        MODEL_EXTRACTOR_MK_I,
        MODEL_EXTRACTOR_MK_II,
        MODEL_EXTRACTOR_MK_III,
        MODEL_EXTRACTOR_MK_IV,
        MODEL_EXTRACTOR_MK_V,
        MODEL_STOCKPILE,
        MODEL_STOREHOUSE,
        MODEL_WAREHOUSE,
        MODEL_DEPOT,
        MODEL_DISTRIBUTION_CENTER
    }

    public enum Images
    {
        ICON_GOD_SEAT,
        ICON_FOOD,
        ICON_POP,
        ICON_INDUSTRY,
        ICON_MILITARY,
        ICON_RESEARCH,
        ICON_ISOLIUM,
        ICON_STORAGE,
        ICON_DEFENSE,
        ICON_POWER,
        ICON_GRUNT,
        ICON_SHOOTER,
        ICON_DEFENDER,
        ICON_GUNNER,
        ICON_SNIPER,
        ICON_SCOUT,
        ICON_ACE,
        ICON_CANNONEER,
        ICON_GUARDIAN
    }

    public enum Hex_Types
    {
        FOOD,
        HOUSING,
        INDUSTRY,
        MILITARY,
        RESEARCH,
        ISOLIUM,
        DEFENSE,
        STORAGE,
        GOD_SEAT,
        POWER
    }

    public enum Building_Tier
    {
        I,
        II,
        III,
        IV,
        V
    }

    public enum Building_Type
    {
        GOD_SEAT,
        GARDEN,
        FARM,
        ORCHARD,
        RANCH,
        HYDROPONICS_TOWER,
        HOVEL,
        COTTAGE,
        APARTMENT,
        CONDOMINIUM,
        VILLA,
        WORKSHOP,
        FORGE,
        MILL,
        FOUNDRY,
        FACTORY,
        BARRACKS,
        DORMITORY,
        GARRISON,
        QUARTERS,
        HEADQUARTERS,
        WATCHTOWER,
        MISSILE_COMPLEX,
        LASER_TOWER,
        AUTO_MISSILE_COMPLEX,
        AUTO_LASER_TOWER,
        RESEARCH_LAB,
        RESEARCH_COLLEGE,
        RESEARCH_INSTITUTE,
        MULTIBRAIN_COMPLEX,
        QUANTUM_BRAIN,
        EXTRACTOR_MK_I,
        EXTRACTOR_MK_II,
        EXTRACTOR_MK_III,
        EXTRACTOR_MK_IV,
        EXTRACTOR_MK_V,
        STOCKPILE,
        STOREHOUSE,
        WAREHOUSE,
        DEPOT,
        DISTRIBUTION_CENTER,
        SHOOTING_RANGE,
        DEFENDERS_WALL,
        GUNNERS_ALLEY,
        SNIPERS_NEST,
        SCOUT_CAMP,
        ACES_ARENA,
        CANNONEERS_TOWER,
        GUARDIANS_LAST_STAND,
        WATERWHEEL_GENERATOR,
        COAL_FIRED_POWER_PLANT,
        HYDROELECTRIC_DAM,
        NUCLEAR_POWER_PLANT,
        QUANTUM_POWER_PLANT
    }

    public enum Unit_Type
    {
        GRUNT,
        SHOOTER,
        DEFENDER,
        GUNNER,
        SNIPER,
        SCOUT,
        ACE,
        CANNONEER,
        GUARDIAN
    }

    public static Building_Type HexTypeAndTierToBuildingType(Hex_Types hex, Building_Tier tier)
    {
        return hex switch
        {
            Hex_Types.GOD_SEAT => Building_Type.GOD_SEAT,
            Hex_Types.FOOD => tier switch
            {
                Building_Tier.I => Building_Type.GARDEN,
                Building_Tier.II => Building_Type.FARM,
                Building_Tier.III => Building_Type.ORCHARD,
                Building_Tier.IV => Building_Type.RANCH,
                Building_Tier.V => Building_Type.HYDROPONICS_TOWER,
                _ => Building_Type.GARDEN,
            },
            Hex_Types.HOUSING => tier switch
            {
                Building_Tier.I => Building_Type.HOVEL,
                Building_Tier.II => Building_Type.COTTAGE,
                Building_Tier.III => Building_Type.APARTMENT,
                Building_Tier.IV => Building_Type.CONDOMINIUM,
                Building_Tier.V => Building_Type.VILLA,
                _ => Building_Type.HOVEL,
            },
            Hex_Types.INDUSTRY => tier switch
            {
                Building_Tier.I => Building_Type.WORKSHOP,
                Building_Tier.II => Building_Type.FORGE,
                Building_Tier.III => Building_Type.MILL,
                Building_Tier.IV => Building_Type.FOUNDRY,
                Building_Tier.V => Building_Type.FACTORY,
                _ => Building_Type.WORKSHOP,
            },
            Hex_Types.MILITARY => tier switch
            {
                Building_Tier.I => Building_Type.BARRACKS,
                Building_Tier.II => Building_Type.DORMITORY,
                Building_Tier.III => Building_Type.GARRISON,
                Building_Tier.IV => Building_Type.QUARTERS,
                Building_Tier.V => Building_Type.HEADQUARTERS,
                _ => Building_Type.BARRACKS,
            },
            Hex_Types.DEFENSE => tier switch
            {
                Building_Tier.I => Building_Type.WATCHTOWER,
                Building_Tier.II => Building_Type.MISSILE_COMPLEX,
                Building_Tier.III => Building_Type.LASER_TOWER,
                Building_Tier.IV => Building_Type.AUTO_MISSILE_COMPLEX,
                Building_Tier.V => Building_Type.AUTO_LASER_TOWER,
                _ => Building_Type.WATCHTOWER,
            },
            Hex_Types.RESEARCH => tier switch
            {
                Building_Tier.I => Building_Type.RESEARCH_LAB,
                Building_Tier.II => Building_Type.RESEARCH_COLLEGE,
                Building_Tier.III => Building_Type.RESEARCH_INSTITUTE,
                Building_Tier.IV => Building_Type.MULTIBRAIN_COMPLEX,
                Building_Tier.V => Building_Type.QUANTUM_BRAIN,
                _ => Building_Type.RESEARCH_LAB,
            },
            Hex_Types.ISOLIUM => tier switch
            {
                Building_Tier.I => Building_Type.EXTRACTOR_MK_I,
                Building_Tier.II => Building_Type.EXTRACTOR_MK_II,
                Building_Tier.III => Building_Type.EXTRACTOR_MK_III,
                Building_Tier.IV => Building_Type.EXTRACTOR_MK_IV,
                Building_Tier.V => Building_Type.EXTRACTOR_MK_V,
                _ => Building_Type.EXTRACTOR_MK_I,
            },
            Hex_Types.STORAGE => tier switch
            {
                Building_Tier.I => Building_Type.STOCKPILE,
                Building_Tier.II => Building_Type.STOREHOUSE,
                Building_Tier.III => Building_Type.WAREHOUSE,
                Building_Tier.IV => Building_Type.DEPOT,
                Building_Tier.V => Building_Type.DISTRIBUTION_CENTER,
                _ => Building_Type.STOCKPILE,
            },
            Hex_Types.POWER => tier switch
            {
                Building_Tier.I => Building_Type.WATERWHEEL_GENERATOR,
                Building_Tier.II => Building_Type.COAL_FIRED_POWER_PLANT,
                Building_Tier.III => Building_Type.HYDROELECTRIC_DAM,
                Building_Tier.IV => Building_Type.NUCLEAR_POWER_PLANT,
                Building_Tier.V => Building_Type.QUANTUM_POWER_PLANT,
                _ => Building_Type.WATERWHEEL_GENERATOR,
            },
            _ => Building_Type.HOVEL,
        };
    }

    public static Prefabs BuildingTypeToHexPrefab(Building_Type type)
    {
        switch (type)
        {
            case Building_Type.GOD_SEAT:
                return Prefabs.HEX_GOD_SEAT;
            case Building_Type.GARDEN:
                return Prefabs.HEX_GARDEN;
            case Building_Type.FARM:
                return Prefabs.HEX_FARM;
            case Building_Type.ORCHARD:
                return Prefabs.HEX_ORCHARD;
            case Building_Type.RANCH:
                return Prefabs.HEX_RANCH;
            case Building_Type.HYDROPONICS_TOWER:
                return Prefabs.HEX_HYDROPONICS_TOWER;
            case Building_Type.HOVEL:
                return Prefabs.HEX_HOVEL;
            case Building_Type.COTTAGE:
                return Prefabs.HEX_COTTAGE;
            case Building_Type.APARTMENT:
                return Prefabs.HEX_APARTMENT;
            case Building_Type.CONDOMINIUM:
                return Prefabs.HEX_CONDOMINIUM;
            case Building_Type.VILLA:
                return Prefabs.HEX_VILLA;
            case Building_Type.WORKSHOP:
                return Prefabs.HEX_WORKSHOP;
            case Building_Type.FORGE:
                return Prefabs.HEX_FORGE;
            case Building_Type.MILL:
                return Prefabs.HEX_MILL;
            case Building_Type.FOUNDRY:
                return Prefabs.HEX_FOUNDRY;
            case Building_Type.FACTORY:
                return Prefabs.HEX_FACTORY;
            case Building_Type.BARRACKS:
                return Prefabs.HEX_BARRACKS;
            case Building_Type.DORMITORY:
                return Prefabs.HEX_DORMITORY;
            case Building_Type.GARRISON:
                return Prefabs.HEX_GARRISON;
            case Building_Type.QUARTERS:
                return Prefabs.HEX_QUARTERS;
            case Building_Type.HEADQUARTERS:
                return Prefabs.HEX_HEADQUARTERS;
            case Building_Type.WATCHTOWER:
                return Prefabs.HEX_WATCHTOWER;
            case Building_Type.MISSILE_COMPLEX:
                return Prefabs.HEX_MISSILE_COMPLEX;
            case Building_Type.LASER_TOWER:
                return Prefabs.HEX_LASER_TOWER;
            case Building_Type.AUTO_MISSILE_COMPLEX:
                return Prefabs.HEX_AUTO_MISSILE_COMPLEX;
            case Building_Type.AUTO_LASER_TOWER:
                return Prefabs.HEX_AUTO_LASER_TOWER;
            case Building_Type.RESEARCH_LAB:
                return Prefabs.HEX_RESEARCH_LAB;
            case Building_Type.RESEARCH_COLLEGE:
                return Prefabs.HEX_RESEARCH_COLLEGE;
            case Building_Type.RESEARCH_INSTITUTE:
                return Prefabs.HEX_RESEARCH_INSTITUTE;
            case Building_Type.MULTIBRAIN_COMPLEX:
                return Prefabs.HEX_MULTIBRAIN_COMPLEX;
            case Building_Type.QUANTUM_BRAIN:
                return Prefabs.HEX_QUANTUM_BRAIN;
            case Building_Type.EXTRACTOR_MK_I:
                return Prefabs.HEX_STOCKPILE;
            case Building_Type.EXTRACTOR_MK_II:
                return Prefabs.HEX_STOREHOUSE;
            case Building_Type.EXTRACTOR_MK_III:
                return Prefabs.HEX_WAREHOUSE;
            case Building_Type.EXTRACTOR_MK_IV:
                return Prefabs.HEX_DEPOT;
            case Building_Type.EXTRACTOR_MK_V:
                return Prefabs.HEX_DISTRIBUTION_CENTER;
            case Building_Type.SHOOTING_RANGE:
                return Prefabs.HEX_SHOOTING_RANGE;
            case Building_Type.DEFENDERS_WALL:
                return Prefabs.HEX_DEFENDERS_WALL;
            case Building_Type.GUNNERS_ALLEY:
                return Prefabs.HEX_GUNNERS_ALLEY;
            case Building_Type.SNIPERS_NEST:
                return Prefabs.HEX_SNIPER_NEST;
            case Building_Type.SCOUT_CAMP:
                return Prefabs.HEX_SCOUT_CAMP;
            case Building_Type.ACES_ARENA:
                return Prefabs.HEX_ACES_ARENA;
            case Building_Type.CANNONEERS_TOWER:
                return Prefabs.HEX_CANNONEERS_TOWER;
            case Building_Type.GUARDIANS_LAST_STAND:
                return Prefabs.HEX_GUARDIANS_LAST_STAND;
            case Building_Type.STOCKPILE:
                return Prefabs.HEX_STOCKPILE;
            case Building_Type.STOREHOUSE:
                return Prefabs.HEX_STOREHOUSE;
            case Building_Type.WAREHOUSE:
                return Prefabs.HEX_WAREHOUSE;
            case Building_Type.DEPOT:
                return Prefabs.HEX_DEPOT;
            case Building_Type.DISTRIBUTION_CENTER:
                return Prefabs.HEX_DISTRIBUTION_CENTER;
            case Building_Type.WATERWHEEL_GENERATOR:
                return Prefabs.HEX_WATERWHEEL;
            case Building_Type.COAL_FIRED_POWER_PLANT:
                return Prefabs.HEX_COAL_FIRED_POWER_PLANT;
            case Building_Type.HYDROELECTRIC_DAM:
                return Prefabs.HEX_HYDROELECTRIC_DAM;
            case Building_Type.NUCLEAR_POWER_PLANT:
                return Prefabs.HEX_NUCLEAR_POWER_PLANT;
            case Building_Type.QUANTUM_POWER_PLANT:
                return Prefabs.HEX_QUANTUM_POWER_PLANT;
            default:
                return Prefabs.HEX_HOVEL;
        }

    }

    public static Prefabs BuildingTypeToModelPrefab(Building_Type type)
    {
        switch (type)
        {
            case Building_Type.GARDEN:
                return Prefabs.MODEL_GARDEN;
            case Building_Type.FARM:
                return Prefabs.MODEL_FARM;
            case Building_Type.ORCHARD:
                return Prefabs.MODEL_ORCHARD;
            case Building_Type.RANCH:
                return Prefabs.MODEL_RANCH;
            case Building_Type.HYDROPONICS_TOWER:
                return Prefabs.MODEL_HYDROPONICS_TOWER;
            case Building_Type.HOVEL:
                return Prefabs.MODEL_HOVEL;
            case Building_Type.COTTAGE:
                return Prefabs.MODEL_COTTAGE;
            case Building_Type.APARTMENT:
                return Prefabs.MODEL_APARTMENT;
            case Building_Type.CONDOMINIUM:
                return Prefabs.MODEL_CONDOMINIUM;
            case Building_Type.VILLA:
                return Prefabs.MODEL_VILLA;
            case Building_Type.WORKSHOP:
                return Prefabs.MODEL_WORKSHOP;
            case Building_Type.FORGE:
                return Prefabs.MODEL_FORGE;
            case Building_Type.MILL:
                return Prefabs.MODEL_MILL;
            case Building_Type.FOUNDRY:
                return Prefabs.MODEL_FOUNDRY;
            case Building_Type.FACTORY:
                return Prefabs.MODEL_FACTORY;
            case Building_Type.BARRACKS:
                return Prefabs.MODEL_BARRACKS;
            case Building_Type.DORMITORY:
                return Prefabs.MODEL_DORMITORY;
            case Building_Type.GARRISON:
                return Prefabs.MODEL_GARRISON;
            case Building_Type.QUARTERS:
                return Prefabs.MODEL_QUARTERS;
            case Building_Type.HEADQUARTERS:
                return Prefabs.MODEL_HEADQUARTERS;
            case Building_Type.RESEARCH_LAB:
                return Prefabs.MODEL_RESEARCH_LAB;
            case Building_Type.RESEARCH_COLLEGE:
                return Prefabs.MODEL_RESEARCH_COLLEGE;
            case Building_Type.RESEARCH_INSTITUTE:
                return Prefabs.MODEL_RESEARCH_INSTITUTE;
            case Building_Type.MULTIBRAIN_COMPLEX:
                return Prefabs.MODEL_MULTIBRAIN_COMPLEX;
            case Building_Type.QUANTUM_BRAIN:
                return Prefabs.MODEL_QUANTUM_BRAIN;
            case Building_Type.EXTRACTOR_MK_I:
                return Prefabs.MODEL_EXTRACTOR_MK_I;
            case Building_Type.EXTRACTOR_MK_II:
                return Prefabs.MODEL_EXTRACTOR_MK_II;
            case Building_Type.EXTRACTOR_MK_III:
                return Prefabs.MODEL_EXTRACTOR_MK_III;
            case Building_Type.EXTRACTOR_MK_IV:
                return Prefabs.MODEL_EXTRACTOR_MK_IV;
            case Building_Type.EXTRACTOR_MK_V:
                return Prefabs.MODEL_EXTRACTOR_MK_V;
            case Building_Type.STOCKPILE:
                return Prefabs.MODEL_STOCKPILE;
            case Building_Type.STOREHOUSE:
                return Prefabs.MODEL_STOREHOUSE;
            case Building_Type.WAREHOUSE:
                return Prefabs.MODEL_WAREHOUSE;
            case Building_Type.DEPOT:
                return Prefabs.MODEL_DEPOT;
            case Building_Type.DISTRIBUTION_CENTER:
                return Prefabs.MODEL_DISTRIBUTION_CENTER;
            case Building_Type.WATCHTOWER:
            case Building_Type.MISSILE_COMPLEX:
            case Building_Type.LASER_TOWER:
            case Building_Type.AUTO_MISSILE_COMPLEX:
            case Building_Type.AUTO_LASER_TOWER:
            case Building_Type.WATERWHEEL_GENERATOR:
            case Building_Type.COAL_FIRED_POWER_PLANT:
            case Building_Type.HYDROELECTRIC_DAM:
            case Building_Type.NUCLEAR_POWER_PLANT:
            case Building_Type.QUANTUM_POWER_PLANT:
            case Building_Type.SHOOTING_RANGE:
            case Building_Type.DEFENDERS_WALL:
            case Building_Type.GUNNERS_ALLEY:
            case Building_Type.SNIPERS_NEST:
            case Building_Type.SCOUT_CAMP:
            case Building_Type.ACES_ARENA:
            case Building_Type.CANNONEERS_TOWER:
            case Building_Type.GUARDIANS_LAST_STAND:
            case Building_Type.GOD_SEAT:
            default:
                return Prefabs.MODEL_GARDEN;
        }
    }
}
