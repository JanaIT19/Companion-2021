﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public void DeleteItem()
    {
        Destroy(gameObject);
    }
}