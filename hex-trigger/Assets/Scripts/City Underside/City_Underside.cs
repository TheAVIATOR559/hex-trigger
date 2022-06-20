using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class City_Underside : MonoBehaviour
{
    //irregular grid stuff
    [SerializeField] private List<GameObject> edgeHexes = new List<GameObject>();
    private List<Underside_Point> edgePoints = new List<Underside_Point>();
    private List<Underside_Point> interiorPoints = new List<Underside_Point>();

    private void Start()
    {
        foreach(GameObject edgeHex in edgeHexes)
        {
            CreateNewUndersidePoints(edgeHex.transform);
        }

        AddInteriorPoints();
    }

    private void CreateNewUndersidePoints(Transform hex)
    {
        Underside_Point[] newPoints = new Underside_Point[6]
        {
            new Underside_Point(hex.GetChild(0).position),
            new Underside_Point(hex.GetChild(1).position),
            new Underside_Point(hex.GetChild(2).position),
            new Underside_Point(hex.GetChild(3).position),
            new Underside_Point(hex.GetChild(4).position),
            new Underside_Point(hex.GetChild(5).position),
        };

        newPoints[0].AddNeighbor(newPoints[2]);
        newPoints[0].AddNeighbor(newPoints[5]);
        newPoints[0].oppositePoint = newPoints[1];

        newPoints[1].AddNeighbor(newPoints[3]);
        newPoints[1].AddNeighbor(newPoints[4]);
        newPoints[1].oppositePoint = newPoints[0];

        newPoints[2].AddNeighbor(newPoints[4]);
        newPoints[2].AddNeighbor(newPoints[0]);
        newPoints[2].oppositePoint = newPoints[3];

        newPoints[3].AddNeighbor(newPoints[5]);
        newPoints[3].AddNeighbor(newPoints[1]);
        newPoints[3].oppositePoint = newPoints[2];

        newPoints[4].AddNeighbor(newPoints[1]);
        newPoints[4].AddNeighbor(newPoints[2]);
        newPoints[4].oppositePoint = newPoints[5];

        newPoints[5].AddNeighbor(newPoints[0]);
        newPoints[5].AddNeighbor(newPoints[3]);
        newPoints[5].oppositePoint = newPoints[4];

        edgePoints.AddRange(newPoints);
    }

    private void RemoveDuplicateEdgePoints()
    {
        //if edgePoints does not contain a point near enough to argument
        // add it to the list
        for(int i = 0; i < edgePoints.Count; i++)
        {
            //sort points by distance from inital point

            List<Underside_Point> pointsToDelete = new List<Underside_Point>();

            for (int j = i + 1; j < edgePoints.Count; j++)
            {
                if(IsNearEnough(edgePoints[i].Position, edgePoints[j].Position))
                {
                    edgePoints[i].MergePoints(edgePoints[j]);
                    pointsToDelete.Add(edgePoints[j]);
                }
            }

            foreach(Underside_Point point in pointsToDelete)
            {
                edgePoints.Remove(point);
            }

            edgePoints.Clear();
        }
    }

    private void AddInteriorPoints()
    {
        foreach(Underside_Point point in edgePoints)
        {
            Vector3 endPoint = new Vector3((point.oppositePoint.Position.x + point.neighbors[0].oppositePoint.Position.x) / 2, point.Position.y, (point.oppositePoint.Position.z + point.neighbors[0].oppositePoint.Position.z) / 2);

            Underside_Point newPoint = new Underside_Point((point.Position + point.neighbors[0].Position + endPoint) / 3);
            newPoint.AddNeighbor(point);
            newPoint.AddNeighbor(point.neighbors[0]);
            interiorPoints.Add(newPoint);
        }
    }

    private static float COMPARISON_TOLERANCE = 0.01f;
    private bool IsNearEnough(Vector3 a, Vector3 b)
    {
        if (Mathf.Abs(a.x - b.x) <= COMPARISON_TOLERANCE
            && Mathf.Abs(a.y - b.y) <= COMPARISON_TOLERANCE
            && Mathf.Abs(a.z - b.z) <= COMPARISON_TOLERANCE)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Underside_Point point in edgePoints)
        {
            foreach (Underside_Point neighbor in point.neighbors)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(point.Position, neighbor.Position);
            }

            Gizmos.color = Color.black;
            Gizmos.DrawSphere(point.Position, 0.01f);
        }

        foreach (Underside_Point point in interiorPoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point.Position, 0.01f);

            foreach (Underside_Point neighbor in point.neighbors)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(point.Position, neighbor.Position);
            }
        }
    }
}
