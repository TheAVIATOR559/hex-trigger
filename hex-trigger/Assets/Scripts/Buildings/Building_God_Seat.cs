using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_God_Seat : Building
{
    public override void Initalize()
    {
        IsPowered = true;
        City_Manager.SetGodSeat(connectedHex);
        base.Initalize();
    }
    public override void DetermineBuildingTier()
    {
        ///intentionally left blank 
        ///to short circuit the parent method
    }

}
