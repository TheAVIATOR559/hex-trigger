using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick_Manager : MonoBehaviour
{
    [SerializeField] float TimeSinceLastTick = 0;

    private void Update()
    {
        if (Event_Manager.IsGamePaused)
        {
            return;
        }

        if (TimeSinceLastTick >= 1f / Constants.TICK_SPEED)
        {
            //trigger tick event
            Event_Manager.TriggerEvent(Events.TICK);
            TimeSinceLastTick = 0;
        }
        else
        {
            TimeSinceLastTick += Time.deltaTime;
        }
    }
}
