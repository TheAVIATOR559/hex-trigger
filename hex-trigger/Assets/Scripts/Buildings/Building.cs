using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Enums.Hex_Types HexType;
    public Enums.Building_Tier BuildingTier;
    public Enums.Building_Type BuildingType;

    private Hex connectedHex;

    [SerializeField] GameObject model;

    private Enums.Building_Tier prevTier;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
    }

    public virtual void DetermineBuildingTier()
    {
        int similarHexes = 0;

        prevTier = BuildingTier;

        foreach(Hex hex in connectedHex.Neighbors)
        {
            if(hex.ConnectedBuilding.HexType == HexType)
            {
                similarHexes++;
            }
        }

        if(similarHexes < 2 && prevTier < Enums.Building_Tier.I)
        {
            BuildingTier = Enums.Building_Tier.I;
        }
        else if(similarHexes == 2 && prevTier < Enums.Building_Tier.II)
        {
            BuildingTier = Enums.Building_Tier.II;
        }
        else if(similarHexes == 3 && prevTier < Enums.Building_Tier.III)
        {
            BuildingTier = Enums.Building_Tier.III;
        }
        else if(similarHexes > 3 && similarHexes < 6 && prevTier < Enums.Building_Tier.IV)
        {
            BuildingTier = Enums.Building_Tier.IV;
        }
        else if(similarHexes == 6 && prevTier < Enums.Building_Tier.V)
        {
            BuildingTier = Enums.Building_Tier.V;
        }
        //else
        //{
        //    Debug.LogError("similarHexes is greater than 6 :: " + connectedHex.Position);
        //}

        BuildingType = Enums.HexTypeAndTierToBuildingType(HexType, BuildingTier);

        if(BuildingTier != prevTier)
        {
            UpdateModel();
        }
    }


    protected virtual void UpdateModel()
    {
        //replace building model with tier accurate one
        //destroy this hex/building
        GameObject prevModel = model;

        model = Instantiate(Prefab_Manager.GetPrefab(Enums.BuildingTypeToModelPrefab(BuildingType)), model.transform.position, Quaternion.identity, transform);

        Destroy(prevModel);
    }
}
