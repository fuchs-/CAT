using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ASEventSystem : MonoBehaviour
{
    #region Properties

    private static ASEventSystem instance;
    private Dictionary<string, UnityEvent> eventDictionary;

    public static bool debugMode = false;

    #endregion

    #region Initializing

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance.gameObject);

        if (eventDictionary == null)
            eventDictionary = new Dictionary<string, UnityEvent>();
    }

    #endregion

    #region Methods

    public static bool HasEventWithName(string name)
    {
        return instance.eventDictionary.ContainsKey(name);
    }

    public static void StartListeningToEventWithName(string name, UnityAction listener)
    {
        UnityEvent uEvent = null;

        if (debugMode)
            Debug.Log("ASEventSystem - Listener: '" + listener.Target.ToString() + "' started listening to event: '" + name + "'");

        if (instance.eventDictionary.TryGetValue(name, out uEvent))
        {
            uEvent.AddListener(listener);
        }
        else
        {
            uEvent = new UnityEvent();
            uEvent.AddListener(listener);
            instance.eventDictionary.Add(name, uEvent);
        }
    }

    public static void StopListeningToEventWithName(string name, UnityAction listener)
    {
        UnityEvent uEvent = null;

        if (debugMode)
            Debug.Log("ASEventSystem - Listener: '" + listener.Target.ToString() + "' stopped listening to event: '" + name + "'");

        if (instance.eventDictionary.TryGetValue(name, out uEvent))
        {
            uEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEventWithName(string name)
    {
        UnityEvent uEvent;

        if (debugMode)
            Debug.Log("ASEventSystem - Event triggered: " + name);

        if (instance.eventDictionary.TryGetValue(name, out uEvent))
        {
            uEvent.Invoke();
        }
    }

    #endregion
}
