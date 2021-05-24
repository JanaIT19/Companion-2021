using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public int x, y; //array dimensions (can differ from level to level)
    public float Step = 1f;
    public GameObject PointPrefab; //prefab we gonna copy from
    public GameObject PlatformPrefab; //platform prefab to copy 
    public bool IsAnyPointClicked { get; set; } = false;
    public Vector3 StartPoint { get; set; }
    public Vector3 FinishPoint { get; set; }

    private GameObject[,] _grid; //grid of points
    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    void Start()
    {
        _grid = new GameObject[y, x];
        CreateGrid();
    }

    private void CreateGrid()
    {
        float horizontal = 0f;
        float vertical = 0f;
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            vertical = 0f;
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = Instantiate(PointPrefab,new Vector3(vertical, horizontal, 0f), Quaternion.identity );
                _grid[i, j].transform.SetParent(gameObject.transform, false); //referencing object this component is attached to(DrawingManager)
                _grid[i, j].name = "Point " + i + j;
                _grid[i, j].GetComponent<Point>().X = j;
                _grid[i, j].GetComponent<Point>().Y = i;
                vertical += Step;
            }
            horizontal += Step;
        }
    }

    public void ActivateOrNotNeighbours(int xPoint, int yPoint, PointsStateEnum state, string status)
    {
        //[i, j] => [y, x]
        int leftX = xPoint - 1;
        int rigthX = xPoint + 1;
        if (leftX >= 0 )
        {
            _grid[yPoint, leftX].GetComponent<Point>().pointType = state;
            _grid[yPoint, leftX].GetComponent<ChangeSprites>().ChangeSprite(status);
        }

        if (rigthX < this.x )
        {
            _grid[yPoint, rigthX].GetComponent<Point>().pointType = state;
            _grid[yPoint, rigthX].GetComponent<ChangeSprites>().ChangeSprite(status);
        }

        int leftY = yPoint - 1;
        int rigthY = yPoint + 1;
        if (leftY >= 0 )
        {
            _grid[leftY, xPoint].GetComponent<Point>().pointType = state;
            _grid[leftY, xPoint].GetComponent<ChangeSprites>().ChangeSprite(status);
        }

        if (rigthY < this.y )
        {
            _grid[rigthY, xPoint].GetComponent<Point>().pointType = state;
            _grid[rigthY, xPoint].GetComponent<ChangeSprites>().ChangeSprite(status);
        }
        leftX = 0;
        rigthX = 0;
        leftY = 0;
        rigthY = 0;

    }

    public void ResetPointStates()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j].GetComponent<Point>().pointType = PointsStateEnum.Unselected;
                _grid[i, j].GetComponent<ChangeSprites>().ChangeSprite("Default");
            }
        }
    }

    public void CreatePath(Vector3 start, Vector3 end)
    {
        Vector3 newPosition;

        if (end[0] - start[0] > 0.01f  || end[0] - start[0] < -0.01f)  //horizontal platform
        {
            float newXpos = (end[0] - start[0])/2f;
            newPosition = new Vector3(start[0] + newXpos, start[1], 0.01f);
            
            if (CheckIfPathExists(newPosition))
            {
                var platform = Instantiate(PlatformPrefab
        , newPosition, Quaternion.identity);
                float pSize = Step/0.2f;
                platform.GetComponent<SpriteRenderer>().size += new Vector2(platform.GetComponent<SpriteRenderer>().size.x * pSize, 0f);
                platform.GetComponent<BoxCollider2D>().size += new Vector2(platform.GetComponent<BoxCollider2D>().size.x * pSize, 0f);
                _eventManager?.OnPlatformCreated.Invoke();
            }
        }

        if (end[1] - start[1] > 0.01f  || end[1] - start[1] < -0.01f) //vertical platform
        {
            float newYpos = (end[1] - start[1])/2f;
            newPosition = new Vector3(start[0], start[1] + newYpos, 0.01f);
            
            if (CheckIfPathExists(newPosition))
            {
                var platform = Instantiate(PlatformPrefab, newPosition, Quaternion.identity);
                float pSize = Step/0.2f;
                platform.GetComponent<SpriteRenderer>().size += new Vector2(0f, platform.GetComponent<SpriteRenderer>().size.y * pSize);
                platform.GetComponent<BoxCollider2D>().size += new Vector2(0f, platform.GetComponent<BoxCollider2D>().size.y * pSize);
                _eventManager?.OnPlatformCreated.Invoke();
            }
        }
    }

    private bool CheckIfPathExists(Vector3 newPlatformPos) //checking if platfrom is already placed
    {
        GameObject[] platformSet;
        platformSet = GameObject.FindGameObjectsWithTag("RemovablePlatform");
        
        foreach (GameObject platform in platformSet)
        {
            if (platform != null && platform.transform.position == newPlatformPos)
            {
                Debug.Log("Cannot build the platform!");
                return false;
            }
        }
        return true;
    }

}
