using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Manager : Singleton<Prefab_Manager>
{
    private Dictionary<Enums.Hex_Prefabs, GameObject> hexes = new Dictionary<Enums.Hex_Prefabs, GameObject>();
    private Dictionary<Enums.Model_Prefabs, GameObject> models = new Dictionary<Enums.Model_Prefabs, GameObject>();
    private Dictionary<Enums.Images, Sprite> images = new Dictionary<Enums.Images, Sprite>();

    private void Awake()
    {
        LoadHexPrefabs();
        LoadModelPrefabs();
        LoadImages();
    }

    //todo remove unbuildable hexes?
    private void LoadHexPrefabs()//TODO add new hexes
    {
        hexes.Add(Enums.Hex_Prefabs.HEX_GHOST, Resources.Load<GameObject>("Prefabs/Hexes/Ghost Hex"));
        hexes.Add(Enums.Hex_Prefabs.HEX_GOD_SEAT, Resources.Load<GameObject>("Prefabs/Hexes/Hex - God Seat"));

        hexes.Add(Enums.Hex_Prefabs.HEX_GARDEN, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Garden"));
        hexes.Add(Enums.Hex_Prefabs.HEX_FARM, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Farm"));
        hexes.Add(Enums.Hex_Prefabs.HEX_ORCHARD, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Orchard"));
        hexes.Add(Enums.Hex_Prefabs.HEX_RANCH, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Ranch"));
        hexes.Add(Enums.Hex_Prefabs.HEX_HYDROPONICS_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Food/Hex - Hydroponics Tower"));

        hexes.Add(Enums.Hex_Prefabs.HEX_HOVEL, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Hovel"));
        hexes.Add(Enums.Hex_Prefabs.HEX_COTTAGE, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Cottage"));
        hexes.Add(Enums.Hex_Prefabs.HEX_APARTMENT, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Apartment"));
        hexes.Add(Enums.Hex_Prefabs.HEX_CONDOMINIUM, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Condo"));
        hexes.Add(Enums.Hex_Prefabs.HEX_VILLA, Resources.Load<GameObject>("Prefabs/Hexes/Housing/Hex - Villa"));

        hexes.Add(Enums.Hex_Prefabs.HEX_WORKSHOP, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Workshop"));
        hexes.Add(Enums.Hex_Prefabs.HEX_FORGE, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Forge"));
        hexes.Add(Enums.Hex_Prefabs.HEX_MILL, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Mill"));
        hexes.Add(Enums.Hex_Prefabs.HEX_FOUNDRY, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Foundry"));
        hexes.Add(Enums.Hex_Prefabs.HEX_FACTORY, Resources.Load<GameObject>("Prefabs/Hexes/Industry/Hex - Factory"));

        hexes.Add(Enums.Hex_Prefabs.HEX_BARRACKS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Barracks"));
        hexes.Add(Enums.Hex_Prefabs.HEX_DORMITORY, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Dormitory"));
        hexes.Add(Enums.Hex_Prefabs.HEX_GARRISON, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Garrison"));
        hexes.Add(Enums.Hex_Prefabs.HEX_QUARTERS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Quarters"));
        hexes.Add(Enums.Hex_Prefabs.HEX_HEADQUARTERS, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Headquarters"));

        hexes.Add(Enums.Hex_Prefabs.HEX_SHOOTING_RANGE, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Shooting Range"));
        hexes.Add(Enums.Hex_Prefabs.HEX_DEFENDERS_WALL, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Defender's Wall"));
        hexes.Add(Enums.Hex_Prefabs.HEX_GUNNERS_ALLEY, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Gunner's Alley"));
        hexes.Add(Enums.Hex_Prefabs.HEX_SNIPER_NEST, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Sniper's Nest"));
        hexes.Add(Enums.Hex_Prefabs.HEX_SCOUT_CAMP, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Scout Camp"));
        hexes.Add(Enums.Hex_Prefabs.HEX_ACES_ARENA, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Ace's Arena"));
        hexes.Add(Enums.Hex_Prefabs.HEX_CANNONEERS_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Cannoneer's Tower"));
        hexes.Add(Enums.Hex_Prefabs.HEX_GUARDIANS_LAST_STAND, Resources.Load<GameObject>("Prefabs/Hexes/Military/Hex - Guardian's Last Stand"));

        hexes.Add(Enums.Hex_Prefabs.HEX_WATCHTOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Watchtower"));
        hexes.Add(Enums.Hex_Prefabs.HEX_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Missile Complex"));
        hexes.Add(Enums.Hex_Prefabs.HEX_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Laser Tower"));
        hexes.Add(Enums.Hex_Prefabs.HEX_AUTO_MISSILE_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Auto Missile Complex"));
        hexes.Add(Enums.Hex_Prefabs.HEX_AUTO_LASER_TOWER, Resources.Load<GameObject>("Prefabs/Hexes/Defense/Hex - Auto Laser Tower"));

        hexes.Add(Enums.Hex_Prefabs.HEX_RESEARCH_LAB, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research Lab"));
        hexes.Add(Enums.Hex_Prefabs.HEX_RESEARCH_COLLEGE, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research College"));
        hexes.Add(Enums.Hex_Prefabs.HEX_RESEARCH_INSTITUTE, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Research Institute"));
        hexes.Add(Enums.Hex_Prefabs.HEX_MULTIBRAIN_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - MultiBrain Complex"));
        hexes.Add(Enums.Hex_Prefabs.HEX_QUANTUM_BRAIN, Resources.Load<GameObject>("Prefabs/Hexes/Research/Hex - Quantum Brain"));

        hexes.Add(Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_I, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Extractor MK I"));
        hexes.Add(Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_II, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Extractor MK II"));
        hexes.Add(Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_III, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Extractor MK III"));
        hexes.Add(Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_IV, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Extractor MK IV"));
        hexes.Add(Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_V, Resources.Load<GameObject>("Prefabs/Hexes/Isolium/Hex - Extractor MK V"));

        hexes.Add(Enums.Hex_Prefabs.HEX_STOCKPILE, Resources.Load<GameObject>("Prefabs/Hexes/Storage/Hex - Stockpile"));
        hexes.Add(Enums.Hex_Prefabs.HEX_STOREHOUSE, Resources.Load<GameObject>("Prefabs/Hexes/Storage/Hex - Storehouse"));
        hexes.Add(Enums.Hex_Prefabs.HEX_WAREHOUSE, Resources.Load<GameObject>("Prefabs/Hexes/Storage/Hex - Warehouse"));
        hexes.Add(Enums.Hex_Prefabs.HEX_DEPOT, Resources.Load<GameObject>("Prefabs/Hexes/Storage/Hex - Depot"));
        hexes.Add(Enums.Hex_Prefabs.HEX_DISTRIBUTION_CENTER, Resources.Load<GameObject>("Prefabs/Hexes/Storage/Hex - Distribution Center"));

        hexes.Add(Enums.Hex_Prefabs.HEX_WATERWHEEL, Resources.Load<GameObject>("Prefabs/Hexes/Power/Hex - Waterwheel Generator"));
        hexes.Add(Enums.Hex_Prefabs.HEX_COAL_FIRED_POWER_PLANT, Resources.Load<GameObject>("Prefabs/Hexes/Power/Hex - Coal-fired Power Plant"));
        hexes.Add(Enums.Hex_Prefabs.HEX_HYDROELECTRIC_DAM, Resources.Load<GameObject>("Prefabs/Hexes/Power/Hex - Hydroelectric Dam"));
        hexes.Add(Enums.Hex_Prefabs.HEX_NUCLEAR_POWER_PLANT, Resources.Load<GameObject>("Prefabs/Hexes/Power/Hex - Nuclear Power Plant"));
        hexes.Add(Enums.Hex_Prefabs.HEX_QUANTUM_POWER_PLANT, Resources.Load<GameObject>("Prefabs/Hexes/Power/Hex - Quantum Power Plant"));

        hexes.Add(Enums.Hex_Prefabs.HEX_PUBLIC_PARK, Resources.Load<GameObject>("Prefabs/Hexes/Entertainment/Hex - Public Park"));
        hexes.Add(Enums.Hex_Prefabs.HEX_CIRCUS, Resources.Load<GameObject>("Prefabs/Hexes/Entertainment/Hex - Circus"));
        hexes.Add(Enums.Hex_Prefabs.HEX_THEATER_COMPLEX, Resources.Load<GameObject>("Prefabs/Hexes/Entertainment/Hex - Theater Complex"));
        hexes.Add(Enums.Hex_Prefabs.HEX_VIRTUAL_REALITY_CAFE, Resources.Load<GameObject>("Prefabs/Hexes/Entertainment/Hex - VR Cafe"));
        hexes.Add(Enums.Hex_Prefabs.HEX_QUANTUM_HOLOGRAM_THEATER, Resources.Load<GameObject>("Prefabs/Hexes/Entertainment/Hex - Quantum Hologram Theater"));
    }

    private void LoadModelPrefabs()//TODO add new models
    {
        models.Add(Enums.Model_Prefabs.MODEL_GARDEN, Resources.Load<GameObject>("Prefabs/Models/Food/I"));
        models.Add(Enums.Model_Prefabs.MODEL_FARM, Resources.Load<GameObject>("Prefabs/Models/Food/II"));
        models.Add(Enums.Model_Prefabs.MODEL_ORCHARD, Resources.Load<GameObject>("Prefabs/Models/Food/III"));
        models.Add(Enums.Model_Prefabs.MODEL_RANCH, Resources.Load<GameObject>("Prefabs/Models/Food/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_HYDROPONICS_TOWER, Resources.Load<GameObject>("Prefabs/Models/Food/V"));

        models.Add(Enums.Model_Prefabs.MODEL_HOVEL, Resources.Load<GameObject>("Prefabs/Models/Housing/I"));
        models.Add(Enums.Model_Prefabs.MODEL_COTTAGE, Resources.Load<GameObject>("Prefabs/Models/Housing/II"));
        models.Add(Enums.Model_Prefabs.MODEL_APARTMENT, Resources.Load<GameObject>("Prefabs/Models/Housing/III"));
        models.Add(Enums.Model_Prefabs.MODEL_CONDOMINIUM, Resources.Load<GameObject>("Prefabs/Models/Housing/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_VILLA, Resources.Load<GameObject>("Prefabs/Models/Housing/V"));

        models.Add(Enums.Model_Prefabs.MODEL_WORKSHOP, Resources.Load<GameObject>("Prefabs/Models/Industry/I"));
        models.Add(Enums.Model_Prefabs.MODEL_FORGE, Resources.Load<GameObject>("Prefabs/Models/Industry/II"));
        models.Add(Enums.Model_Prefabs.MODEL_MILL, Resources.Load<GameObject>("Prefabs/Models/Industry/III"));
        models.Add(Enums.Model_Prefabs.MODEL_FOUNDRY, Resources.Load<GameObject>("Prefabs/Models/Industry/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_FACTORY, Resources.Load<GameObject>("Prefabs/Models/Industry/V"));

        models.Add(Enums.Model_Prefabs.MODEL_BARRACKS, Resources.Load<GameObject>("Prefabs/Models/Miliary/I"));
        models.Add(Enums.Model_Prefabs.MODEL_DORMITORY, Resources.Load<GameObject>("Prefabs/Models/Military/II"));
        models.Add(Enums.Model_Prefabs.MODEL_GARRISON, Resources.Load<GameObject>("Prefabs/Models/Military/III"));
        models.Add(Enums.Model_Prefabs.MODEL_QUARTERS, Resources.Load<GameObject>("Prefabs/Models/Military/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_HEADQUARTERS, Resources.Load<GameObject>("Prefabs/Models/Military/V"));

        models.Add(Enums.Model_Prefabs.MODEL_RESEARCH_LAB, Resources.Load<GameObject>("Prefabs/Models/Research/I"));
        models.Add(Enums.Model_Prefabs.MODEL_RESEARCH_COLLEGE, Resources.Load<GameObject>("Prefabs/Models/Research/II"));
        models.Add(Enums.Model_Prefabs.MODEL_RESEARCH_INSTITUTE, Resources.Load<GameObject>("Prefabs/Models/Research/III"));
        models.Add(Enums.Model_Prefabs.MODEL_MULTIBRAIN_COMPLEX, Resources.Load<GameObject>("Prefabs/Models/Research/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_QUANTUM_BRAIN, Resources.Load<GameObject>("Prefabs/Models/Research/V"));

        models.Add(Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_I, Resources.Load<GameObject>("Prefabs/Models/Isolium/I"));
        models.Add(Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_II, Resources.Load<GameObject>("Prefabs/Models/Isolium/II"));
        models.Add(Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_III, Resources.Load<GameObject>("Prefabs/Models/Isolium/III"));
        models.Add(Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_IV, Resources.Load<GameObject>("Prefabs/Models/Isolium/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_V, Resources.Load<GameObject>("Prefabs/Models/Isolium/V"));

        models.Add(Enums.Model_Prefabs.MODEL_STOCKPILE, Resources.Load<GameObject>("Prefabs/Models/Storage/I"));
        models.Add(Enums.Model_Prefabs.MODEL_STOREHOUSE, Resources.Load<GameObject>("Prefabs/Models/Storage/II"));
        models.Add(Enums.Model_Prefabs.MODEL_WAREHOUSE, Resources.Load<GameObject>("Prefabs/Models/Storage/III"));
        models.Add(Enums.Model_Prefabs.MODEL_DEPOT, Resources.Load<GameObject>("Prefabs/Models/Storage/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_DISTRIBUTION_CENTER, Resources.Load<GameObject>("Prefabs/Models/Storage/V"));

        models.Add(Enums.Model_Prefabs.MODEL_PUBLIC_PARK, Resources.Load<GameObject>("Prefabs/Models/Entertainment/I"));
        models.Add(Enums.Model_Prefabs.MODEL_CIRCUS, Resources.Load<GameObject>("Prefabs/Models/Entertainment/II"));
        models.Add(Enums.Model_Prefabs.MODEL_THEATER_COMPLEX, Resources.Load<GameObject>("Prefabs/Models/Entertainment/III"));
        models.Add(Enums.Model_Prefabs.MODEL_VIRTUAL_REALITY_CAFE, Resources.Load<GameObject>("Prefabs/Models/Entertainment/IV"));
        models.Add(Enums.Model_Prefabs.MODEL_QUANTUM_HOLOGRAM_THEATER, Resources.Load<GameObject>("Prefabs/Models/Entertainment/V"));
    }

    private void LoadImages()//todo load new images
    {
        images.Add(Enums.Images.ICON_GOD_SEAT, Resources.Load<Sprite>("Sprites/God Seat"));
        images.Add(Enums.Images.ICON_FOOD, Resources.Load<Sprite>("Sprites/Food"));
        images.Add(Enums.Images.ICON_POP, Resources.Load<Sprite>("Sprites/Population"));
        images.Add(Enums.Images.ICON_INDUSTRY, Resources.Load<Sprite>("Sprites/Industry"));
        images.Add(Enums.Images.ICON_MILITARY, Resources.Load<Sprite>("Sprites/Military"));
        images.Add(Enums.Images.ICON_RESEARCH, Resources.Load<Sprite>("Sprites/Research"));
        images.Add(Enums.Images.ICON_STORAGE, Resources.Load<Sprite>("Sprites/Storage"));
        images.Add(Enums.Images.ICON_DEFENSE, Resources.Load<Sprite>("Sprites/Defense"));
        images.Add(Enums.Images.ICON_POWER, Resources.Load<Sprite>("Sprites/Power"));
        images.Add(Enums.Images.ICON_GRUNT, Resources.Load<Sprite>("Sprites/Grunt"));
        images.Add(Enums.Images.ICON_SHOOTER, Resources.Load<Sprite>("Sprites/Shooter"));
        images.Add(Enums.Images.ICON_DEFENDER, Resources.Load<Sprite>("Sprites/Defender"));
        images.Add(Enums.Images.ICON_GUNNER, Resources.Load<Sprite>("Sprites/Gunner"));
        images.Add(Enums.Images.ICON_SNIPER, Resources.Load<Sprite>("Sprites/Sniper"));
        images.Add(Enums.Images.ICON_SCOUT, Resources.Load<Sprite>("Sprites/Scout"));
        images.Add(Enums.Images.ICON_ACE, Resources.Load<Sprite>("Sprites/Ace"));
        images.Add(Enums.Images.ICON_CANNONEER, Resources.Load<Sprite>("Sprites/Cannoneer"));
        images.Add(Enums.Images.ICON_GUARDIAN, Resources.Load<Sprite>("Sprites/Guardian"));
        images.Add(Enums.Images.ICON_ISOLIUM, Resources.Load<Sprite>("Sprites/Isolium"));
        images.Add(Enums.Images.ICON_ENTERTAINMENT, Resources.Load<Sprite>("Sprites/Entertainment"));
    }

    public static GameObject GetHexPrefab(Enums.Hex_Prefabs hex)
    {
        return Instance.hexes[hex];
    }

    public static GameObject GetModelPrefab(Enums.Model_Prefabs model)
    {
        return Instance.models[model];
    }

    public static Sprite GetImage(Enums.Images image)
    {
        return Instance.images[image];
    }
}
