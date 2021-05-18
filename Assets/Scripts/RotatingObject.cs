using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float Speed = 90f;

    private float objectRotation = 0f;

    void Update()
    {
        objectRotation += Time.deltaTime * Speed;
        this.transform.rotation = Quaternion.Euler(0, objectRotation, 0);    
    }
}
