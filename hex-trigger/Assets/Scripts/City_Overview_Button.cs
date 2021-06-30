using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Overview_Button : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject CityOverviewCamera;

    private static City_Overview_Button instance;

    private void Awake()
    {
        CityOverviewCamera.SetActive(false);
        instance = this;
    }

    public void OnClick()
    {
        //disable main camera
        MainCamera.SetActive(!MainCamera.activeSelf);

        //enable overview camera
        CityOverviewCamera.SetActive(!CityOverviewCamera.activeSelf);

        //enable overview canvas
        UI_Manager.ResetCityUIState();
        
        if(CityOverviewCamera.activeSelf)
        {
            UI_Manager.EnableCityOverviewPanel();
        }
        else
        {
            UI_Manager.DisableCityOverviewPanel();
        }

        City_Manager.Instance.UnhighlightHex();
    }

    public static void DisableCityOverview()
    {
        instance.CityOverviewCamera.SetActive(false);
        instance.MainCamera.SetActive(true);
        UI_Manager.ResetCityUIState();
    }
}
