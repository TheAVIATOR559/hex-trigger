using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Menu_Button : MonoBehaviour
{
    [SerializeField] GameObject PanelToClose;
    public void OnClick()
    {
        PanelToClose.SetActive(false);
    }

    public void CloseInfoPanel()
    {
        PanelToClose.SetActive(false);
        City_Manager.Instance.UnhighlightHex();
    }
}
