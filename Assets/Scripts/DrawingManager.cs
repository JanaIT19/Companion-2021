using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public int x, y; //array dimensions (can differ from level to level)
    public float step = 1f;
    public GameObject pointPrefab; //prefab we gonna copy from
    public GameObject platformPrefab; //platform prefab to copy 
    private GameObject[,] Grid; //grid of points
    public bool isAnyPointClicked { get; set; } = false;
    public Vector3 startPoint { get; set; }
    public Vector3 finishPoint { get; set; }

    private EventManager _eventManager;

    private void Awake() 
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Grid = new GameObject[y, x];
        CreateGrid();
        Debug.Log(startPoint);
    }

    void CreateGrid()
    {
        float horizontal = 0f;
        float vertical = 0f;
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            vertical = 0f;
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Grid[i, j] = Instantiate(pointPrefab,new Vector3(vertical, horizontal, 0f), Quaternion.identity );
                Grid[i, j].transform.SetParent(gameObject.transform, false); //referencing object this component is attached to(DrawingManager)
                Grid[i, j].name = "Point " + i + j;
                Grid[i, j].GetComponent<Point>().X = j;
                Grid[i, j].GetComponent<Point>().Y = i;
                vertical += step;
            }
            horizontal += step;
        }
    }

    public void ActivateOrNotNeighbours(int xPoint, int yPoint, PointsStateEnum state, Color paint)
    {
        //needs checking if point is enabled???!!!
        //if Grid[yPoint, xPoint]
        //switch 
        //[i, j] => [y, x]
        //Debug.Log("x is: " + this.x + ", y is: " + this.y);
        //Debug.Log("x is: " + xPoint + ", y is: " + yPoint);
        int leftX = xPoint - 1;
        int rigthX = xPoint + 1;
        if (leftX >= 0 )
        {
            Grid[yPoint, leftX].GetComponent<Point>().pointType = state;
            Grid[yPoint, leftX].GetComponent<Point>().ChangeColor(paint);
        }

        if (rigthX < this.x )
        {

            Grid[yPoint, rigthX].GetComponent<Point>().pointType = state;
            Grid[yPoint, rigthX].GetComponent<Point>().ChangeColor(paint);
        }

        int leftY = yPoint - 1;
        int rigthY = yPoint + 1;
        if (leftY >= 0 )
        {
            Grid[leftY, xPoint].GetComponent<Point>().pointType = state;
            Grid[leftY, xPoint].GetComponent<Point>().ChangeColor(paint);
        }

        if (rigthY < this.y )
        {
            Grid[rigthY, xPoint].GetComponent<Point>().pointType = state;
            Grid[rigthY, xPoint].GetComponent<Point>().ChangeColor(paint);
        }
        leftX = 0;
        rigthX = 0;
        leftY = 0;
        rigthY = 0;

    }

    public void ResetPointStates()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Grid[i, j].GetComponent<Point>().pointType = PointsStateEnum.Unselected;
                Grid[i, j].GetComponent<Point>().ChangeColor(Color.white);
            }
        }
    }

    public void CreatePath(Vector3 start, Vector3 end)
    {
        Vector3 newPosition;

        if (end[0] - start[0] > 0.01f  || end[0] - start[0] < -0.01f)  //horizontal platform
        {
            Debug.Log("Horizontal");
            float newXpos = (end[0] - start[0])/2f;
            newPosition = new Vector3(start[0] + newXpos, start[1], 0.01f);
            
            if (CheckIfPathExists(newPosition))
            {
                var platform = Instantiate(platformPrefab, newPosition, Quaternion.identity);
                float pSize = step/0.2f;
                platform.GetComponent<SpriteRenderer>().size += new Vector2(platform.GetComponent<SpriteRenderer>().size.x * pSize, 0f);
                platform.GetComponent<BoxCollider2D>().size += new Vector2(platform.GetComponent<BoxCollider2D>().size.x * pSize, 0f);
                _eventManager?.OnPlatformCreated.Invoke();
            }
        }

        if (end[1] - start[1] > 0.01f  || end[1] - start[1] < -0.01f) //vertical platform
        {
            Debug.Log("Vertical");
            float newYpos = (end[1] - start[1])/2f;
            newPosition = new Vector3(start[0], start[1] + newYpos, 0.01f);
            
            if (CheckIfPathExists(newPosition))
            {
                var platform = Instantiate(platformPrefab, newPosition, Quaternion.identity);
                float pSize = step/0.2f;
                platform.GetComponent<SpriteRenderer>().size += new Vector2(0f, platform.GetComponent<SpriteRenderer>().size.y * pSize);
                platform.GetComponent<BoxCollider2D>().size += new Vector2(0f, platform.GetComponent<BoxCollider2D>().size.y * pSize);
                _eventManager?.OnPlatformCreated.Invoke();
            }
        }


        //https://docs.unity3d.com/ScriptReference/Vector3-operator_eq.html
        //https://docs.unity3d.com/ScriptReference/Vector3.Index_operator.html
        
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
