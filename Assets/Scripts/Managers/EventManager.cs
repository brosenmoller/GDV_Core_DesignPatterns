using System;
using System.Collections.Generic;

public enum EventType
{
    ON_TICK,
    ON_MOUSE_DOWN,
}

public static class EventManager
{
    private static readonly Dictionary<EventType, Action> eventDictionary = new();

    public static void AddListener(EventType _eventType, Action _action)
    {
        if (!eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary.Add(_eventType, null);
        }

        eventDictionary[_eventType] -= _action;
        eventDictionary[_eventType] += _action;
    }

    public static void RemoveListener(EventType _eventType, Action _action) 
    { 
        if (eventDictionary.ContainsKey(_eventType) && eventDictionary[_eventType] != null) 
        {
            eventDictionary[_eventType] -= _action;
        }
    }

    public static void InvokeEvent(EventType _eventType)
    {
        if (eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary[_eventType]?.Invoke();
        }
    }
}
