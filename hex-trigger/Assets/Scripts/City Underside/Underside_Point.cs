using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underside_Point
{
    public List<Underside_Point> neighbors = new List<Underside_Point>();

    public Underside_Point oppositePoint;

    public Vector3 Position;

    public Underside_Point(Vector3 position)
    {
        Position = position;
    }

    public void AddNeighbor(Underside_Point newNeighbor)
    {
        if(!this.neighbors.Contains(newNeighbor))
        {
            neighbors.Add(newNeighbor);
        }
    }

    public void RemoveNeighbor(Underside_Point neighbor)
    {
        if(this.neighbors.Contains(neighbor))
        {
            neighbors.Remove(neighbor);
        }
    }
    
    public void MergePoints(Underside_Point other)
    {
        foreach(Underside_Point point in other.neighbors)
        {
            AddNeighbor(point);
            point.AddNeighbor(this);
            point.RemoveNeighbor(other);
        }
    }
}
