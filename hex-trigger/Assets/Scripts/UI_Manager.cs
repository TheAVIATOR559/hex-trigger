using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : Singleton<UI_Manager>
{
    private Canvas CityCanvas;
    private GameObject PlaceHexPanel;

    public void SetupReferences(Canvas cityCanvas)
    {
        CityCanvas = cityCanvas;
        PlaceHexPanel = CityCanvas.transform.GetChild(0).gameObject;
    }

    public static void EnablePlaceHexPanel()
    {
        Instance.PlaceHexPanel.SetActive(true);
    }

    public static void DisablePlaceHexPanel()
    {
        Instance.PlaceHexPanel.SetActive(false);
    }
}
