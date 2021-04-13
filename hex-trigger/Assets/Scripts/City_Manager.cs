using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Manager : Singleton<City_Manager>
{
    public Dictionary<Vector2Int, Hex> Hexes = new Dictionary<Vector2Int, Hex>();

    private int hexRange = 6;

    private void Awake()
    {
        CreateHexGrid();
    }

    private void CreateHexGrid()
    {
        for (int i = 0; i < hexRange; i++)
        {
            for (int j = 0; j < hexRange; j++)
            {
                float xPos = i * Constants.HEX_X_OFFSET;

                if (j % 2 == 1)
                {
                    xPos += (Constants.HEX_X_OFFSET / 2f);
                }

                Hex newHex = Instantiate(Prefab_Manager.GetPrefab(Enums.Prefabs.HEX_BASIC), new Vector3(xPos, 0, j * Constants.HEX_Y_OFFSET), Quaternion.Euler(-90, 0, 0)).GetComponent<Hex>();
                Hexes.Add(new Vector2Int(i, j), newHex.GetComponent<Hex>());
                newHex.Initialize(i, j);
            }
        }
    }
}
