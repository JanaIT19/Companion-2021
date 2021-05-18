using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    public Sprite[] SpriteArray;

    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(string status)
    {
        if(SpriteArray.Length < 3)
        {
            return;
        }

        switch(status)
        {
            case "Active":
                _spriteRenderer.sprite = SpriteArray[2]; 
            break;
            case "Neighbour":
                _spriteRenderer.sprite = SpriteArray[1]; 
            break;
            default:
                _spriteRenderer.sprite = SpriteArray[0]; 
            break;

        }
    
    }
}