using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Events
{
    UPDATE_POWER_DISTRIBUTION//todo rejig to work with add and remove power
}

public struct EventParam
{
    public Hex hex;
}

public static class Event_Manager
{
    private static Dictionary<Events, Action<EventParam>> eventsDict;

    public static bool IsGamePaused//TODO integrate this in others
    {
        get;
        private set;
    }

    static Event_Manager()
    {
        eventsDict = new Dictionary<Events, Action<EventParam>>();
        IsGamePaused = false;
    }

    public static void AddListener(Events eventName, Action<EventParam> listener)
    {
        Action<EventParam> thisEvent;

        if(eventsDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;

            eventsDict[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventsDict.Add(eventName, thisEvent);
        }
    }

    public static void RemoveListener(Events eventName, Action<EventParam> listener)
    {
        Action<EventParam> thisEvent;

        if(eventsDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;

            eventsDict[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(Events eventName, EventParam eventParam)
    {
        Action<EventParam> thisEvent = null;

        if(eventsDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
        }
    }

    public static void PauseGame()
    {
        IsGamePaused = true;
    }

    public static void UnpauseGame()
    {
        IsGamePaused = false;
    }
}
