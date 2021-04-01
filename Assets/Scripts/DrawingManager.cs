using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public int x, y; //array dimensions (can differ from level to level)
    public float step = 1f;
    public GameObject pointPrefab; //prefab we gonna copy from
    public GameObject[,] Grid; //grid of points
    public bool isAnyPointClicked { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        Grid = new GameObject[y, x];
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("x is: " + this.x + ", y is: " + this.y);
        Debug.Log("x is: " + xPoint + ", y is: " + yPoint);
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

}
