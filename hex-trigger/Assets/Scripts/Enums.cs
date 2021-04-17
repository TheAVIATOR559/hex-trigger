using System.Collections;
using System.Collections.Generic;


public static class Enums
{
    public enum Prefabs
    {
        HEX_BASIC,
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
        BASIC,
        FOOD,
        HOUSING,
        INDUSTRY,
        MILITARY,
        RESEARCH,
        ISOLIUM,
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
        GOD_SEAT,
        FOOD_I,
        HOUSING_I,
        INDUSTRY_I,
        MILITARY_I,
        DEFENSE_I,
        RESEARCH_I,
        ISOLIUM_I
    }

    public static Prefabs HexTypeToPrefab(Hex_Types type)
    {
        switch(type)
        {
            case Hex_Types.BASIC:
                return Prefabs.HEX_BASIC;
            case Hex_Types.FOOD:
                return Prefabs.HEX_FOOD;
            case Hex_Types.HOUSING:
                return Prefabs.HEX_HOUSING;
            case Hex_Types.INDUSTRY:
                return Prefabs.HEX_INDUSTRY;
            case Hex_Types.ISOLIUM:
                return Prefabs.HEX_ISOLIUM;
            case Hex_Types.MILITARY:
                return Prefabs.HEX_MILITARY;
            case Hex_Types.RESEARCH:
                return Prefabs.HEX_RESEARCH;
            case Hex_Types.GOD_SEAT:
                return Prefabs.HEX_GOD_SEAT;
            default:
                return Prefabs.HEX_BASIC;
        }
    }
}
