using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : Building
{
    //todo test

    public override void Initalize()
    {
        AdjustedProduction = Resource_Manager.UpdateMonumentProduction(BuildingType);
        Resource_Manager.UpdateMonumentCost(BuildingType);
        Resource_Manager.UpdateMonumentCount(BuildingType, true);
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
        Resource_Manager.AddProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.RemoveProduction(HexType, Mathf.RoundToInt(AdjustedProduction));
    }
}
