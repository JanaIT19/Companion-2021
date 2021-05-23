using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool IsExitActivated {get; private set;} = false;

    public void SetWinCondition()
    {
        IsExitActivated = true;
    }

    public void CheckWinCondition(int itemCounter)
    {
        if (itemCounter <= 0)
        {
            Debug.Log("Win");
        } 
        else
        {
            Debug.Log("Not win");
        }
    }
}
