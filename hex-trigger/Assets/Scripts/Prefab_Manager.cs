using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Manager : Singleton<Prefab_Manager>
{
    private Dictionary<Enums.Prefabs, GameObject> prefabs = new Dictionary<Enums.Prefabs, GameObject>();

    private void Awake()
    {
        /* LOAD PREFABS HERE */
        prefabs.Add(Enums.Prefabs.HEX_EMPTY, Resources.Load<GameObject>("Prefabs/Hex - DEFAULT"));
        prefabs.Add(Enums.Prefabs.HEX_GARDEN, Resources.Load<GameObject>("Prefabs/Hex - FOOD PROD"));
        prefabs.Add(Enums.Prefabs.HEX_HOVEL, Resources.Load<GameObject>("Prefabs/Hex - Hovel"));
        prefabs.Add(Enums.Prefabs.HEX_WORKSHOP, Resources.Load<GameObject>("Prefabs/Hex - INDUSTRY"));
        prefabs.Add(Enums.Prefabs.HEX_BARRACKS, Resources.Load<GameObject>("Prefabs/Hex - MILITARY"));
        prefabs.Add(Enums.Prefabs.HEX_RESEARCH_LAB, Resources.Load<GameObject>("Prefabs/Hex - RESEARCH"));
        prefabs.Add(Enums.Prefabs.HEX_STOCKPILE, Resources.Load<GameObject>("Prefabs/Hex - ISOLIUM PROD & STORAGE"));
        prefabs.Add(Enums.Prefabs.HEX_GHOST, Resources.Load<GameObject>("Prefabs/Ghost Hex"));
        prefabs.Add(Enums.Prefabs.HEX_GOD_SEAT, Resources.Load<GameObject>("Prefabs/Hex - God Seat"));
    }

    public static GameObject GetPrefab(Enums.Prefabs prefab)
    {
        return Instance.prefabs[prefab];
    }
}
