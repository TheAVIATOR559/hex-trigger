using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Overview_Button : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject CityOverviewCamera;
    //todo make it so when another button is clicked disable the city overview

    private void Awake()
    {
        CityOverviewCamera.SetActive(false);
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
}
