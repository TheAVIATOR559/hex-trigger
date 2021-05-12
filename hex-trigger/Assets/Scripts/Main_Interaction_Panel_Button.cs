using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Interaction_Panel_Button : MonoBehaviour
{
    [SerializeField] GameObject panelToEnable;

    public void OnClick()
    {
        if (panelToEnable.activeSelf)
        {
            UI_Manager.ResetCityUIState();
        }
        else
        {
            panelToEnable.SetActive(true);
        }
        //UI_Manager.ResetCityUIState();
        
    }
}
