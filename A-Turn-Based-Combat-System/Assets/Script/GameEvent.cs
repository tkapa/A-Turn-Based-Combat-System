﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event", menuName ="Game Event")]
public class GameEvent : ScriptableObject {

    private List<GameEventListener> listeners =
        new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    { listeners.Add(listener); }

    public void UndregisterListener(GameEventListener listener)
    { listeners.Remove(listener); }
}
