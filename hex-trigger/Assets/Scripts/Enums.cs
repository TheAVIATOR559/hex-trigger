using System.Collections;
using System.Collections.Generic;


public static class Enums
{
    public enum Prefabs//TODO NEED TO REWORK THIS ENTIRE THING
    {
        HEX_EMPTY,
        HEX_FOOD,
        HEX_HOUSING,
        HEX_INDUSTRY,
        HEX_MILITARY,
        HEX_RESEARCH,
        HEX_ISOLIUM,
        HEX_GHOST,
        HEX_GOD_SEAT
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

    public static Prefabs BuildingTypeToPrefab(Building_Type type) //TODO FILL ME IN
    {
        switch (type)
        {
            case Building_Type.GOD_SEAT:
                break;
            case Building_Type.GARDEN:
                break;
            case Building_Type.FARM:
                break;
            case Building_Type.ORCHARD:
                break;
            case Building_Type.RANCH:
                break;
            case Building_Type.HYDROPONICS_TOWER:
                break;
            case Building_Type.HOVEL:
                break;
            case Building_Type.COTTAGE:
                break;
            case Building_Type.APARTMENT:
                break;
            case Building_Type.CONDOMINIUM:
                break;
            case Building_Type.VILLA:
                break;
            case Building_Type.WORKSHOP:
                break;
            case Building_Type.FORGE:
                break;
            case Building_Type.MILL:
                break;
            case Building_Type.FOUNDRY:
                break;
            case Building_Type.FACTORY:
                break;
            case Building_Type.BARRACKS:
                break;
            case Building_Type.DORMITORY:
                break;
            case Building_Type.GARRISON:
                break;
            case Building_Type.QUARTERS:
                break;
            case Building_Type.HEADQUARTERS:
                break;
            case Building_Type.WATCHTOWER:
                break;
            case Building_Type.MISSILE_COMPLEX:
                break;
            case Building_Type.LASER_TOWER:
                break;
            case Building_Type.AUTO_MISSILE_COMPLEX:
                break;
            case Building_Type.AUTO_LASER_TOWER:
                break;
            case Building_Type.RESEARCH_LAB:
                break;
            case Building_Type.RESEARCH_COLLEGE:
                break;
            case Building_Type.RESEARCH_INSTITUTE:
                break;
            case Building_Type.MULTIBRAIN_COMPLEX:
                break;
            case Building_Type.QUANTUM_BRAIN:
                break;
            case Building_Type.STOCKPILE:
                break;
            case Building_Type.STOREHOUSE:
                break;
            case Building_Type.WAREHOUSE:
                break;
            case Building_Type.DEPOT:
                break;
            case Building_Type.DISTRIBUTION_CENTER:
                break;
            case Building_Type.EMPTY:
            default:
                return Prefabs.HEX_EMPTY;
        }

    }
}
