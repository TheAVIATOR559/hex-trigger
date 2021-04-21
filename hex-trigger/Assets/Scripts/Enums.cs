using System.Collections;
using System.Collections.Generic;


public static class Enums
{
    public enum Prefabs
    {
        HEX_EMPTY,
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
        HEX_STOCKPILE,
        HEX_STOREHOUSE,
        HEX_WAREHOUSE,
        HEX_DEPOT,
        HEX_DISTRIBUTION_CENTER
    }

    public enum Hex_Types
    {
        EMPTY,
        FOOD,
        HOUSING,
        INDUSTRY,
        MILITARY,
        RESEARCH,
        ISOLIUM,
        DEFENSE,
        GOD_SEAT
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
        EMPTY,
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
        STOCKPILE,
        STOREHOUSE,
        WAREHOUSE,
        DEPOT,
        DISTRIBUTION_CENTER
    }

    public static Building_Type HexTypeAndTierToBuildingType(Hex_Types hex, Building_Tier tier)
    {
        return hex switch
        {
            Hex_Types.EMPTY => Building_Type.EMPTY,
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
                Building_Tier.I => Building_Type.STOCKPILE,
                Building_Tier.II => Building_Type.STOREHOUSE,
                Building_Tier.III => Building_Type.WAREHOUSE,
                Building_Tier.IV => Building_Type.DEPOT,
                Building_Tier.V => Building_Type.DISTRIBUTION_CENTER,
                _ => Building_Type.STOCKPILE,
            },
            _ => Building_Type.EMPTY,
        };
    }

    public static Prefabs BuildingTypeToPrefab(Building_Type type)
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
            case Building_Type.EMPTY:
            default:
                return Prefabs.HEX_EMPTY;
        }

    }
}
