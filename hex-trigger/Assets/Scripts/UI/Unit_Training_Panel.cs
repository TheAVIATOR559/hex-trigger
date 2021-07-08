using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Training_Panel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Enums.Unit_Type UnitType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Manager.UpdateBuildInfoPanel(UnitType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Manager.ClearBuildInfoPanel();
    }
}
