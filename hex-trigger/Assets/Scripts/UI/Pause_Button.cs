using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Button : MonoBehaviour
{
    public void OnClick()
    {
        if(Event_Manager.IsGamePaused)
        {
            Event_Manager.UnpauseGame();
        }
        else
        {
            Event_Manager.PauseGame();
        }
    }
}
