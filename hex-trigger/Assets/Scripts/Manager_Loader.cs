using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loader : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;

    private void Awake()
    {
        Prefab_Manager prefabs = Prefab_Manager.Instance;
        City_Manager city = City_Manager.Instance;
        UI_Manager.Instance.SetupReferences(mainCanvas);
        Resource_Manager.StartResourcesTick();
    }
}
