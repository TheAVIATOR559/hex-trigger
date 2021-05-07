using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardians_Last_Stand : Building_Military
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
        Resource_Manager.IncreaseHeroUnitCap(Enums.Unit_Type.GUARDIAN, Constants.GUARDIANS_PER_HEX);
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.DecreaseHeroUnitCap(Enums.Unit_Type.GUARDIAN, Constants.GUARDIANS_PER_HEX);
    }
}
