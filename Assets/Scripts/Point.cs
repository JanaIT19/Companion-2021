﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{   
    public PointsStateEnum pointType { get; set; } = PointsStateEnum.Unselected;
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public SpriteRenderer pointVisual;
    private DrawingManager Grid;
    
    private void Start() 
    {
        if (gameObject.GetComponentInParent<DrawingManager>() != null)
        {
            Grid = gameObject.GetComponentInParent<DrawingManager>();
        }
    }

    private void OnMouseOver() 
    {
        if (Grid.isAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Selected;
        Grid.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Neighbour, Color.blue);
        pointVisual.color = Color.red;

    }

    private void OnMouseExit() 
    {
        if (Grid.isAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Unselected;
        Grid.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Unselected, Color.white);
        pointVisual.color = Color.white;
    }

    private void OnMouseDown() 
    {
       if (this.pointType == PointsStateEnum.Neighbour)
       {
           Grid.ResetPointStates();
           Grid.isAnyPointClicked = false;
           Grid.finishPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
           Grid.CreatePath(Grid.startPoint, Grid.finishPoint);
           //Grid.finishPoint = new Vector2(this.X, this.Y);
           //draw the line
           //https://docs.unity3d.com/Manual/9SliceSprites.html
       } else if (Grid.isAnyPointClicked == false)
       {
           this.pointType = PointsStateEnum.Clicked;
           Grid.isAnyPointClicked = true;
           pointVisual.color = Color.yellow;
           Grid.startPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
           //Grid.startPoint = new Vector2(this.X, this.Y);
       }
    }


    public void ChangeColor(Color c)
    {
        pointVisual.color = c;
    }


//1. Transform parent. get object - get component, ссылка на массив\родителя, вызвать нужным метод родителя;
//2. UnityEvent
}

