using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public Vector2Int Position;
    public List<Hex> Neighbors = new List<Hex>();
    public Building ConnectedBuilding;

    [SerializeField] Material standardMaterial;

    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        ConnectedBuilding = GetComponent<Building>();
    }

    public void Initialize(int x, int y)
    {
        Position = new Vector2Int(x, y);
        City_Manager.Instance.Hexes.Add(Position, this);
        ConnectedBuilding.Initalize();
    }

    public void AddNeighbor(Hex neighbor)
    {
        if(neighbor == this)
        {
            return;
        }

        Neighbors.Add(neighbor);
        ConnectedBuilding.DetermineBuildingTier();
        //ConnectedBuilding.UpdateProductionValue();
    }

    public void AddToNeighbors()
    {
        foreach(Hex neighbor in Neighbors)
        {
            neighbor.AddNeighbor(this);
        }
    }

    public void SetStandardMaterial()
    {
        renderer.material = standardMaterial;
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))
        {
            ///TODO on left click
            ///zoom in on hex

            ///enable and populate hex info panel
            UI_Manager.UpdateInfoPanel(ConnectedBuilding.BuildingType, ConnectedBuilding.AdjustedProduction, ConnectedBuilding.BonusFromNeighbors);
        
            ///highlight hex
            City_Manager.Instance.MoveHighlighterToHex(this);
        }

        if(Input.GetMouseButtonUp(1))
        {
            ///TODO on right click
            ///zoom out to previous camera position

            ///disable hex info panel

            ///unhighlight hex
            City_Manager.Instance.UnhighlightHex();
        }
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
