using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Type_Button : MonoBehaviour
{
    [SerializeField] GameObject panelToEnable;

    public void EnableTierPanel()
    {
        panelToEnable.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
