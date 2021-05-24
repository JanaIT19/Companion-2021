using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeWinSprite : MonoBehaviour
{
    public Sprite[] SpriteArray;

    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite()
    {
        _spriteRenderer.sprite = SpriteArray[0]; 
    }
}