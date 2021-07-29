using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Map 
{
    private List<Point> battlePoints;

    public Battle_Map()
    {
        battlePoints = new List<Point>();
    }

    public void AddIntersection(Vector3 worldPosition, Vector2Int mapPosition)
    {
        //if there is no point at(or very near) worldPosition
        battlePoints.Add(new Intersection(worldPosition, mapPosition, this));
    }

    public void AddConnection(Vector3 worldPosition, Vector2Int mapPosition)
    {

    }
}
