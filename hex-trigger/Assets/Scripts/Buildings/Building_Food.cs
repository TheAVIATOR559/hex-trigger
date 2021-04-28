using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Food : Production_Building
{
    protected override void UpdateProductionValue()
    {
        //prod value = Tier bonus * tier production
        ProductionValue = GetProductionBonus(BuildingTier) * GetProductionValue(BuildingTier, HexType);
    }

    public override void TickResourceProduction()
    {
        
    }
}
