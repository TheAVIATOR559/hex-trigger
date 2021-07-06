using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Manager : Singleton<City_Manager>
{
    public Dictionary<Vector2Int, Hex> Hexes = new Dictionary<Vector2Int, Hex>();
    public List<Vector2Int> availbleHexPositions = new List<Vector2Int>();

    private int hexRange = 1;
    private List<Ghost_Hex> ghostHexes = new List<Ghost_Hex>();

    public Hex_Blueprint hexBlueprint;
    public Hex_Highlighter hexHighlight;

    private Hex GodSeat;

    private void Awake()
    {
        CreateHexGrid();

        foreach(KeyValuePair<Vector2Int, Hex> kvp in Hexes)
        {
            SetupNeighbors(kvp.Value);
        }

        UpdateAvialableHexPositions();
    }

    private void CreateHexGrid()
    {
        for (int i = -hexRange; i <= hexRange; i++)
        {
            for (int j = -hexRange; j <= hexRange; j++)
            {
                float xPos = i * Constants.HEX_X_OFFSET;

                if (Mathf.Abs(j) % 2 == 1)
                {
                    xPos += (Constants.HEX_X_OFFSET / 2f);
                }

                Hex newHex;

                if (i == 0 && j == 0)
                {
                    newHex = Instantiate(Prefab_Manager.GetPrefab(Enums.Prefabs.HEX_GOD_SEAT), new Vector3(xPos, 0, j * Constants.HEX_Y_OFFSET), Quaternion.Euler(-90, 0, 0)).GetComponent<Hex>();
                }
                else
                {
                    newHex = Instantiate(Prefab_Manager.GetPrefab(Enums.Prefabs.HEX_WATCHTOWER), new Vector3(xPos, 0, j * Constants.HEX_Y_OFFSET), Quaternion.Euler(-90, 0, 0)).GetComponent<Hex>();
                }

                newHex.Initialize(i, j);
                newHex.SetStandardMaterial();
            }
        }
    }

    public static void SetupNeighbors(Hex centerHex)
    {
        if(Hex.IsOnOddRow(centerHex.Position.y)) //odd row offset
        {
            foreach(Vector2Int offset in Constants.ODD_ROW_OFFSETS)
            {
                if(Instance.Hexes.ContainsKey(offset + centerHex.Position))
                {
                    centerHex.AddNeighbor(Instance.Hexes[offset + centerHex.Position]);
                }
            }
        }
        else //even row offset
        {
            foreach (Vector2Int offset in Constants.EVEN_ROW_OFFSETS)
            {
                if (Instance.Hexes.ContainsKey(offset + centerHex.Position))
                {
                    centerHex.AddNeighbor(Instance.Hexes[offset + centerHex.Position]);
                }
            }
        }
    }

    public static Hex GetHex(Vector2Int gridPos)
    {
        if(Instance.Hexes.ContainsKey(gridPos))
        {
            return Instance.Hexes[gridPos];
        }
        else
        {
            return null;
        }
    }

    public static Hex GetHex(Vector3 worldPosition)
    {
        Vector2Int gridPos = new Vector2Int();

        gridPos.y = Mathf.RoundToInt(worldPosition.z / Constants.HEX_Y_OFFSET);

        if(Hex.IsOnOddRow(gridPos.y))
        {
            gridPos.x = Mathf.RoundToInt((worldPosition.x / Constants.HEX_X_OFFSET) - (Constants.HEX_X_OFFSET / 2));
        }
        else
        {
            gridPos.x = Mathf.RoundToInt(worldPosition.x / Constants.HEX_X_OFFSET);
        }

        return GetHex(gridPos);
    }

    public void UpdateAvialableHexPositions()
    {
        availbleHexPositions.Clear();

        foreach(KeyValuePair<Vector2Int, Hex> kvp in Hexes)
        {
            if(kvp.Value.Neighbors.Count >= 6)
            {
                continue;
            }
            else
            {
                if(Hex.IsOnOddRow(kvp.Value.Position.y)) //odd row offset
                {
                    foreach(Vector2Int vector in Constants.ODD_ROW_OFFSETS)
                    {
                        if (!kvp.Value.Neighbors.Contains(GetHex(vector + kvp.Value.Position)))// && !availbleHexPositions.Contains(vector + kvp.Value.Position))
                        {
                            //Debug.Log("Valid new hex location");
                            if(Hex.GetDistance(GodSeat.Position, vector + kvp.Value.Position) <= Resource_Manager.Instance.MaximumHexRange)
                            {
                                availbleHexPositions.Add(vector + kvp.Value.Position);
                            }
                        }
                    }
                }
                else // even row offsets
                {
                    foreach (Vector2Int vector in Constants.EVEN_ROW_OFFSETS)
                    {
                        if (!kvp.Value.Neighbors.Contains(GetHex(vector + kvp.Value.Position)))// && !availbleHexPositions.Contains(vector + kvp.Value.Position))
                        {
                            //Debug.Log("Valid new hex location");
                            if (Hex.GetDistance(GodSeat.Position, vector + kvp.Value.Position) <= Resource_Manager.Instance.MaximumHexRange)
                            {
                                availbleHexPositions.Add(vector + kvp.Value.Position);
                            }
                        }
                    }
                }
            }
        }
    }

    public static void ActivateAvailableHexHighlights()
    {
        foreach(Vector2Int position in Instance.availbleHexPositions)
        {
            Ghost_Hex newGhost = Instantiate(Prefab_Manager.GetPrefab(Enums.Prefabs.HEX_GHOST), Hex.GetWorldCoordFromHexCoord(position), Quaternion.Euler(-90, 0, 0)).GetComponent<Ghost_Hex>();
            newGhost.hexCoord = position;
            Instance.ghostHexes.Add(newGhost);
        }
    }

    public static void DisableAvailableHexHighlights()
    {
        foreach(Ghost_Hex hex in Instance.ghostHexes)
        {
            hex.Destroy();
        }

        Instance.ghostHexes.Clear();
    }

    public void MoveHighlighterToHex(Hex hex)
    {
        hexHighlight.gameObject.SetActive(true);
        hexHighlight.MoveToHex(hex);
    }

    public void UnhighlightHex()
    {
        hexHighlight.gameObject.SetActive(false);
    }

    public static void SetGodSeat(Hex godSeat)
    {
        Instance.GodSeat = godSeat;
    }
}
