using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Blueprint : MonoBehaviour
{
    private Ghost_Hex occupiedHex;
    private Hex connectedHex;
    private MeshCollider collider;

    private Renderer rend;

    private void Awake()
    {
        connectedHex = GetComponent<Hex>();
        collider = GetComponent<MeshCollider>();
        collider.enabled = false;
        rend = GetComponent<Renderer>();
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
            //Debug.Log("CLICKED OFF A HEX");
            StartCoroutine(Blink(0.5f));
            return;
        }

        if(!Resource_Manager.HaveRequiredBuildingCosts(Resource_Manager.GetBuildingCost(connectedHex.ConnectedBuilding.BuildingType)))
        {
            UI_Manager.FlashMissingResources(Resource_Manager.GetBuildingCost(connectedHex.ConnectedBuilding.BuildingType));
            //Debug.Log("NOT ENOUGH RESOURCES");
            return;
        }

        //deduct required Resources
        Resource_Manager.DeductResources(Resource_Manager.GetBuildingCost(connectedHex.ConnectedBuilding.BuildingType));

        //disable the ghost hexes
        City_Manager.DisableAvailableHexHighlights();

        //change mat to regular mat
        connectedHex.SetStandardMaterial();

        //init connected hex
        connectedHex.Initialize(occupiedHex.hexCoord.x, occupiedHex.hexCoord.y);

        //update connected hex neighbors
        City_Manager.SetupNeighbors(connectedHex);
        connectedHex.AddToNeighbors();

        connectedHex.ConnectedBuilding.UpdateProductionValue();
        connectedHex.ConnectedBuilding.UpdateNeighborProductionValues();
        

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
        City_Manager.Instance.UnhighlightHex();

        //disable the ghost hexes
        City_Manager.DisableAvailableHexHighlights();

        //set city manager's hex_blueprint to null
        City_Manager.Instance.hexBlueprint = null;

        //destroy this gameobject
        Destroy(this.gameObject);
    }

    private IEnumerator Blink(float time)
    {
        float endTime = Time.time + time;

        while(Time.time < endTime)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        rend.enabled = true;
    }
}
