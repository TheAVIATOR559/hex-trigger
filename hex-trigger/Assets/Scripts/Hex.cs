using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public static Vector2Int Position;
    public static Vector3 WorldPosition;
    public List<Hex> Neighbors = new List<Hex>();

    public void Initialize(int x, int y)
    {
        Position = new Vector2Int(x, y);
        WorldPosition = transform.position;
    }

    public void AddNeighbor(Hex neighbor)
    {
        Neighbors.Add(neighbor);
    }


}
