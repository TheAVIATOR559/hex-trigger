using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Hex_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Enums.Building_Type buildingType;

    private GameObject parentPanel;

    private void Awake()
    {
        parentPanel = transform.parent.gameObject;
    }

    public void OnClick()
    {
        if(City_Manager.Instance.availbleHexPositions.Count < 1)
        {
            //flash god seat to show user that they need to upgrade the godseat
            City_Manager.FlashGodSeat();
            return;
        }

        //highlight available hex locations
        City_Manager.ActivateAvailableHexHighlights();

        //instantiate hex blueprint based on hex type
        City_Manager.Instance.hexBlueprint = Instantiate(Prefab_Manager.GetHexPrefab(Enums.BuildingTypeToHexPrefab(buildingType)), Hex.GetWorldCoordFromHexCoord(City_Manager.Instance.availbleHexPositions[0]), Quaternion.Euler(-90, 0, 0)).AddComponent<Hex_Blueprint>();

        //disable place hex panel
        UI_Manager.SetTierPanel(parentPanel);
        UI_Manager.DisableHexTierPanel();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Manager.UpdateBuildInfoPanel(buildingType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Manager.ClearBuildInfoPanel();
    }
}
