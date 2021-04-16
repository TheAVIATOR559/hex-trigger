using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Blueprint : MonoBehaviour
{
    private Ghost_Hex occupiedHex;
    private Hex connectedHex;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
    }

    public void MoveToHex(Ghost_Hex hex)
    {
        transform.position = Hex.GetWorldCoordFromHexCoord(hex.hexCoord);
        occupiedHex = hex;
    }

    public void RemoveFromHex()
    {
        occupiedHex = null;
    }

    private void PlaceHex()
    {
        if(occupiedHex == null)
        {
            return;
        }

        //disable the ghost hexes
        City_Manager.DisableAvailableHexHighlights();

        //change mat to regular mat
        connectedHex.SetStandardMaterial();

        //init connected hex
        connectedHex.Initialize(occupiedHex.hexCoord.x, occupiedHex.hexCoord.y);

        //update connected hex neighbors
        City_Manager.SetupNeighbors(connectedHex);

        //update available placement position
        City_Manager.Instance.UpdateAvialableHexPositions();

        //set city manager's hex_blueprint to null
        City_Manager.Instance.hexBlueprint = null;

        //reenable place hex panel
        UI_Manager.EnablePlaceHexPanel();

        //destroy this script
        Destroy(this);
    }

    private void CancelPlacement()
    {
        //reenable the place hex panel

        //disable the ghost hexes

        //set city manager's hex_blueprint to null

        //destroy this gameobject
    }
}
