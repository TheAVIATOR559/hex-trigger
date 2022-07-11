using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hex : MonoBehaviour
{
    public Vector2Int Position;
    public List<Hex> Neighbors = new List<Hex>();
    public Building ConnectedBuilding;

    [SerializeField] TMP_Text OverviewTierText;

    [SerializeField] Material standardMaterial;
    [SerializeField] GameObject ParticleSystem;

    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        ConnectedBuilding = GetComponent<Building>();
    }

    public void Initialize(int x, int y, bool forceBuild = false)
    {
        Position = new Vector2Int(x, y);
        City_Manager.Instance.Hexes.Add(Position, this);
        //ConnectedBuilding.Initalize();

        //set shader useHologram to false
        //set shader min fill level to just slightly visible
        mat.SetFloat("_Use_Hologram", 0);
        mat.SetFloat("_Fill_Rate", 0);
        
        if(forceBuild)
        {
            ForceBuild();
        }
        else
        {
            StartCoroutine(BuildHex());
        }
    }

    private IEnumerator BuildHex()
    {
        float currTime = 0;
        float totalTime = Resource_Manager.GetBuildTime(ConnectedBuilding.BuildingType);

        float startTime = Time.time;

        while(currTime < totalTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            mat.SetFloat("_Fill_Rate", (currTime / Mathf.Max(totalTime, 0.0001f)));
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Debug.Log(totalTime + " :: " + (Time.time - startTime));

        ParticleSystem.SetActive(true);
        ConnectedBuilding.Initalize();
    }

    private void ForceBuild()
    {
        StopCoroutine(BuildHex());
        mat.SetFloat("_Fill_Rate", 1);
        ParticleSystem.SetActive(true);
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
        //renderer.material = standardMaterial;
        Debug.Log("GET RID OF ME");
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))
        {
            ///enable and populate hex info panel
            if(ConnectedBuilding.HexType == Enums.Hex_Types.HOUSING)
            {
                Building_Housing housing = (Building_Housing)ConnectedBuilding;
                UI_Manager.UpdateInfoPanel(housing.BuildingType, housing.AdjustedProduction, housing.BonusFromNeighbors, housing.Happiness);
            }
            else
            {
                UI_Manager.UpdateInfoPanel(ConnectedBuilding.BuildingType, ConnectedBuilding.AdjustedProduction, ConnectedBuilding.BonusFromNeighbors);
            }
        
            ///highlight hex
            City_Manager.Instance.MoveHighlighterToHex(this);
        }

        if(Input.GetMouseButtonUp(1))
        {
            ///disable hex info panel
            UI_Manager.DisableInfoPanel();

            ///unhighlight hex
            City_Manager.Instance.UnhighlightHex();
        }
    }

    public void UpdateOverviewTier(Enums.Building_Tier newTier)
    {
        switch (newTier)
        {
            case Enums.Building_Tier.I:
                OverviewTierText.text = "I";
                break;
            case Enums.Building_Tier.II:
                OverviewTierText.text = "II";
                break;
            case Enums.Building_Tier.III:
                OverviewTierText.text = "III";
                break;
            case Enums.Building_Tier.IV:
                OverviewTierText.text = "IV";
                break;
            case Enums.Building_Tier.V:
                OverviewTierText.text = "V";
                break;
            default:
                break;
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

    private static Vector3Int OddRowToCube(Vector2Int point)
    {
        Vector3Int returnValue = new Vector3Int();
        returnValue.x = point.x - (point.y - (point.y & 1)) / 2;
        returnValue.z = point.y;
        returnValue.y = -returnValue.x - returnValue.z;

        return returnValue;
    }

    private static int CubeDistance(Vector3Int a, Vector3Int b)
    {
        return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
    }

    public static int GetDistance(Vector2Int a, Vector2Int b)
    {
        Vector3Int ac = OddRowToCube(a);
        Vector3Int bc = OddRowToCube(b);

        return CubeDistance(ac, bc);
    }

}
