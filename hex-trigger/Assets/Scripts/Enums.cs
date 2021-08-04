using System.Collections;
using System.Collections.Generic;


public static class Enums
{
    public enum Hex_Prefabs
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
        HEX_PUBLIC_PARK,
        HEX_CIRCUS,
        HEX_THEATER_COMPLEX,
        HEX_VIRTUAL_REALITY_CAFE,
        HEX_QUANTUM_HOLOGRAM_THEATER,
        HEX_VOID_PORTAL,//TODO IMPLEMENT ME
        HEX_VOID_COMMUNICATOR,//TODO IMPLEMENT ME
        HEX_VOID_RADAR_ARRAY,//TODO IMPLEMENT ME
        HEX_FACTION_EMBASSY,//TODO IMPLEMENT ME
        HEX_ABYSSAL_PATHFINDER,//TODO IMPLEMENT ME
        HEX_VOID_RUDDER,//TODO IMPLEMENT ME
        HEX_WEATHER_MANIPULATOR,//TODO IMPLEMENT ME
        HEX_DIPLO_MONUMENT,//TODO IMPLEMENT ME
        HEX_SCI_MONUMENT,//TODO IMPLEMENT ME
        HEX_HAPP_MONUMENT,//TODO IMPLEMENT ME
        HEX_IND_MONUMENT,//TODO IMPLEMENT ME
        HEX_ISO_MONUMENT,//TODO IMPLEMENT ME
        HEX_MIL_MONUMENT,//TODO IMPLEMENT ME
        HEX_FOOD_MONUMENT//TODO IMPLEMENT ME
    }

    public enum Model_Prefabs
    {
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
        MODEL_DISTRIBUTION_CENTER,
        MODEL_PUBLIC_PARK,
        MODEL_CIRCUS,
        MODEL_THEATER_COMPLEX,
        MODEL_VIRTUAL_REALITY_CAFE,
        MODEL_QUANTUM_HOLOGRAM_THEATER,
        MODEL_DIPLO_MONUMENT,//TODO IMPLEMENT ME THIS MAY BE MORE COMPLICATED THAN I WANT
        MODEL_SCI_MONUMENT,//TODO IMPLEMENT ME
        MODEL_HAPP_MONUMENT,//TODO IMPLEMENT ME
        MODEL_IND_MONUMENT,//TODO IMPLEMENT ME
        MODEL_ISO_MONUMENT,//TODO IMPLEMENT ME
        MODEL_MIL_MONUMENT,//TODO IMPLEMENT ME
        MODEL_FOOD_MONUMENT//TODO IMPLEMENT ME
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
        ICON_GUARDIAN,
        ICON_ENTERTAINMENT,
        ICON_MONUMENT,//TODO IMPLEMENT ME
        ICON_SPECIAL//TODO IMPLEMENT ME
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
        POWER,
        ENTERTAINMENT,
        SPECIAL,//TODO IMPLEMENT ME
        MONUMENT//TODO IMPLEMENT ME
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
        QUANTUM_POWER_PLANT,
        PUBLIC_PARK,
        CIRCUS,
        THEATER_COMPLEX,
        VIRTUAL_REALITY_CAFE,
        QUANTUM_HOLOGRAM_THEATER,
        VOID_PORTAL,//TODO IMPLEMENT ME
        VOID_COMMUNICATOR,//TODO IMPLEMENT ME
        VOID_RADAR_ARRAY,//TODO IMPLEMENT ME
        FACTION_EMBASSY,//TODO IMPLEMENT ME
        ABYSSAL_PATHFINDER,//TODO IMPLEMENT ME
        VOID_RUDDER,//TODO IMPLEMENT ME
        WEATHER_MANIPULATOR,//TODO IMPLEMENT ME
        DIPLO_MONUMENT,//TODO IMPLEMENT ME
        SCI_MONUMENT,//TODO IMPLEMENT ME
        HAPP_MONUMENT,//TODO IMPLEMENT ME
        IND_MONUMENT,//TODO IMPLEMENT ME
        ISO_MONUMENT,//TODO IMPLEMENT ME
        MIL_MONUMENT,//TODO IMPLEMENT ME
        FOOD_MONUMENT//TODO IMPLEMENT ME
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

    public static Building_Type HexTypeAndTierToBuildingType(Hex_Types hex, Building_Tier tier)//todo MAY NEED AN OVERRIDE FOR MONUMENTS AND SPECIAL
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
            Hex_Types.ENTERTAINMENT => tier switch
            {
                Building_Tier.I => Building_Type.PUBLIC_PARK,
                Building_Tier.II => Building_Type.CIRCUS,
                Building_Tier.III => Building_Type.THEATER_COMPLEX,
                Building_Tier.IV => Building_Type.VIRTUAL_REALITY_CAFE,
                Building_Tier.V => Building_Type.QUANTUM_HOLOGRAM_THEATER,
                _ => Building_Type.PUBLIC_PARK,
            },
            _ => Building_Type.HOVEL,
        };
    }

    public static Hex_Prefabs BuildingTypeToHexPrefab(Building_Type type)
    {
        return type switch
        {
            Building_Type.GOD_SEAT => Hex_Prefabs.HEX_GOD_SEAT,
            Building_Type.GARDEN => Hex_Prefabs.HEX_GARDEN,
            Building_Type.FARM => Hex_Prefabs.HEX_FARM,
            Building_Type.ORCHARD => Hex_Prefabs.HEX_ORCHARD,
            Building_Type.RANCH => Hex_Prefabs.HEX_RANCH,
            Building_Type.HYDROPONICS_TOWER => Hex_Prefabs.HEX_HYDROPONICS_TOWER,
            Building_Type.HOVEL => Hex_Prefabs.HEX_HOVEL,
            Building_Type.COTTAGE => Hex_Prefabs.HEX_COTTAGE,
            Building_Type.APARTMENT => Hex_Prefabs.HEX_APARTMENT,
            Building_Type.CONDOMINIUM => Hex_Prefabs.HEX_CONDOMINIUM,
            Building_Type.VILLA => Hex_Prefabs.HEX_VILLA,
            Building_Type.WORKSHOP => Hex_Prefabs.HEX_WORKSHOP,
            Building_Type.FORGE => Hex_Prefabs.HEX_FORGE,
            Building_Type.MILL => Hex_Prefabs.HEX_MILL,
            Building_Type.FOUNDRY => Hex_Prefabs.HEX_FOUNDRY,
            Building_Type.FACTORY => Hex_Prefabs.HEX_FACTORY,
            Building_Type.BARRACKS => Hex_Prefabs.HEX_BARRACKS,
            Building_Type.DORMITORY => Hex_Prefabs.HEX_DORMITORY,
            Building_Type.GARRISON => Hex_Prefabs.HEX_GARRISON,
            Building_Type.QUARTERS => Hex_Prefabs.HEX_QUARTERS,
            Building_Type.HEADQUARTERS => Hex_Prefabs.HEX_HEADQUARTERS,
            Building_Type.WATCHTOWER => Hex_Prefabs.HEX_WATCHTOWER,
            Building_Type.MISSILE_COMPLEX => Hex_Prefabs.HEX_MISSILE_COMPLEX,
            Building_Type.LASER_TOWER => Hex_Prefabs.HEX_LASER_TOWER,
            Building_Type.AUTO_MISSILE_COMPLEX => Hex_Prefabs.HEX_AUTO_MISSILE_COMPLEX,
            Building_Type.AUTO_LASER_TOWER => Hex_Prefabs.HEX_AUTO_LASER_TOWER,
            Building_Type.RESEARCH_LAB => Hex_Prefabs.HEX_RESEARCH_LAB,
            Building_Type.RESEARCH_COLLEGE => Hex_Prefabs.HEX_RESEARCH_COLLEGE,
            Building_Type.RESEARCH_INSTITUTE => Hex_Prefabs.HEX_RESEARCH_INSTITUTE,
            Building_Type.MULTIBRAIN_COMPLEX => Hex_Prefabs.HEX_MULTIBRAIN_COMPLEX,
            Building_Type.QUANTUM_BRAIN => Hex_Prefabs.HEX_QUANTUM_BRAIN,
            Building_Type.EXTRACTOR_MK_I => Hex_Prefabs.HEX_STOCKPILE,
            Building_Type.EXTRACTOR_MK_II => Hex_Prefabs.HEX_STOREHOUSE,
            Building_Type.EXTRACTOR_MK_III => Hex_Prefabs.HEX_WAREHOUSE,
            Building_Type.EXTRACTOR_MK_IV => Hex_Prefabs.HEX_DEPOT,
            Building_Type.EXTRACTOR_MK_V => Hex_Prefabs.HEX_DISTRIBUTION_CENTER,
            Building_Type.SHOOTING_RANGE => Hex_Prefabs.HEX_SHOOTING_RANGE,
            Building_Type.DEFENDERS_WALL => Hex_Prefabs.HEX_DEFENDERS_WALL,
            Building_Type.GUNNERS_ALLEY => Hex_Prefabs.HEX_GUNNERS_ALLEY,
            Building_Type.SNIPERS_NEST => Hex_Prefabs.HEX_SNIPER_NEST,
            Building_Type.SCOUT_CAMP => Hex_Prefabs.HEX_SCOUT_CAMP,
            Building_Type.ACES_ARENA => Hex_Prefabs.HEX_ACES_ARENA,
            Building_Type.CANNONEERS_TOWER => Hex_Prefabs.HEX_CANNONEERS_TOWER,
            Building_Type.GUARDIANS_LAST_STAND => Hex_Prefabs.HEX_GUARDIANS_LAST_STAND,
            Building_Type.STOCKPILE => Hex_Prefabs.HEX_STOCKPILE,
            Building_Type.STOREHOUSE => Hex_Prefabs.HEX_STOREHOUSE,
            Building_Type.WAREHOUSE => Hex_Prefabs.HEX_WAREHOUSE,
            Building_Type.DEPOT => Hex_Prefabs.HEX_DEPOT,
            Building_Type.DISTRIBUTION_CENTER => Hex_Prefabs.HEX_DISTRIBUTION_CENTER,
            Building_Type.WATERWHEEL_GENERATOR => Hex_Prefabs.HEX_WATERWHEEL,
            Building_Type.COAL_FIRED_POWER_PLANT => Hex_Prefabs.HEX_COAL_FIRED_POWER_PLANT,
            Building_Type.HYDROELECTRIC_DAM => Hex_Prefabs.HEX_HYDROELECTRIC_DAM,
            Building_Type.NUCLEAR_POWER_PLANT => Hex_Prefabs.HEX_NUCLEAR_POWER_PLANT,
            Building_Type.QUANTUM_POWER_PLANT => Hex_Prefabs.HEX_QUANTUM_POWER_PLANT,
            Building_Type.PUBLIC_PARK => Hex_Prefabs.HEX_PUBLIC_PARK,
            Building_Type.CIRCUS => Hex_Prefabs.HEX_CIRCUS,
            Building_Type.THEATER_COMPLEX => Hex_Prefabs.HEX_THEATER_COMPLEX,
            Building_Type.VIRTUAL_REALITY_CAFE => Hex_Prefabs.HEX_VIRTUAL_REALITY_CAFE,
            Building_Type.QUANTUM_HOLOGRAM_THEATER => Hex_Prefabs.HEX_QUANTUM_HOLOGRAM_THEATER,
            Building_Type.VOID_PORTAL => Hex_Prefabs.HEX_VOID_PORTAL,
            Building_Type.VOID_COMMUNICATOR => Hex_Prefabs.HEX_VOID_COMMUNICATOR,
            Building_Type.VOID_RADAR_ARRAY => Hex_Prefabs.HEX_VOID_RADAR_ARRAY,
            Building_Type.FACTION_EMBASSY => Hex_Prefabs.HEX_FACTION_EMBASSY,
            Building_Type.ABYSSAL_PATHFINDER => Hex_Prefabs.HEX_ABYSSAL_PATHFINDER,
            Building_Type.VOID_RUDDER => Hex_Prefabs.HEX_VOID_RUDDER,
            Building_Type.WEATHER_MANIPULATOR => Hex_Prefabs.HEX_WEATHER_MANIPULATOR,
            Building_Type.DIPLO_MONUMENT => Hex_Prefabs.HEX_DIPLO_MONUMENT,
            Building_Type.SCI_MONUMENT => Hex_Prefabs.HEX_SCI_MONUMENT,
            Building_Type.HAPP_MONUMENT => Hex_Prefabs.HEX_HAPP_MONUMENT,
            Building_Type.IND_MONUMENT => Hex_Prefabs.HEX_IND_MONUMENT,
            Building_Type.ISO_MONUMENT => Hex_Prefabs.HEX_ISO_MONUMENT,
            Building_Type.MIL_MONUMENT => Hex_Prefabs.HEX_MIL_MONUMENT,
            Building_Type.FOOD_MONUMENT => Hex_Prefabs.HEX_FOOD_MONUMENT,
            _ => Hex_Prefabs.HEX_HOVEL,
        };
    }

    public static Model_Prefabs BuildingTypeToModelPrefab(Building_Type type)
    {
        switch (type)
        {
            case Building_Type.GARDEN:
                return Model_Prefabs.MODEL_GARDEN;
            case Building_Type.FARM:
                return Model_Prefabs.MODEL_FARM;
            case Building_Type.ORCHARD:
                return Model_Prefabs.MODEL_ORCHARD;
            case Building_Type.RANCH:
                return Model_Prefabs.MODEL_RANCH;
            case Building_Type.HYDROPONICS_TOWER:
                return Model_Prefabs.MODEL_HYDROPONICS_TOWER;
            case Building_Type.HOVEL:
                return Model_Prefabs.MODEL_HOVEL;
            case Building_Type.COTTAGE:
                return Model_Prefabs.MODEL_COTTAGE;
            case Building_Type.APARTMENT:
                return Model_Prefabs.MODEL_APARTMENT;
            case Building_Type.CONDOMINIUM:
                return Model_Prefabs.MODEL_CONDOMINIUM;
            case Building_Type.VILLA:
                return Model_Prefabs.MODEL_VILLA;
            case Building_Type.WORKSHOP:
                return Model_Prefabs.MODEL_WORKSHOP;
            case Building_Type.FORGE:
                return Model_Prefabs.MODEL_FORGE;
            case Building_Type.MILL:
                return Model_Prefabs.MODEL_MILL;
            case Building_Type.FOUNDRY:
                return Model_Prefabs.MODEL_FOUNDRY;
            case Building_Type.FACTORY:
                return Model_Prefabs.MODEL_FACTORY;
            case Building_Type.BARRACKS:
                return Model_Prefabs.MODEL_BARRACKS;
            case Building_Type.DORMITORY:
                return Model_Prefabs.MODEL_DORMITORY;
            case Building_Type.GARRISON:
                return Model_Prefabs.MODEL_GARRISON;
            case Building_Type.QUARTERS:
                return Model_Prefabs.MODEL_QUARTERS;
            case Building_Type.HEADQUARTERS:
                return Model_Prefabs.MODEL_HEADQUARTERS;
            case Building_Type.RESEARCH_LAB:
                return Model_Prefabs.MODEL_RESEARCH_LAB;
            case Building_Type.RESEARCH_COLLEGE:
                return Model_Prefabs.MODEL_RESEARCH_COLLEGE;
            case Building_Type.RESEARCH_INSTITUTE:
                return Model_Prefabs.MODEL_RESEARCH_INSTITUTE;
            case Building_Type.MULTIBRAIN_COMPLEX:
                return Model_Prefabs.MODEL_MULTIBRAIN_COMPLEX;
            case Building_Type.QUANTUM_BRAIN:
                return Model_Prefabs.MODEL_QUANTUM_BRAIN;
            case Building_Type.EXTRACTOR_MK_I:
                return Model_Prefabs.MODEL_EXTRACTOR_MK_I;
            case Building_Type.EXTRACTOR_MK_II:
                return Model_Prefabs.MODEL_EXTRACTOR_MK_II;
            case Building_Type.EXTRACTOR_MK_III:
                return Model_Prefabs.MODEL_EXTRACTOR_MK_III;
            case Building_Type.EXTRACTOR_MK_IV:
                return Model_Prefabs.MODEL_EXTRACTOR_MK_IV;
            case Building_Type.EXTRACTOR_MK_V:
                return Model_Prefabs.MODEL_EXTRACTOR_MK_V;
            case Building_Type.STOCKPILE:
                return Model_Prefabs.MODEL_STOCKPILE;
            case Building_Type.STOREHOUSE:
                return Model_Prefabs.MODEL_STOREHOUSE;
            case Building_Type.WAREHOUSE:
                return Model_Prefabs.MODEL_WAREHOUSE;
            case Building_Type.DEPOT:
                return Model_Prefabs.MODEL_DEPOT;
            case Building_Type.DISTRIBUTION_CENTER:
                return Model_Prefabs.MODEL_DISTRIBUTION_CENTER;
            case Building_Type.PUBLIC_PARK:
                return Model_Prefabs.MODEL_PUBLIC_PARK;
            case Building_Type.CIRCUS:
                return Model_Prefabs.MODEL_CIRCUS;
            case Building_Type.THEATER_COMPLEX:
                return Model_Prefabs.MODEL_THEATER_COMPLEX;
            case Building_Type.VIRTUAL_REALITY_CAFE:
                return Model_Prefabs.MODEL_VIRTUAL_REALITY_CAFE;
            case Building_Type.QUANTUM_HOLOGRAM_THEATER:
                return Model_Prefabs.MODEL_QUANTUM_HOLOGRAM_THEATER;
            case Building_Type.DIPLO_MONUMENT://TODO monument stuff
                throw new System.NotImplementedException();
            case Building_Type.SCI_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.HAPP_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.IND_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.ISO_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.MIL_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.FOOD_MONUMENT:
                throw new System.NotImplementedException();
            case Building_Type.VOID_PORTAL:
            case Building_Type.VOID_COMMUNICATOR:
            case Building_Type.VOID_RADAR_ARRAY:
            case Building_Type.FACTION_EMBASSY:
            case Building_Type.ABYSSAL_PATHFINDER:
            case Building_Type.VOID_RUDDER:
            case Building_Type.WEATHER_MANIPULATOR:
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
                return Model_Prefabs.MODEL_GARDEN;
        }
    }
}
