using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loader : MonoBehaviour
{
    private void Awake()
    {
        Event_Manager.PauseGame();
        Event_Manager.UnpauseGame();
    }
}
