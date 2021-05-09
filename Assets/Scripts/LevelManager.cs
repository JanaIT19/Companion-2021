using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Range (1, 10)]
    public int PlatformCountLimit = 3; //maximum value
    public int PlatformCounter {get; private set;}
    
    private EventManager _eventManager;

    private void Awake() 
    {
        PlatformCounter = 0;
        _eventManager = FindObjectOfType<EventManager>();
    }

    public void PlatformAdd()
    {
        PlatformCounter = Math.Min(PlatformCountLimit, PlatformCounter+1);
    }

    public void PlatformRemove()
    {
        PlatformCounter = Math.Max(0, PlatformCounter-1);

    }

    public bool IsPlatformLimitReached()
    {
        return PlatformCounter >= PlatformCountLimit;
    }
}
