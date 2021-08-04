using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Entertainment : Building
{
    [SerializeField] protected List<Hex> effectedHexes;

    protected override void AddToResourceProduction()
    {
        if (IsPowered)
        {
            int effectDistance = Mathf.RoundToInt(AdjustedProduction / 10f);
            Debug.Log("effect distance :: " + effectDistance);

            effectedHexes = new List<Hex>(connectedHex.Neighbors);

            for(int i = 2; i <= effectDistance; i++)
            {
                List<Hex> newEffectedHexes = new List<Hex>();

                foreach(Hex hex in effectedHexes)
                {
                    foreach(Hex neighbor in hex.Neighbors)
                    {
                        if(!effectedHexes.Contains(neighbor) && !newEffectedHexes.Contains(neighbor))
                        {
                            newEffectedHexes.Add(neighbor);
                        }
                    }
                }

                effectedHexes.AddRange(newEffectedHexes);
            }

            //clear list of non housing
            effectedHexes.RemoveAll(hex => hex.ConnectedBuilding.HexType != Enums.Hex_Types.HOUSING);

            foreach(Hex hex in effectedHexes)
            {
                //add happiness
                if(hex.ConnectedBuilding is Building_Housing)
                {
                    Building_Housing building = (Building_Housing)hex.ConnectedBuilding;

                    int happToAdd = (int)AdjustedProduction - ((Hex.GetDistance(connectedHex.Position, hex.Position) - 1) * 10);
                    //Debug.Log(happToAdd + " = " + Hex.GetDistance(connectedHex.Position, hex.Position) + " - " + 1 + " * " + 10);
                    building.AddHappiness(happToAdd);
                }
            }
        }
    }

    protected override void RemoveFromResourceProduction()
    {
        foreach (Hex hex in effectedHexes)
        {
            //add happiness
            if (hex.ConnectedBuilding is Building_Housing)
            {
                Building_Housing building = (Building_Housing)hex.ConnectedBuilding;

                int happToRemove = (int)AdjustedProduction - ((Hex.GetDistance(connectedHex.Position, hex.Position) - 1) * 10);
                //Debug.Log(happToRemove + " = " + Hex.GetDistance(connectedHex.Position, hex.Position) + " - " + 1 + " * " + 10);
                building.RemoveHappiness(happToRemove);
            }
        }
    }
}
