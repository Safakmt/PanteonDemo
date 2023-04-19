using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Grid<T>
{

    //public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    //public class OnGridValueChangedEventArgs : EventArgs
    //{
    //    public int x, y;
    //}

    private int width, height;
    private T[,] gridArr;
    private GameObject obj;
    private int cellSize;
    private Vector2 origin;
    public Grid(int width,int height, int cellSize, Vector2 origin, Func<Grid<T>,int,int,T> createGridObj){

        gridArr = new T[width,height];
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        for (int x = 0; x < gridArr.GetLength(0); x++)
        {
            for (int y = 0; y < gridArr.GetLength(1); y++)
            {
                gridArr[x, y] = createGridObj(this,x,y);
            }
        }

        DrawGridGizmos();
    }
    
    public Vector2 GetWorldPos(int x, int y)
    {
        return new Vector2(x, y) * cellSize + origin;
    }

    public Vector2Int GetXY(Vector2 worldPos)
    {
        int x = Mathf.FloorToInt((worldPos - origin).x / cellSize);
        int y = Mathf.FloorToInt((worldPos - origin).y / cellSize);

        return new Vector2Int(x, y);
    }


    public void SetValue(Vector2 worldPos, T value)
    {
        Vector2Int gridPos = GetXY(worldPos);
        if (gridPos.x >= 0 && gridPos.y >= 0 && gridPos.x < width && gridPos.y < height)
            gridArr[gridPos.x, gridPos.y] = value;

        
        
    }

    public T GetValue(Vector2 mousePos)
    {
        
        Vector2Int gridPos = GetXY(mousePos);

        if (gridPos.x >= 0 && gridPos.y >= 0 && gridPos.x < width && gridPos.y < height)
        {
            return gridArr[gridPos.x, gridPos.y];
        } else
            return default;
    }

    public T GetValue(int x,int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArr[x, y];
        }
        else
            return default;
    }

    private void DrawGridGizmos()
    {
        for (int x = 0; x < gridArr.GetLength(0); x++)
        {

            for (int y = 0; y < gridArr.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x, y + 1), Color.black, 100f);
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x + 1, y), Color.black, 100f);
            }
        }

        Debug.DrawLine(GetWorldPos(0, height), GetWorldPos(width, height), Color.black, 100f);
        Debug.DrawLine(GetWorldPos(width, 0), GetWorldPos(width, height), Color.black, 100f);

        //for (int y = 0; y < gridArr.GetLength(1); y++)
        //{
        //    for (int x = 0; x < gridArr.GetLength(0); x++)
        //    {
        //        Debug.Log(x + "," + y + " is " + gridArr[x, y]);
        //    }
        //}
    }
}
