using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public GameObject CollectibleSoundObject;

    public void DeleteItem()
    {
        if (CollectibleSoundObject != null)
        {
            Instantiate(CollectibleSoundObject, transform.position, Quaternion.identity); //creates where current object is
        }
        Destroy(gameObject);
    }
}
