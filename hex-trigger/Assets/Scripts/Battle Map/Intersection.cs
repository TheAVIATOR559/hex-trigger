using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : Point
{
    public Intersection(Vector3 worldPosition, Vector2Int mapPosition, Battle_Map map)
    {
        WorldPosition = worldPosition;
        MapPosition = mapPosition;
        IsOccupied = false;
        neighbors = new Point[3];
        Map = map;
    }
}
