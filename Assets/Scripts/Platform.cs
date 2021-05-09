using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnMouseDown()
    {
        _eventManager?.OnPlatformRemoved.Invoke();
        Destroy(this.gameObject);
    }
}
