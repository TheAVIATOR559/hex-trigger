using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class City_Underside : MonoBehaviour
{
    //irregular grid stuff
    [SerializeField] private List<GameObject> edgeHexes = new List<GameObject>();
    private Dictionary<Vector3, int> edgePoints = new Dictionary<Vector3, int>();

    private void Start()
    {
        foreach(GameObject edgeHex in edgeHexes)
        {
            foreach(Transform child in edgeHex.transform)
            {
                AddNewEdgePoint(child.position);
            }
        }

        ClearInteriorPoints();
    }

    private void AddNewEdgePoint(Vector3 newPoint)
    {
        //if edgePoints does not contain a point near enough to argument
        // add it to the list
        foreach(KeyValuePair<Vector3, int> kvp in edgePoints)
        {
            if(IsNearEnough(kvp.Key, newPoint))//if any point has 2 other similar points, ignore it
            {
                edgePoints[kvp.Key]++;
                return;
            }
        }

        edgePoints.Add(newPoint, 0);
    }

    private void ClearInteriorPoints()
    {
        //Debug.Log(edgePoints.Count);

        foreach(KeyValuePair<Vector3, int> item in edgePoints.Where(kvp => kvp.Value >= 2).ToList())
        {
            edgePoints.Remove(item.Key);
        }

        //Debug.Log(edgePoints.Count);
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
        foreach (KeyValuePair<Vector3, int> kvp in edgePoints)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(kvp.Key, 0.01f);
        }
    }
}
