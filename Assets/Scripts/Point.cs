using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{   
    public PointsStateEnum pointType { get; set; } = PointsStateEnum.Unselected;
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    private DrawingManager Grid;
    private ChangeSprites _spriteChanger;
    private LevelManager _levelManager;

    private void Awake() 
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _spriteChanger = GetComponent<ChangeSprites>();
    }
    
    private void Start() 
    {
        Grid = gameObject.GetComponentInParent<DrawingManager>();
    }

    private void OnMouseOver() 
    {
        if(IsPlatformLimitReached())
        {
            return;
        }
        
        if (Grid.isAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Selected;
        Grid.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Neighbour, "Neighbour");
        _spriteChanger.ChangeSprite("Active");

    }

    private void OnMouseExit() 
    {
        if (Grid.isAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Unselected;
        Grid.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Unselected, "Default");
        _spriteChanger.ChangeSprite("Default");
    }

    private void OnMouseDown() 
    {
        if(IsPlatformLimitReached())
        {
            return;
        }

        if (this.pointType == PointsStateEnum.Neighbour)
        {
            Grid.ResetPointStates();
            Grid.isAnyPointClicked = false;
            Grid.finishPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Grid.CreatePath(Grid.startPoint, Grid.finishPoint);
           //draw the line
        } else if (Grid.isAnyPointClicked == false)
        {
           this.pointType = PointsStateEnum.Clicked;
           Grid.isAnyPointClicked = true;
           _spriteChanger.ChangeSprite("Active");
           Grid.startPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

    private bool IsPlatformLimitReached()
    {
        return _levelManager != null && _levelManager.IsPlatformLimitReached();
    }

}

