using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout_Camp : Building_Military
{
    public override void DetermineBuildingTier()
    {
        //short circuting parent method
    }

    protected override void UpdateProductionValue()
    {
        AddToResourceProduction();
    }

    protected override void AddToResourceProduction()
    {
        Resource_Manager.AddUnitCostReduction(Enums.Unit_Type.SCOUT, Constants.TRAINING_COST_REDUCTION_PER_HEX);
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.RemoveUnitCostReduction(Enums.Unit_Type.SCOUT, Constants.TRAINING_COST_REDUCTION_PER_HEX);
    }
}