using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent OnPlatformCreated;
    public UnityEvent OnPlatformRemoved;
    public UnityEvent OnItemCollected;
}
