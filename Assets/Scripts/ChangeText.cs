using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text PlatformText;
    public Text CollectibleText;

    private LevelManager _levelManager;

    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformText.text = "Platform count: " + _levelManager.PlatformCounter.ToString() + " out of " + _levelManager.PlatformCountLimit.ToString();
        CollectibleText.text = "Keys left: " + _levelManager.CollectibleCounter.ToString();
    }
}
