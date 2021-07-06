using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannoneers_Tower : Building_Military
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
        if(IsPowered)
        {
            Resource_Manager.IncreaseHeroUnitCap(Enums.Unit_Type.CANNONEER, Constants.CANNONEERS_PER_HEX);
        }
        
    }

    protected override void RemoveFromResourceProduction()
    {
        Resource_Manager.DecreaseHeroUnitCap(Enums.Unit_Type.CANNONEER, Constants.CANNONEERS_PER_HEX);
    }
}
