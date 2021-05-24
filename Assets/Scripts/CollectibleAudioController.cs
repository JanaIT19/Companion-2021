using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectibleAudioController : MonoBehaviour
{
    public float Lifetime = 1f;

    private void Start() 
    {
        //play on awake in inspector
        Destroy(gameObject, Lifetime);
    }

}
