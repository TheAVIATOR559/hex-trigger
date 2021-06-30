using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Enums.Hex_Types HexType;
    public Enums.Building_Tier BuildingTier;
    public Enums.Building_Type BuildingType;

    protected Hex connectedHex;

    [SerializeField] protected GameObject model;

    public float AdjustedProduction = 0;
    public float BonusFromNeighbors = 1;

    private Enums.Building_Tier prevTier;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
    }

    public virtual void Initalize()
    {
        //instantiate overivew canvas object
    }

    public virtual void DetermineBuildingTier()
    {
        int similarHexes = 0;

        prevTier = BuildingTier;

        foreach(Hex hex in connectedHex.Neighbors)
        {
            if(hex.ConnectedBuilding.HexType == HexType)
            {
                similarHexes++;
            }
        }

        if(similarHexes < 2 && prevTier < Enums.Building_Tier.I)
        {
            BuildingTier = Enums.Building_Tier.I;
        }
        else if(similarHexes == 2 && prevTier < Enums.Building_Tier.II)
        {
            BuildingTier = Enums.Building_Tier.II;
        }
        else if(similarHexes == 3 && prevTier < Enums.Building_Tier.III)
        {
            BuildingTier = Enums.Building_Tier.III;
        }
        else if(similarHexes > 3 && similarHexes < 6 && prevTier < Enums.Building_Tier.IV)
        {
            BuildingTier = Enums.Building_Tier.IV;
        }
        else if(similarHexes == 6 && prevTier < Enums.Building_Tier.V)
        {
            BuildingTier = Enums.Building_Tier.V;
        }
        //else
        //{
        //    Debug.LogError("similarHexes is greater than 6 :: " + connectedHex.Position);
        //}

        BuildingType = Enums.HexTypeAndTierToBuildingType(HexType, BuildingTier);

        if(BuildingTier != prevTier)
        {
            connectedHex.UpdateOverviewTier(BuildingTier);
            UpdateModel();
            UpdateProductionValue();
            UpdateNeighborProductionValues();
        }
    }

    protected virtual void UpdateModel()
    {
        //replace building model with tier accurate one
        //destroy this hex/building
        GameObject prevModel = model;

        model = Instantiate(Prefab_Manager.GetPrefab(Enums.BuildingTypeToModelPrefab(BuildingType)), model.transform.position, Quaternion.identity, transform);

        Destroy(prevModel);
    }

    public virtual void UpdateProductionValue()
    {
        BonusFromNeighbors = 0;

        RemoveFromResourceProduction();
        AdjustedProduction = GetProductionValue(BuildingTier, HexType);

        foreach(Hex neighbor in connectedHex.Neighbors)
        {
            if(neighbor.ConnectedBuilding.HexType == this.HexType)
            {
                BonusFromNeighbors += GetProductionBonus(neighbor.ConnectedBuilding.BuildingTier);
            }   
        }

        //Debug.Log("new prod bonus :: " + BonusFromNeighbors);

        AdjustedProduction += (AdjustedProduction * BonusFromNeighbors);

        AddToResourceProduction();
    }

    public virtual void UpdateNeighborProductionValues()
    {
        foreach(Hex neighbor in connectedHex.Neighbors)
        {
            neighbor.ConnectedBuilding.UpdateProductionValue();
        }
    }

    protected virtual void AddToResourceProduction()
    {
        Resource_Manager.AddProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
    }

    protected virtual void RemoveFromResourceProduction()
    {
        Resource_Manager.RemoveProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
    }

    public static float GetProductionBonus(Enums.Building_Tier tier)
    {
        switch (tier)
        {
            case Enums.Building_Tier.I:
                return Constants.TIER_I_BONUS;
            case Enums.Building_Tier.II:
                return Constants.TIER_II_BONUS;
            case Enums.Building_Tier.III:
                return Constants.TIER_III_BONUS;
            case Enums.Building_Tier.IV:
                return Constants.TIER_IV_BONUS;
            case Enums.Building_Tier.V:
                return Constants.TIER_V_BONUS;
            default:
                return Constants.TIER_I_BONUS;
        }
    }

    public static int GetProductionValue(Enums.Building_Tier tier, Enums.Hex_Types type)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.FOOD_I_PROD,
                    Enums.Building_Tier.II => Constants.FOOD_II_PROD,
                    Enums.Building_Tier.III => Constants.FOOD_III_PROD,
                    Enums.Building_Tier.IV => Constants.FOOD_IV_PROD,
                    Enums.Building_Tier.V => Constants.FOOD_V_PROD,
                    _ => Constants.FOOD_I_PROD,
                };
            case Enums.Hex_Types.HOUSING:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.HOUSING_I_PROD,
                    Enums.Building_Tier.II => Constants.HOUSING_II_PROD,
                    Enums.Building_Tier.III => Constants.HOUSING_III_PROD,
                    Enums.Building_Tier.IV => Constants.HOUSING_IV_PROD,
                    Enums.Building_Tier.V => Constants.HOUSING_V_PROD,
                    _ => Constants.HOUSING_I_PROD,
                };
            case Enums.Hex_Types.INDUSTRY:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.INDUSTRY_I_PROD,
                    Enums.Building_Tier.II => Constants.INDUSTRY_II_PROD,
                    Enums.Building_Tier.III => Constants.INDUSTRY_III_PROD,
                    Enums.Building_Tier.IV => Constants.INDUSTRY_IV_PROD,
                    Enums.Building_Tier.V => Constants.INDUSTRY_V_PROD,
                    _ => Constants.INDUSTRY_I_PROD,
                };
            case Enums.Hex_Types.MILITARY:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.MILITARY_I_PROD,
                    Enums.Building_Tier.II => Constants.MILITARY_II_PROD,
                    Enums.Building_Tier.III => Constants.MILITARY_III_PROD,
                    Enums.Building_Tier.IV => Constants.MILITARY_IV_PROD,
                    Enums.Building_Tier.V => Constants.MILITARY_V_PROD,
                    _ => Constants.MILITARY_I_PROD,
                };
            case Enums.Hex_Types.RESEARCH:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.RESEARCH_I_PROD,
                    Enums.Building_Tier.II => Constants.RESEARCH_II_PROD,
                    Enums.Building_Tier.III => Constants.RESEARCH_III_PROD,
                    Enums.Building_Tier.IV => Constants.RESEARCH_IV_PROD,
                    Enums.Building_Tier.V => Constants.RESEARCH_V_PROD,
                    _ => Constants.RESEARCH_I_PROD,
                };
            case Enums.Hex_Types.ISOLIUM:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.ISOLIUM_I_PROD,
                    Enums.Building_Tier.II => Constants.ISOLIUM_II_PROD,
                    Enums.Building_Tier.III => Constants.ISOLIUM_III_PROD,
                    Enums.Building_Tier.IV => Constants.ISOLIUM_IV_PROD,
                    Enums.Building_Tier.V => Constants.ISOLIUM_V_PROD,
                    _ => Constants.ISOLIUM_I_PROD,
                };
            case Enums.Hex_Types.STORAGE:
                return tier switch
                {
                    Enums.Building_Tier.I => Constants.STORAGE_I_PROD,
                    Enums.Building_Tier.II => Constants.STORAGE_II_PROD,
                    Enums.Building_Tier.III => Constants.STORAGE_III_PROD,
                    Enums.Building_Tier.IV => Constants.STORAGE_IV_PROD,
                    Enums.Building_Tier.V => Constants.STORAGE_V_PROD,
                    _ => Constants.STORAGE_I_PROD,
                };
            case Enums.Hex_Types.POWER:
            case Enums.Hex_Types.DEFENSE:
            case Enums.Hex_Types.GOD_SEAT:
            default:
                return 1;
        }
    }
}