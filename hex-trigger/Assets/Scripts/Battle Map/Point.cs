using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Point[] neighbors;
    public Vector3 WorldPosition;
    public Vector2Int MapPosition;
    public bool IsOccupied;

    protected Battle_Map Map;

    public virtual void SetUpNeighbors()
    {

    }
}
