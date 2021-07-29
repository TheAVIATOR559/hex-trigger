using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : Point
{
    public Connection(Vector3 worldPosition, Vector2Int mapPosition, Battle_Map map)
    {
        WorldPosition = worldPosition;
        MapPosition = mapPosition;
        IsOccupied = false;
        neighbors = new Point[2];
        Map = map;
    }
}
