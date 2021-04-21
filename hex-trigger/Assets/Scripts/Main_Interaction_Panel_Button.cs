using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Interaction_Panel_Button : MonoBehaviour
{
    [SerializeField] GameObject panelToEnable;

    public void OnClick()
    {
        UI_Manager.ResetCityUIState();
        panelToEnable.SetActive(true);
    }
}
