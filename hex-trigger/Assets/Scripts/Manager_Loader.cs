using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Loader : MonoBehaviour
{
    private void Awake()
    {
        Prefab_Manager prefabs = Prefab_Manager.Instance;
        City_Manager city = City_Manager.Instance;
    }
}
