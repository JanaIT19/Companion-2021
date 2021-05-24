using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool IsExitActivated {get; private set;} = false;
    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }
    
    public void SetWinCondition()
    {
        IsExitActivated = true;
    }

    public void CheckWinCondition(int itemCounter)
    {
        if (itemCounter <= 0)
        {
            _eventManager?.OnAllItemsCollected.Invoke();
        } 
    }
}
