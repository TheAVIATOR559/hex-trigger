using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static Vector2Int[] EVEN_ROW_OFFSETS = new Vector2Int[6]
    {
        new Vector2Int(-1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(+1, 0),
        new Vector2Int(0, +1),
        new Vector2Int(-1, +1),
        new Vector2Int(-1, 0)
    };

    public static Vector2Int[] ODD_ROW_OFFSETS = new Vector2Int[6]
    {
        new Vector2Int(0, -1),
        new Vector2Int(+1, -1),
        new Vector2Int(+1, 0),
        new Vector2Int(+1, +1),
        new Vector2Int(0, +1),
        new Vector2Int(-1, 0)
    };

    public static float HEX_X_OFFSET = 0.866f;
    public static float HEX_Y_OFFSET = 0.75f;
}
