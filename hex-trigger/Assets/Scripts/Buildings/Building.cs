using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Enums.Hex_Types Type;
    public Enums.Building_Tier Tier;

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
            if(hex.ConnectedBuilding.Type == Type)
            {
                similarHexes++;
            }
        }

        if(similarHexes < 2)
        {
            Tier = Enums.Building_Tier.I;
        }
        else if(similarHexes == 2)
        {
            Tier = Enums.Building_Tier.II;
        }
        else if(similarHexes == 3)
        {
            Tier = Enums.Building_Tier.III;
        }
        else if(similarHexes > 3 && similarHexes < 6)
        {
            Tier = Enums.Building_Tier.IV;
        }
        else if(similarHexes == 6)
        {
            Tier = Enums.Building_Tier.V;
        }
        else
        {
            Debug.LogError("similarHexes is greater than 6 :: " + connectedHex.Position);
        }

        UpdateModel();
    }

    protected virtual void UpdateModel()
    {
        // should be fleshed out in children

        //replace building model with tier accurate one
        //destroy this hex/building
    }

}
