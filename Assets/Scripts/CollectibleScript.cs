using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) //checks only once
    {
        var pointComp = other.gameObject.GetComponent<Point>(); //check player tag instead!!!

        if (pointComp != null)
        {
            _eventManager?.OnItemCollected.Invoke();
            Destroy(this.gameObject);
        }
    }
}
