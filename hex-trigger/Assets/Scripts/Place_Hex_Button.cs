using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Hex_Button : MonoBehaviour
{
    [SerializeField] Enums.Prefabs hexType;
    public void OnClick()
    {
        //highlight available hex locations
        City_Manager.ActivateAvailableHexHighlights();
        //enable ghost hex and set hex type
    }
}
