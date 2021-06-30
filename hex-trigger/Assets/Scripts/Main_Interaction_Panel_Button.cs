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
            City_Manager.Instance.UnhighlightHex();
        }
        else
        {
            UI_Manager.ResetCityUIState();
            City_Manager.Instance.UnhighlightHex();
            UI_Manager.EnableBuildInfoPanel();
            City_Overview_Button.DisableCityOverview();
            panelToEnable.SetActive(true);
        }
        //UI_Manager.ResetCityUIState();
        
    }
}
