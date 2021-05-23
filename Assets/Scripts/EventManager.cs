using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] 
public class UnityEventInt : UnityEvent<int> { }

public class EventManager : MonoBehaviour
{
    public UnityEvent OnPlatformCreated;
    public UnityEvent OnPlatformRemoved;
    public UnityEvent OnItemCollected;
    public UnityEvent OnAllItemsCollected;
    public UnityEvent OnPlatformCounterChange;
    public UnityEvent OnItemCounterChange;
    public UnityEventInt TestItemCounter;
}
