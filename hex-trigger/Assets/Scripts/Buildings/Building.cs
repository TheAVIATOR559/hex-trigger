using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Enums.Hex_Types HexType;
    public Enums.Building_Tier BuildingTier;
    public Enums.Building_Type BuildingType;

    private Hex connectedHex;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
    }

    public virtual void DetermineBuildingTier()
    {
        int similarHexes = 0;

        foreach(Hex hex in connectedHex.Neighbors)
        {
            if(hex.ConnectedBuilding.HexType == HexType)
            {
                similarHexes++;
            }
        }

        if(similarHexes < 2)
        {
            BuildingTier = Enums.Building_Tier.I;
        }
        else if(similarHexes == 2)
        {
            BuildingTier = Enums.Building_Tier.II;
        }
        else if(similarHexes == 3)
        {
            BuildingTier = Enums.Building_Tier.III;
        }
        else if(similarHexes > 3 && similarHexes < 6)
        {
            BuildingTier = Enums.Building_Tier.IV;
        }
        else if(similarHexes == 6)
        {
            BuildingTier = Enums.Building_Tier.V;
        }
        else
        {
            Debug.LogError("similarHexes is greater than 6 :: " + connectedHex.Position);
        }

        UpdateModel();
    }

    protected virtual void UpdateModel() //TODO IMPLEMENT ME
    {
        // should be fleshed out in children

        //replace building model with tier accurate one
        //destroy this hex/building
    }

}
