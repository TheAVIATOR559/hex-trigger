using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Blueprint : MonoBehaviour
{
    private Ghost_Hex occupiedHex;
    private Hex connectedHex;
    private MeshCollider collider;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
        collider = GetComponent<MeshCollider>();
        collider.enabled = false;
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

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            PlaceHex();
        }

        if(Input.GetMouseButtonUp(1))
        {
            CancelPlacement();
        }
    }

    private void PlaceHex()
    {
        if(occupiedHex == null)
        {
            //TODO indicate invalid click
            Debug.Log("CLICKED OFF A HEX");
            return;
        }

        if(!Resource_Manager.HaveRequiredBuildingCosts(Resource_Manager.GetBuildingCost(connectedHex.ConnectedBuilding.BuildingType)))
        {
            //TODO indicate lack of resources
            Debug.Log("NOT ENOUGH RESOURCES");
            return;
        }

        //TODO deduct required Resources

        //disable the ghost hexes
        City_Manager.DisableAvailableHexHighlights();

        //change mat to regular mat
        connectedHex.SetStandardMaterial();

        //init connected hex
        connectedHex.Initialize(occupiedHex.hexCoord.x, occupiedHex.hexCoord.y);

        //update connected hex neighbors
        City_Manager.SetupNeighbors(connectedHex);
        connectedHex.AddToNeighbors();

        //update available placement position
        City_Manager.Instance.UpdateAvialableHexPositions();

        //set city manager's hex_blueprint to null
        City_Manager.Instance.hexBlueprint = null;

        UI_Manager.DisableHexTierPanel();

        //reenable the collider
        collider.enabled = true;

        //destroy this script
        Destroy(this);
    }

    private void CancelPlacement()
    {
        //reenable the place hex panel
        UI_Manager.ResetCityUIState();

        //disable the ghost hexes
        City_Manager.DisableAvailableHexHighlights();

        //set city manager's hex_blueprint to null
        City_Manager.Instance.hexBlueprint = null;

        //destroy this gameobject
        Destroy(this.gameObject);
    }
}
