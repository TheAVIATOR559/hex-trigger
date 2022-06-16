using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using TMPro;

public class Load_Scene : MonoBehaviour
{
    public bool LoadAssets;
    public AssetReference scene;
    public TMP_Text loadingText;

    private void Awake()
    {
        if(LoadAssets)
        {
            Prefab_Manager.LoadAssets(LoadScene, loadingText);
        }
    }

    public void LoadScene()
    {
        scene.LoadSceneAsync(LoadSceneMode.Single).Completed += SceneLoadComplete;
    }

    private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
    {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + " loaded");
        }
    }

    void OnDestroy()
    {
        scene.ReleaseAsset();
    }
}
