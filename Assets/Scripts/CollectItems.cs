using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var item = other.gameObject.GetComponent<CollectibleItem>(); 
        if (item != null)
        {
            _eventManager?.OnItemCollected.Invoke();
            item.DeleteItem();
        }   
    }
}
