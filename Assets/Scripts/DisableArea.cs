using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //checks only once
    {

        var pointComp = other.gameObject.GetComponent<Point>();

        if (pointComp != null)
        {
            pointComp.gameObject.SetActive(false);
        }

        //other.gameObject.TryGetComponent(out Point pointComp); //Tries to get Point component, if it finds it, puts it in pointComp
    }
}
