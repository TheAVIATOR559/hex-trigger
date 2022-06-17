using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Panel_Button : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;

    public void OnClick()
    {
        UI_Manager.ResetCityUIState();

        Event_Manager.PauseGame();
        optionsPanel.SetActive(true);
    }
}
