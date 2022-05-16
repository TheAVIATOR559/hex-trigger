using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aces_Arena : Building_Military
{
    public override void DetermineBuildingTier()
    {
        //short circuting parent method
    }

    public override void UpdateProductionValue()
    {
        //short circuting parent method
    }

    public override void Initalize()
    {
        base.Initalize();
        AddToResourceProduction();
    }

    protected override void AddToResourceProduction()
    {
        Resource_Manager.IncreaseHeroUnitCap(Enums.Unit_Type.ACE, Constants.ACES_PER_HEX);
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.DecreaseHeroUnitCap(Enums.Unit_Type.ACE, Constants.ACES_PER_HEX);
    }
}
