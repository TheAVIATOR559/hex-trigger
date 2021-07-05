using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Power : Building
{
    [SerializeField] private GameObject RangeHighlighter;

    [SerializeField] List<Vector2Int> PoweredHexPositions = new List<Vector2Int>();

    private Action<EventParam> PowerUpdateListener;

    public override void Initalize()
    {
        base.Initalize();

        PowerUpdateListener = new Action<EventParam>(GivePowerToHex);

        IsPowered = true;
        RangeHighlighter.SetActive(false);

        GetPoweredHexPositions();
    }

    public override void DetermineBuildingTier()
    {
        //short circuit
    }

    private void GetPoweredHexPositions()
    {
        foreach(Transform child in RangeHighlighter.transform)
        {
            //get the hex position of the child
            PoweredHexPositions.Add(Hex.GetHexCoordFromWorldCoord(child.position));
        }

        DistributePower();
    }

    public void DistributePower()
    {
        foreach(Vector2Int point in PoweredHexPositions)
        {
            Hex hex = City_Manager.GetHex(point);
            if (hex != null)
            {
                hex.ConnectedBuilding.SetPowered(true);
            }
        }
    }

    public void GivePowerToHex(Hex hex)
    {
        if(PoweredHexPositions.Contains(hex.Position))
        {
            hex.ConnectedBuilding.SetPowered(true);
        }
    }

    private void GivePowerToHex(EventParam eventParam)
    {
        //todo wrap this in a distance check
        GivePowerToHex(eventParam.hex);
    }

    public void RemovePower()
    {
        foreach (Vector2Int point in PoweredHexPositions)
        {
            Hex hex = City_Manager.GetHex(point);
            if (hex != null)
            {
                hex.ConnectedBuilding.SetPowered(false);
            }
        }
    }
}
