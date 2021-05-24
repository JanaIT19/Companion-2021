using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{   
    public PointsStateEnum pointType { get; set; } = PointsStateEnum.Unselected;
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    
    private DrawingManager _drawingManager;
    private ChangeSprites _spriteChanger;
    private LevelManager _levelManager;

    private void Awake() 
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _spriteChanger = GetComponent<ChangeSprites>();
    }
    
    private void Start() 
    {
        _drawingManager = gameObject.GetComponentInParent<DrawingManager>();
    }

    private void OnMouseOver() 
    {
        if(IsPlatformLimitReached())
        {
            return;
        }
        
        if (_drawingManager.IsAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Selected;
        _drawingManager.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Neighbour, "Neighbour");
        _spriteChanger.ChangeSprite("Active");

    }

    private void OnMouseExit() 
    {
        if (_drawingManager.IsAnyPointClicked == true)
        {
            return;
        }
        this.pointType = PointsStateEnum.Unselected;
        _drawingManager.ActivateOrNotNeighbours(this.X, this.Y, PointsStateEnum.Unselected, "Default");
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
            _drawingManager.ResetPointStates();
            _drawingManager.IsAnyPointClicked = false;
            _drawingManager.FinishPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            _drawingManager.CreatePath(_drawingManager.StartPoint, _drawingManager.FinishPoint);
           //draw the line
        } else if (_drawingManager.IsAnyPointClicked == false)
        {
           this.pointType = PointsStateEnum.Clicked;
           _drawingManager.IsAnyPointClicked = true;
           _spriteChanger.ChangeSprite("Active");
           _drawingManager.StartPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

    private bool IsPlatformLimitReached()
    {
        return _levelManager != null && _levelManager.IsPlatformLimitReached();
    }

}

