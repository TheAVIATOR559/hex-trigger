using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public Vector2Int Position;
    public List<Hex> Neighbors = new List<Hex>();

    public void Initialize(int x, int y)
    {
        Position = new Vector2Int(x, y);
    }

    public void AddNeighbor(Hex neighbor)
    {
        Neighbors.Add(neighbor);
    }

    public static Vector3 GetWorldCoordFromHexCoord(Vector2Int vector)
    {
        float xPos = vector.x * Constants.HEX_X_OFFSET;

        if (IsOnOddRow(vector.y))
        {
            xPos += (Constants.HEX_X_OFFSET / 2f);
        }

        return new Vector3(xPos, 0, vector.y * Constants.HEX_Y_OFFSET);
    }

    public static Vector2Int GetHexCoordFromWorldCoord(Vector3 vector)
    {
        Vector2Int returnValue = new Vector2Int();

        returnValue.y = Mathf.RoundToInt(vector.z / Constants.HEX_Y_OFFSET);

        if (IsOnOddRow(returnValue.y))
        {
            returnValue.x = Mathf.RoundToInt((vector.x / Constants.HEX_X_OFFSET) - (Constants.HEX_X_OFFSET / 2));
        }
        else
        {
            returnValue.x = Mathf.RoundToInt(vector.x / Constants.HEX_X_OFFSET);
        }

        return returnValue;
    }

    public static bool IsOnOddRow(int y)
    {
        return (Mathf.Abs(y) % 2 == 1);
    }
}
