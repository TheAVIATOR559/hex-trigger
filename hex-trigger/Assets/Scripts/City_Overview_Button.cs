using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Overview_Button : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject CityOverviewCamera;


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
        City_Manager.Instance.UnhighlightHex();
    }
}
