using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Training_Button : MonoBehaviour
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
            Resource_Manager.DeductResources(cost);

            //increase unit count
            Resource_Manager.IncreaseUnitCount(UnitType, 1);
        }
        else
        {
            UI_Manager.FlashMissingResources(cost);
        }
    }
}
