using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Training_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Enums.Unit_Type UnitType;
    private UnitTrainingCost cost;

    private void Awake()
    {
        cost = Resource_Manager.GetUnitCost(UnitType);
    }

    public void OnClick()
    {
        if(Resource_Manager.HaveRequiredUnitTrainingCosts(UnitType, cost))
        {
            Resource_Manager.DeductResources(cost, UnitType);

            //increase unit count
            Resource_Manager.IncreaseUnitCount(UnitType, 1);
        }
        else
        {
            UI_Manager.FlashMissingResources(cost);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Manager.UpdateBuildInfoPanel(UnitType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Manager.ClearBuildInfoPanel();
    }
}
