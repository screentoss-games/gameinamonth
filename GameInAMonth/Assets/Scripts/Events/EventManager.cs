using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    public delegate void Unsubscribe();
    private Dictionary<EventType, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager Instance {
        get {
            return eventManager;
        }
    }
    void Awake() {
        if (eventManager == null) {
            eventManager = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else if (eventManager != this) {
            Destroy(gameObject);
        }
    }

    private void Init() {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<EventType, UnityEvent>();
        }
    }

    public static Unsubscribe Subscribe(EventType type, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (!Instance.eventDictionary.TryGetValue(type, out thisEvent)) {
            Debug.Log(String.Format("Registering new EventType: {0}", type.ToString()));
            thisEvent = new UnityEvent();
            Instance.eventDictionary.Add(type, thisEvent);
        }
        thisEvent.AddListener(listener);

        return () => thisEvent.RemoveListener(listener);
    }
    public static void TriggerEvent(EventType type) {
        UnityEvent thisEvent;
        if (Instance.eventDictionary.TryGetValue(type, out thisEvent)) {
            thisEvent.Invoke();
        }
        else {
            Debug.Log(String.Format("No subscribers on EventType: {0}", type.ToString()));
        }
    }
}
