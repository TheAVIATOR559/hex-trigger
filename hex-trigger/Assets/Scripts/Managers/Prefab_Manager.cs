using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Prefab_Manager : Singleton<Prefab_Manager> 
{
    private Dictionary<Enums.Hex_Prefabs, GameObject> hexes = new Dictionary<Enums.Hex_Prefabs, GameObject>();
    private Dictionary<Enums.Model_Prefabs, GameObject> models = new Dictionary<Enums.Model_Prefabs, GameObject>();
    private Dictionary<Enums.Images, Sprite> images = new Dictionary<Enums.Images, Sprite>();

    private bool AllAssetsLoaded = false;

    public static void LoadAssets(System.Action callback, TMPro.TMP_Text loadingText = null)
    {
        if(!Instance.AllAssetsLoaded)
        {
            Instance.StartCoroutine(Instance.BeginAssetLoad(callback, loadingText));
        }
    }

    // remove unbuildable hexes?
    private IEnumerator BeginAssetLoad(System.Action callback, TMPro.TMP_Text loadingText)
    {
        Debug.Log("Starting Load Hexes");

        foreach (Enums.Hex_Prefabs hex in System.Enum.GetValues(typeof(Enums.Hex_Prefabs)))
        {
            AsyncOperationHandle<GameObject> opHandle;

            opHandle = Addressables.LoadAssetAsync<GameObject>(HexPrefabToAddress(hex));
            loadingText.text = HexPrefabToAddress(hex).ToString();
            yield return opHandle;

            if (opHandle.Status == AsyncOperationStatus.Succeeded)
            {
                //Debug.Log("Successfully loaded " + opHandle.Result.name);
                hexes.Add(hex, opHandle.Result);
            }
            else if (opHandle.Status == AsyncOperationStatus.Failed)
            {
                Debug.LogError("Failed to load " + hex.ToString());
            }
        }

        Debug.Log("Finished Load Hexes");

        Debug.Log("Starting Load Models");

        foreach (Enums.Model_Prefabs model in System.Enum.GetValues(typeof(Enums.Model_Prefabs)))
        {
            AsyncOperationHandle<GameObject> opHandle;

            opHandle = Addressables.LoadAssetAsync<GameObject>(ModelPrefabToAddress(model));
            loadingText.text = ModelPrefabToAddress(model).ToString();
            yield return opHandle;

            if (opHandle.Status == AsyncOperationStatus.Succeeded)
            {
                //Debug.Log("Successfully loaded " + opHandle.Result.name);
                models.Add(model, opHandle.Result);
            }
            else if (opHandle.Status == AsyncOperationStatus.Failed)
            {
                Debug.LogError("Failed to load " + model.ToString());
            }
        }

        Debug.Log("Finished Load Model");

        Debug.Log("Starting Load Images");

        foreach (Enums.Images image in System.Enum.GetValues(typeof(Enums.Images)))
        {
            AsyncOperationHandle<Sprite> opHandle;

            opHandle = Addressables.LoadAssetAsync<Sprite>(ImageToAddress(image));
            loadingText.text = ImageToAddress(image).ToString();
            yield return opHandle;

            if (opHandle.Status == AsyncOperationStatus.Succeeded)
            {
                //Debug.Log("Successfully loaded " + opHandle.Result.name);
                images.Add(image, opHandle.Result);
            }
            else if (opHandle.Status == AsyncOperationStatus.Failed)
            {
                Debug.LogError("Failed to load " + image.ToString());
            }
        }

        Debug.Log("Finished Load Image");

        Debug.Log("All Assets Successfully Loaded");
        AllAssetsLoaded = true;

        callback();
    }

    public static void UnLoadAssets(System.Action callback, TMPro.TMP_Text loadingText = null)
    {
        if (Instance.AllAssetsLoaded)
        {
            Instance.StartCoroutine(Instance.BeginAssetUnLoad(callback, loadingText));
        }
    }

    private IEnumerator BeginAssetUnLoad(System.Action callback, TMPro.TMP_Text loadingText)
    {
        foreach(KeyValuePair<Enums.Hex_Prefabs, GameObject> hex in hexes)
        {
            loadingText.text = "Unloading " + hex.Key;
            Addressables.Release(hex.Value);
            
            yield return new WaitForEndOfFrame();
        }

        hexes.Clear();

        foreach (KeyValuePair<Enums.Model_Prefabs, GameObject> model in models)
        {
            loadingText.text = "Unloading " + model.Key;
            Addressables.Release(model.Value);

            yield return new WaitForEndOfFrame();
        }

        models.Clear();

        foreach (KeyValuePair<Enums.Images, Sprite> image in images)
        {
            loadingText.text = "Unloading " + image.Key;
            Addressables.Release(image.Value);

            yield return new WaitForEndOfFrame();
        }

        images.Clear();

        AllAssetsLoaded = false;

        callback();
    }

    private string HexPrefabToAddress(Enums.Hex_Prefabs hex)
    {
        switch (hex)
        {
            case Enums.Hex_Prefabs.HEX_GHOST:
                return "Prefabs/Hexes/Ghost Hex";
            case Enums.Hex_Prefabs.HEX_GOD_SEAT:
                return "Prefabs/Hexes/Hex - God Seat";
            case Enums.Hex_Prefabs.HEX_GARDEN:
                return "Prefabs/Hexes/Food/Hex - Garden";
            case Enums.Hex_Prefabs.HEX_FARM:
                return "Prefabs/Hexes/Food/Hex - Farm";
            case Enums.Hex_Prefabs.HEX_ORCHARD:
                return "Prefabs/Hexes/Food/Hex - Orchard";
            case Enums.Hex_Prefabs.HEX_RANCH:
                return "Prefabs/Hexes/Food/Hex - Ranch";
            case Enums.Hex_Prefabs.HEX_HYDROPONICS_TOWER:
                return "Prefabs/Hexes/Food/Hex - Hydroponics Tower";
            case Enums.Hex_Prefabs.HEX_HOVEL:
                return "Prefabs/Hexes/Housing/Hex - Hovel";
            case Enums.Hex_Prefabs.HEX_COTTAGE:
                return "Prefabs/Hexes/Housing/Hex - Cottage";
            case Enums.Hex_Prefabs.HEX_APARTMENT:
                return "Prefabs/Hexes/Housing/Hex - Apartment";
            case Enums.Hex_Prefabs.HEX_CONDOMINIUM:
                return "Prefabs/Hexes/Housing/Hex - Condo";
            case Enums.Hex_Prefabs.HEX_VILLA:
                return "Prefabs/Hexes/Housing/Hex - Villa";
            case Enums.Hex_Prefabs.HEX_WORKSHOP:
                return "Prefabs/Hexes/Industry/Hex - Workshop";
            case Enums.Hex_Prefabs.HEX_FORGE:
                return "Prefabs/Hexes/Industry/Hex - Forge";
            case Enums.Hex_Prefabs.HEX_MILL:
                return "Prefabs/Hexes/Industry/Hex - Mill";
            case Enums.Hex_Prefabs.HEX_FOUNDRY:
                return "Prefabs/Hexes/Industry/Hex - Foundry";
            case Enums.Hex_Prefabs.HEX_FACTORY:
                return "Prefabs/Hexes/Industry/Hex - Factory";
            case Enums.Hex_Prefabs.HEX_BARRACKS:
                return "Prefabs/Hexes/Military/Hex - Barracks";
            case Enums.Hex_Prefabs.HEX_DORMITORY:
                return "Prefabs/Hexes/Military/Hex - Dormitory";
            case Enums.Hex_Prefabs.HEX_GARRISON:
                return "Prefabs/Hexes/Military/Hex - Garrison";
            case Enums.Hex_Prefabs.HEX_QUARTERS:
                return "Prefabs/Hexes/Military/Hex - Quarters";
            case Enums.Hex_Prefabs.HEX_HEADQUARTERS:
                return "Prefabs/Hexes/Military/Hex - Headquarters";
            case Enums.Hex_Prefabs.HEX_WATCHTOWER:
                return "Prefabs/Hexes/Defense/Hex - Watchtower";
            case Enums.Hex_Prefabs.HEX_MISSILE_COMPLEX:
                return "Prefabs/Hexes/Defense/Hex - Missile Complex";
            case Enums.Hex_Prefabs.HEX_LASER_TOWER:
                return "Prefabs/Hexes/Defense/Hex - Laser Tower";
            case Enums.Hex_Prefabs.HEX_AUTO_MISSILE_COMPLEX:
                return "Prefabs/Hexes/Defense/Hex - Auto Missile Complex";
            case Enums.Hex_Prefabs.HEX_AUTO_LASER_TOWER:
                return "Prefabs/Hexes/Defense/Hex - Auto Laser Tower";
            case Enums.Hex_Prefabs.HEX_RESEARCH_LAB:
                return "Prefabs/Hexes/Research/Hex - Research Lab";
            case Enums.Hex_Prefabs.HEX_RESEARCH_COLLEGE:
                return "Prefabs/Hexes/Research/Hex - Research College";
            case Enums.Hex_Prefabs.HEX_RESEARCH_INSTITUTE:
                return "Prefabs/Hexes/Research/Hex - Research Institute";
            case Enums.Hex_Prefabs.HEX_MULTIBRAIN_COMPLEX:
                return "Prefabs/Hexes/Research/Hex - MultiBrain Complex";
            case Enums.Hex_Prefabs.HEX_QUANTUM_BRAIN:
                return "Prefabs/Hexes/Research/Hex - Quantum Brain";
            case Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_I:
                return "Prefabs/Hexes/Isolium/Hex - Extractor MK I";
            case Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_II:
                return "Prefabs/Hexes/Isolium/Hex - Extractor MK II";
            case Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_III:
                return "Prefabs/Hexes/Isolium/Hex - Extractor MK III";
            case Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_IV:
                return "Prefabs/Hexes/Isolium/Hex - Extractor MK IV";
            case Enums.Hex_Prefabs.HEX_EXTRACTOR_MK_V:
                return "Prefabs/Hexes/Isolium/Hex - Extractor MK V";
            case Enums.Hex_Prefabs.HEX_STOCKPILE:
                return "Prefabs/Hexes/Storage/Hex - Stockpile";
            case Enums.Hex_Prefabs.HEX_STOREHOUSE:
                return "Prefabs/Hexes/Storage/Hex - Storehouse";
            case Enums.Hex_Prefabs.HEX_WAREHOUSE:
                return "Prefabs/Hexes/Storage/Hex - Warehouse";
            case Enums.Hex_Prefabs.HEX_DEPOT:
                return "Prefabs/Hexes/Storage/Hex - Depot";
            case Enums.Hex_Prefabs.HEX_DISTRIBUTION_CENTER:
                return "Prefabs/Hexes/Storage/Hex - Distribution Center";
            case Enums.Hex_Prefabs.HEX_SHOOTING_RANGE:
                return "Prefabs/Hexes/Military/Hex - Shooting Range";
            case Enums.Hex_Prefabs.HEX_DEFENDERS_WALL:
                return "Prefabs/Hexes/Military/Hex - Defender's Wall";
            case Enums.Hex_Prefabs.HEX_GUNNERS_ALLEY:
                return "Prefabs/Hexes/Military/Hex - Gunner's Alley";
            case Enums.Hex_Prefabs.HEX_SNIPER_NEST:
                return "Prefabs/Hexes/Military/Hex - Sniper's Nest";
            case Enums.Hex_Prefabs.HEX_SCOUT_CAMP:
                return "Prefabs/Hexes/Military/Hex - Scout Camp";
            case Enums.Hex_Prefabs.HEX_ACES_ARENA:
                return "Prefabs/Hexes/Military/Hex - Ace's Arena";
            case Enums.Hex_Prefabs.HEX_CANNONEERS_TOWER:
                return "Prefabs/Hexes/Military/Hex - Cannoneer's Tower";
            case Enums.Hex_Prefabs.HEX_GUARDIANS_LAST_STAND:
                return "Prefabs/Hexes/Military/Hex - Guardian's Last Stand";
            case Enums.Hex_Prefabs.HEX_WATERWHEEL:
                return "Prefabs/Hexes/Power/Hex - Waterwheel Generator";
            case Enums.Hex_Prefabs.HEX_COAL_FIRED_POWER_PLANT:
                return "Prefabs/Hexes/Power/Hex - Coal-fired Power Plant";
            case Enums.Hex_Prefabs.HEX_HYDROELECTRIC_DAM:
                return "Prefabs/Hexes/Power/Hex - Hydroelectric Dam";
            case Enums.Hex_Prefabs.HEX_NUCLEAR_POWER_PLANT:
                return "Prefabs/Hexes/Power/Hex - Nuclear Power Plant";
            case Enums.Hex_Prefabs.HEX_QUANTUM_POWER_PLANT:
                return "Prefabs/Hexes/Power/Hex - Quantum Power Plant";
            case Enums.Hex_Prefabs.HEX_PUBLIC_PARK:
                return "Prefabs/Hexes/Entertainment/Hex - Public Park";
            case Enums.Hex_Prefabs.HEX_CIRCUS:
                return "Prefabs/Hexes/Entertainment/Hex - Circus";
            case Enums.Hex_Prefabs.HEX_THEATER_COMPLEX:
                return "Prefabs/Hexes/Entertainment/Hex - Theater Complex";
            case Enums.Hex_Prefabs.HEX_VIRTUAL_REALITY_CAFE:
                return "Prefabs/Hexes/Entertainment/Hex - VR Cafe";
            case Enums.Hex_Prefabs.HEX_QUANTUM_HOLOGRAM_THEATER:
                return "Prefabs/Hexes/Entertainment/Hex - Quantum Hologram Theater";
            case Enums.Hex_Prefabs.HEX_VOID_PORTAL:
                return "Prefabs/Hexes/Special/Hex - Void Portal";
            case Enums.Hex_Prefabs.HEX_VOID_COMMUNICATOR:
                return "Prefabs/Hexes/Special/Hex - Void Communicator";
            case Enums.Hex_Prefabs.HEX_VOID_RADAR_ARRAY:
                return "Prefabs/Hexes/Special/Hex - Void Radar Array";
            case Enums.Hex_Prefabs.HEX_FACTION_EMBASSY:
                return "Prefabs/Hexes/Special/Hex - Faction Embassy";
            case Enums.Hex_Prefabs.HEX_ABYSSAL_PATHFINDER:
                return "Prefabs/Hexes/Special/Hex - Abyssal Pathfinder";
            case Enums.Hex_Prefabs.HEX_VOID_RUDDER:
                return "Prefabs/Hexes/Special/Hex - Void Rudder";
            case Enums.Hex_Prefabs.HEX_WEATHER_MANIPULATOR:
                return "Prefabs/Hexes/Special/Hex - Weather Manipulator";
            case Enums.Hex_Prefabs.HEX_DIPLO_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Diplo Monument";
            case Enums.Hex_Prefabs.HEX_SCI_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Sci Monument";
            case Enums.Hex_Prefabs.HEX_HAPP_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Happ Monument";
            case Enums.Hex_Prefabs.HEX_IND_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Ind Monument";
            case Enums.Hex_Prefabs.HEX_ISO_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Iso Monument";
            case Enums.Hex_Prefabs.HEX_MIL_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Mil Monument";
            case Enums.Hex_Prefabs.HEX_FOOD_MONUMENT:
                return "Prefabs/Hexes/Monument/Hex - Food Monument";
            default:
                return "PROBLEMS";
        }
    }

    private string ModelPrefabToAddress(Enums.Model_Prefabs model)
    {
        switch (model)
        {
            case Enums.Model_Prefabs.MODEL_GARDEN:
                return "Prefabs/Models/Food/Garden";
            case Enums.Model_Prefabs.MODEL_FARM:
                return "Prefabs/Models/Food/Farm";
            case Enums.Model_Prefabs.MODEL_ORCHARD:
                return "Prefabs/Models/Food/Orchard";
            case Enums.Model_Prefabs.MODEL_RANCH:
                return "Prefabs/Models/Food/Ranch";
            case Enums.Model_Prefabs.MODEL_HYDROPONICS_TOWER:
                return "Prefabs/Models/Food/Hydroponics Tower";
            case Enums.Model_Prefabs.MODEL_HOVEL:
                return "Prefabs/Models/Housing/Hovel";
            case Enums.Model_Prefabs.MODEL_COTTAGE:
                return "Prefabs/Models/Housing/Cottage";
            case Enums.Model_Prefabs.MODEL_APARTMENT:
                return "Prefabs/Models/Housing/Apartment";
            case Enums.Model_Prefabs.MODEL_CONDOMINIUM:
                return "Prefabs/Models/Housing/Condo";
            case Enums.Model_Prefabs.MODEL_VILLA:
                return "Prefabs/Models/Housing/Villa";
            case Enums.Model_Prefabs.MODEL_WORKSHOP:
                return "Prefabs/Models/Industry/Workshop";
            case Enums.Model_Prefabs.MODEL_FORGE:
                return "Prefabs/Models/Industry/Forge";
            case Enums.Model_Prefabs.MODEL_MILL:
                return "Prefabs/Models/Industry/Mill";
            case Enums.Model_Prefabs.MODEL_FOUNDRY:
                return "Prefabs/Models/Industry/Foundry";
            case Enums.Model_Prefabs.MODEL_FACTORY:
                return "Prefabs/Models/Industry/Factory";
            case Enums.Model_Prefabs.MODEL_BARRACKS:
                return "Prefabs/Models/Military/Barracks";
            case Enums.Model_Prefabs.MODEL_DORMITORY:
                return "Prefabs/Models/Military/Dormitory";
            case Enums.Model_Prefabs.MODEL_GARRISON:
                return "Prefabs/Models/Military/Garrison";
            case Enums.Model_Prefabs.MODEL_QUARTERS:
                return "Prefabs/Models/Military/Quarters";
            case Enums.Model_Prefabs.MODEL_HEADQUARTERS:
                return "Prefabs/Models/Military/Headquarters";
            case Enums.Model_Prefabs.MODEL_RESEARCH_LAB:
                return "Prefabs/Models/Research/Research Lab";
            case Enums.Model_Prefabs.MODEL_RESEARCH_COLLEGE:
                return "Prefabs/Models/Research/Research College";
            case Enums.Model_Prefabs.MODEL_RESEARCH_INSTITUTE:
                return "Prefabs/Models/Research/Research Institute";
            case Enums.Model_Prefabs.MODEL_MULTIBRAIN_COMPLEX:
                return "Prefabs/Models/Research/MultiBrain Complex";
            case Enums.Model_Prefabs.MODEL_QUANTUM_BRAIN:
                return "Prefabs/Models/Research/Quantum Brain";
            case Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_I:
                return "Prefabs/Models/Isolium/Extractor MK I";
            case Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_II:
                return "Prefabs/Models/Isolium/Extractor MK II";
            case Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_III:
                return "Prefabs/Models/Isolium/Extractor MK III";
            case Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_IV:
                return "Prefabs/Models/Isolium/Extractor MK IV";
            case Enums.Model_Prefabs.MODEL_EXTRACTOR_MK_V:
                return "Prefabs/Models/Isolium/Extractor MK V";
            case Enums.Model_Prefabs.MODEL_STOCKPILE:
                return "Prefabs/Models/Storage/Stockpile";
            case Enums.Model_Prefabs.MODEL_STOREHOUSE:
                return "Prefabs/Models/Storage/Storehouse";
            case Enums.Model_Prefabs.MODEL_WAREHOUSE:
                return "Prefabs/Models/Storage/Stockpile";
            case Enums.Model_Prefabs.MODEL_DEPOT:
                return "Prefabs/Models/Storage/Depot";
            case Enums.Model_Prefabs.MODEL_DISTRIBUTION_CENTER:
                return "Prefabs/Models/Storage/Distribution Center";
            case Enums.Model_Prefabs.MODEL_PUBLIC_PARK:
                return "Prefabs/Models/Entertainment/Public Park";
            case Enums.Model_Prefabs.MODEL_CIRCUS:
                return "Prefabs/Models/Entertainment/Circus";
            case Enums.Model_Prefabs.MODEL_THEATER_COMPLEX:
                return "Prefabs/Models/Entertainment/Theater Complex";
            case Enums.Model_Prefabs.MODEL_VIRTUAL_REALITY_CAFE:
                return "Prefabs/Models/Entertainment/VR Cafe";
            case Enums.Model_Prefabs.MODEL_QUANTUM_HOLOGRAM_THEATER:
                return "Prefabs/Models/Entertainment/Quantum Hologram Theater";
            case Enums.Model_Prefabs.MODEL_DIPLO_MONUMENT:
                return "Prefabs/Models/Monument/Diplo Monument";
            case Enums.Model_Prefabs.MODEL_SCI_MONUMENT:
                return "Prefabs/Models/Monument/Sci Monument";
            case Enums.Model_Prefabs.MODEL_HAPP_MONUMENT:
                return "Prefabs/Models/Monument/Happ Monument";
            case Enums.Model_Prefabs.MODEL_IND_MONUMENT:
                return "Prefabs/Models/Monument/Ind Monument";
            case Enums.Model_Prefabs.MODEL_ISO_MONUMENT:
                return "Prefabs/Models/Monument/Iso Monument";
            case Enums.Model_Prefabs.MODEL_MIL_MONUMENT:
                return "Prefabs/Models/Monument/Mil Monument";
            case Enums.Model_Prefabs.MODEL_FOOD_MONUMENT:
                return "Prefabs/Models/Monument/Food Monument";
            default:
                return "PROBLEMS";
        }
    }

    private string ImageToAddress(Enums.Images image)
    {
        switch (image)
        {
            case Enums.Images.ICON_GOD_SEAT:
                return "Sprites/God Seat";
            case Enums.Images.ICON_FOOD:
                return "Sprites/Food";
            case Enums.Images.ICON_POP:
                return "Sprites/Population";
            case Enums.Images.ICON_INDUSTRY:
                return "Sprites/Industry";
            case Enums.Images.ICON_MILITARY:
                return "Sprites/Military";
            case Enums.Images.ICON_RESEARCH:
                return "Sprites/Research";
            case Enums.Images.ICON_ISOLIUM:
                return "Sprites/Isolium";
            case Enums.Images.ICON_STORAGE:
                return "Sprites/Storage";
            case Enums.Images.ICON_DEFENSE:
                return "Sprites/Defense";
            case Enums.Images.ICON_POWER:
                return "Sprites/Power";
            case Enums.Images.ICON_GRUNT:
                return "Sprites/Grunt";
            case Enums.Images.ICON_SHOOTER:
                return "Sprites/Shooter";
            case Enums.Images.ICON_DEFENDER:
                return "Sprites/Defender";
            case Enums.Images.ICON_GUNNER:
                return "Sprites/Gunner";
            case Enums.Images.ICON_SNIPER:
                return "Sprites/Sniper";
            case Enums.Images.ICON_SCOUT:
                return "Sprites/Scout";
            case Enums.Images.ICON_ACE:
                return "Sprites/Ace";
            case Enums.Images.ICON_CANNONEER:
                return "Sprites/Cannoneer";
            case Enums.Images.ICON_GUARDIAN:
                return "Sprites/Guardian";
            case Enums.Images.ICON_ENTERTAINMENT:
                return "Sprites/entertainment";
            case Enums.Images.ICON_MONUMENT:
                return "Sprites/monument";
            case Enums.Images.ICON_SPECIAL:
                return "Sprites/special";
            default:
                return "PROBLEMS";
        }
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

    private void OnDestroy()
    {
        UnLoadAssets(null);
    }
}
