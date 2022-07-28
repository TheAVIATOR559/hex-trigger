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

    [SerializeField] GameObject ParticleSystem;
    [SerializeField] Transparent_Mask TransparentMask;

    [SerializeField] GameObject BuildingModel;

    private Material mat;

    public bool IsBuilding = false;
    public bool IsUpgrading = false;

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

        TransparentMask.transform.localScale = new Vector3(0, TransparentMask.transform.localScale.y, 0);
        ScaleModel(0, 1, 0);

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
        if(IsBuilding)
        {
            yield return null;
        }
        IsBuilding = true;

        float currTime = 0;
        float hexTotalTime = Resource_Manager.GetBuildTime(ConnectedBuilding.BuildingType) / 2f;
        float buildingTotalTime = hexTotalTime;
        float elapsedTime;

        //float startTime = Time.time;

        while(currTime < hexTotalTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = (currTime / Mathf.Max(hexTotalTime, 0.0001f));

            mat.SetFloat("_Fill_Rate", elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        currTime = 0;

        while (currTime < buildingTotalTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = currTime / Mathf.Max(hexTotalTime, 0.0001f);

            TransparentMask.SetScale(elapsedTime, TransparentMask.transform.localScale.y, elapsedTime);
            ScaleModel(elapsedTime, 1, elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        currTime = 0;

        while(currTime < 2f)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = 1 - (currTime / Mathf.Max(2f, 0.0001f));

            TransparentMask.SetFillValue(elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //Debug.Log(hexTotalTime + "+" + buildingTotalTime + "+" + 2 + " :: " + (Time.time - startTime + 2));

        ParticleSystem.SetActive(true);
        ConnectedBuilding.Initalize();
        IsBuilding = false;
    }

    private void ForceBuild()
    {
        StopCoroutine(BuildHex());
        mat.SetFloat("_Fill_Rate", 1);
        TransparentMask.SetFillValue(0);
        TransparentMask.SetScale(1, TransparentMask.transform.localScale.y, 1);
        ScaleModel(1, 1, 1);
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

        //if building has been initialized, call determine building tier

        ConnectedBuilding.DetermineBuildingTier();
    }

    public void AddToNeighbors()
    {
        foreach(Hex neighbor in Neighbors)
        {
            neighbor.AddNeighbor(this);
        }
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

    private void EnableModel()
    {
        BuildingModel.SetActive(true);
    }

    private void DisableModel()
    {
        BuildingModel.SetActive(false);
    }

    private void ScaleModel(float x, float y, float z)
    {
        BuildingModel.transform.localScale = new Vector3(x, y, z);
    }

    public void UpdateModel(Enums.Building_Type buildingType)
    {
        if(IsUpgrading)
        {
            return;
        }

        IsUpgrading = true;

        StartCoroutine(UpgradeBuilding(buildingType));

        //GameObject prevModel = BuildingModel;

        //BuildingModel = Instantiate(Prefab_Manager.GetModelPrefab(Enums.BuildingTypeToModelPrefab(buildingType)), BuildingModel.transform.position, Quaternion.Euler(-90, 0, 0), transform);

        //Destroy(prevModel);
    }

    private IEnumerator UpgradeBuilding(Enums.Building_Type type)
    {
        GameObject prevModel = BuildingModel;

        float currTime = 0;
        float buildingTime = Resource_Manager.GetBuildTime(ConnectedBuilding.BuildingType, true) / 4f;
        float elapsedTime;
        float targetScale = Prefab_Manager.GetMaskTargetScale(type);
        //float startTime = Time.time;

        while (currTime < buildingTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = (currTime / Mathf.Max(buildingTime, 0.0001f));

            TransparentMask.SetFillValue(elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        currTime = 0;

        while (currTime < buildingTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = 1 - (currTime / Mathf.Max(buildingTime, 0.0001f));

            ScaleModel(elapsedTime, 1, elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        BuildingModel = Instantiate(Prefab_Manager.GetModelPrefab(Enums.BuildingTypeToModelPrefab(type)), BuildingModel.transform.position, Quaternion.identity, transform);
        ScaleModel(0, 1, 0);

        Destroy(prevModel);

        currTime = 0;

        float currMaskYScale = TransparentMask.transform.localScale.y;

        while (currTime < buildingTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = (currTime / Mathf.Max(buildingTime, 0.0001f));

            if(currMaskYScale < targetScale * elapsedTime)
            {
                TransparentMask.SetScale(1, targetScale * elapsedTime, 1);//could be wonky
            }

            BuildingModel.transform.localPosition = new Vector3(BuildingModel.transform.localPosition.x, Prefab_Manager.GetModelVerticalOffset(type), BuildingModel.transform.localPosition.z);//local doesnt work
            ScaleModel(elapsedTime, elapsedTime, elapsedTime);

            currTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        currTime = 0;

        while (currTime < buildingTime)
        {
            if (Event_Manager.IsGamePaused)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            elapsedTime = 1 - (currTime / Mathf.Max(buildingTime, 0.0001f));

            TransparentMask.SetFillValue(elapsedTime);
            currTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        IsUpgrading = false;
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
