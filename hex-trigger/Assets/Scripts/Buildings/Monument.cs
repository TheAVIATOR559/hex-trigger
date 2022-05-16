using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : Building
{
    //todo test

    [SerializeField] private Enums.MonumentType monumentType;

    private bool adjProdCreated = false;

    public override void Initalize()
    {
        base.Initalize();

        if(!adjProdCreated)
        {
            AdjustedProduction = Resource_Manager.UpdateMonumentProduction(BuildingType);
            Resource_Manager.UpdateMonumentCost(BuildingType);
            Resource_Manager.UpdateMonumentCount(BuildingType, true);
            adjProdCreated = true;
        }
    }

    public override void DetermineBuildingTier()
    {
        //intentionally left blank
    }

    public override void UpdateProductionValue()
    {
        //intentionally left blank
    }

    protected override void AddToResourceProduction()
    {
        if(adjProdCreated)
        {
            Resource_Manager.AddProduction(HexType, Mathf.RoundToInt(AdjustedProduction), monumentType);
        }
        else
        {
            AdjustedProduction = Resource_Manager.UpdateMonumentProduction(BuildingType);
            Resource_Manager.UpdateMonumentCost(BuildingType);
            Resource_Manager.UpdateMonumentCount(BuildingType, true);
            Resource_Manager.AddProduction(HexType, Mathf.RoundToInt(AdjustedProduction), monumentType);
            adjProdCreated = true;
        }
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.RemoveProduction(HexType, Mathf.RoundToInt(AdjustedProduction), monumentType);
    }
}
