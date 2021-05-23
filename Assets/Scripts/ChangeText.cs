using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChangeText : MonoBehaviour
{
    //public Text PlatformText;
    //public Text CollectibleText;
    public TMP_Text PlatformText;
    public TMP_Text CollectibleText;

    private LevelManager _levelManager;

    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        ShowItemCount();
        ShowPlatformCount();
    }

    // Update is called once per frame
    /*void Update()
    {
        PlatformText.text = "Platform count: " + _levelManager.PlatformCounter.ToString() + " out of " + _levelManager.PlatformCountLimit.ToString();
        CollectibleText.text = "Keys left: " + _levelManager.CollectibleCounter.ToString();
    }*/

    public void ShowItemCount()
    {
        CollectibleText.text = "Keys left: " + _levelManager.CollectibleCounter.ToString();
    }

    public void ShowPlatformCount()
    {
        PlatformText.text = "Platform count: " + _levelManager.PlatformCounter.ToString() + " out of " + _levelManager.PlatformCountLimit.ToString();
    }
}
