using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Manager : Singleton<Prefab_Manager>
{
    private Dictionary<Enums.Prefabs, GameObject> prefabs = new Dictionary<Enums.Prefabs, GameObject>();

    private void Awake()
    {
        /* LOAD PREFABS HERE */
        prefabs.Add(Enums.Prefabs.HEX_GHOST, Resources.Load<GameObject>("Prefabs/Hexes/Ghost Hex"));
        prefabs.Add(Enums.Prefabs.HEX_GOD_SEAT, Resources.Load<GameObject>("Prefabs/Hexes/Hex - God Seat"));

        prefabs.Add(Enums.Prefabs.HEX_GARDEN, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Garden"));
        prefabs.Add(Enums.Prefabs.HEX_FARM, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Farm"));
        prefabs.Add(Enums.Prefabs.HEX_ORCHARD, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Orchard"));
        prefabs.Add(Enums.Prefabs.HEX_RANCH, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Ranch"));
        prefabs.Add(Enums.Prefabs.HEX_HYDROPONICS_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Hydroponics Tower"));

        prefabs.Add(Enums.Prefabs.HEX_HOVEL, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Hovel"));
        prefabs.Add(Enums.Prefabs.HEX_COTTAGE, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Cottage"));
        prefabs.Add(Enums.Prefabs.HEX_APARTMENT, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Apartment"));
        prefabs.Add(Enums.Prefabs.HEX_CONDOMINIUM, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Condo"));
        prefabs.Add(Enums.Prefabs.HEX_VILLA, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Villa"));

        prefabs.Add(Enums.Prefabs.HEX_WORKSHOP, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Workshop"));
        prefabs.Add(Enums.Prefabs.HEX_FORGE, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Forge"));
        prefabs.Add(Enums.Prefabs.HEX_MILL, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Mill"));
        prefabs.Add(Enums.Prefabs.HEX_FOUNDRY, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Foundry"));
        prefabs.Add(Enums.Prefabs.HEX_FACTORY, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Factory"));

        prefabs.Add(Enums.Prefabs.HEX_BARRACKS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Barracks"));
        prefabs.Add(Enums.Prefabs.HEX_DORMITORY, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Dormitory"));
        prefabs.Add(Enums.Prefabs.HEX_GARRISON, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Garrison"));
        prefabs.Add(Enums.Prefabs.HEX_QUARTERS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Quarters"));
        prefabs.Add(Enums.Prefabs.HEX_HEADQUARTERS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Headquarters"));

        prefabs.Add(Enums.Prefabs.HEX_WATCHTOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Watchtower"));
        prefabs.Add(Enums.Prefabs.HEX_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Missile Complex"));
        prefabs.Add(Enums.Prefabs.HEX_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Laser Tower"));
        prefabs.Add(Enums.Prefabs.HEX_AUTO_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Auto Missile Complex"));
        prefabs.Add(Enums.Prefabs.HEX_AUTO_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Auto Laser Tower"));

        prefabs.Add(Enums.Prefabs.HEX_RESEARCH_LAB, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research Lab"));
        prefabs.Add(Enums.Prefabs.HEX_RESEARCH_COLLEGE, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research College"));
        prefabs.Add(Enums.Prefabs.HEX_RESEARCH_INSTITUTE, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research Institute"));
        prefabs.Add(Enums.Prefabs.HEX_MULTIBRAIN_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - MultiBrain Complex"));
        prefabs.Add(Enums.Prefabs.HEX_QUANTUM_BRAIN, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Quantum Brain"));

        prefabs.Add(Enums.Prefabs.HEX_STOCKPILE, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Stockpile"));
        prefabs.Add(Enums.Prefabs.HEX_STOREHOUSE, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Storehouse"));
        prefabs.Add(Enums.Prefabs.HEX_WAREHOUSE, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Warehouse"));
        prefabs.Add(Enums.Prefabs.HEX_DEPOT, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Depot"));
        prefabs.Add(Enums.Prefabs.HEX_DISTRIBUTION_CENTER, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Distribution Center"));

        prefabs.Add(Enums.Prefabs.MODEL_GARDEN, Resources.Load<GameObject>("Prefabs/Models/Food/I"));
        prefabs.Add(Enums.Prefabs.MODEL_FARM, Resources.Load<GameObject>("Prefabs/Models/Food/II"));
        prefabs.Add(Enums.Prefabs.MODEL_ORCHARD, Resources.Load<GameObject>("Prefabs/Models/Food/III"));
        prefabs.Add(Enums.Prefabs.MODEL_RANCH, Resources.Load<GameObject>("Prefabs/Models/Food/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_HYDROPONICS_TOWER, Resources.Load<GameObject>("Prefabs/Models/Food/V"));

        prefabs.Add(Enums.Prefabs.MODEL_HOVEL, Resources.Load<GameObject>("Prefabs/Models/Housing/I"));
        prefabs.Add(Enums.Prefabs.MODEL_COTTAGE, Resources.Load<GameObject>("Prefabs/Models/Housing/II"));
        prefabs.Add(Enums.Prefabs.MODEL_APARTMENT, Resources.Load<GameObject>("Prefabs/Models/Housing/III"));
        prefabs.Add(Enums.Prefabs.MODEL_CONDOMINIUM, Resources.Load<GameObject>("Prefabs/Models/Housing/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_VILLA, Resources.Load<GameObject>("Prefabs/Models/Housing/V"));

        prefabs.Add(Enums.Prefabs.MODEL_WORKSHOP, Resources.Load<GameObject>("Prefabs/Models/Industry/I"));
        prefabs.Add(Enums.Prefabs.MODEL_FORGE, Resources.Load<GameObject>("Prefabs/Models/Industry/II"));
        prefabs.Add(Enums.Prefabs.MODEL_MILL, Resources.Load<GameObject>("Prefabs/Models/Industry/III"));
        prefabs.Add(Enums.Prefabs.MODEL_FOUNDRY, Resources.Load<GameObject>("Prefabs/Models/Industry/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_FACTORY, Resources.Load<GameObject>("Prefabs/Models/Industry/V"));

        prefabs.Add(Enums.Prefabs.MODEL_WATCHTOWER, Resources.Load<GameObject>("Prefabs/Models/Defense/I"));
        prefabs.Add(Enums.Prefabs.MODEL_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Models/Defense/II"));
        prefabs.Add(Enums.Prefabs.MODEL_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Models/Defense/III"));
        prefabs.Add(Enums.Prefabs.MODEL_AUTO_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Models/Defense/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_AUTO_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Models/Defense/V"));

        prefabs.Add(Enums.Prefabs.MODEL_BARRACKS, Resources.Load<GameObject>("Prefabs/Models/Miliary/I"));
        prefabs.Add(Enums.Prefabs.MODEL_DORMITORY, Resources.Load<GameObject>("Prefabs/Models/Military/II"));
        prefabs.Add(Enums.Prefabs.MODEL_GARRISON, Resources.Load<GameObject>("Prefabs/Models/Military/III"));
        prefabs.Add(Enums.Prefabs.MODEL_QUARTERS, Resources.Load<GameObject>("Prefabs/Models/Military/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_HEADQUARTERS, Resources.Load<GameObject>("Prefabs/Models/Military/V"));

        prefabs.Add(Enums.Prefabs.MODEL_RESEARCH_LAB, Resources.Load<GameObject>("Prefabs/Models/Research/I"));
        prefabs.Add(Enums.Prefabs.MODEL_RESEARCH_COLLEGE, Resources.Load<GameObject>("Prefabs/Models/Research/II"));
        prefabs.Add(Enums.Prefabs.MODEL_RESEARCH_INSTITUTE, Resources.Load<GameObject>("Prefabs/Models/Research/III"));
        prefabs.Add(Enums.Prefabs.MODEL_MULTIBRAIN_COMPLEX, Resources.Load<GameObject>("Prefabs/Models/Research/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_QUANTUM_BRAIN, Resources.Load<GameObject>("Prefabs/Models/Research/V"));

        prefabs.Add(Enums.Prefabs.MODEL_STOCKPILE, Resources.Load<GameObject>("Prefabs/Models/Isolium/I"));
        prefabs.Add(Enums.Prefabs.MODEL_STOREHOUSE, Resources.Load<GameObject>("Prefabs/Models/Isolium/II"));
        prefabs.Add(Enums.Prefabs.MODEL_WAREHOUSE, Resources.Load<GameObject>("Prefabs/Models/Isolium/III"));
        prefabs.Add(Enums.Prefabs.MODEL_DEPOT, Resources.Load<GameObject>("Prefabs/Models/Isolium/IV"));
        prefabs.Add(Enums.Prefabs.MODEL_DISTRIBUTION_CENTER, Resources.Load<GameObject>("Prefabs/Models/Isolium/V"));
    }

    public static GameObject GetPrefab(Enums.Prefabs prefab)
    {
        return Instance.prefabs[prefab];
    }
}
