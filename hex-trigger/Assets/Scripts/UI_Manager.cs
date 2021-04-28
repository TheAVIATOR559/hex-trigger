using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    private Canvas CityCanvas;
    private GameObject MainPanel;
    private GameObject HexTypePanel;
    private GameObject FoodTierPanel;
    private GameObject HousingTierPanel;
    private GameObject IndustryTierPanel;
    private GameObject MilitaryTierPanel;
    private GameObject DefenseTierPanel;
    private GameObject ResearchTierPanel;
    private GameObject IsoliumTierPanel;

    private GameObject ResourcePanel;
    private TMP_Text AvailableHexText;
    private TMP_Text AvailablePopText;
    private TMP_Text AvailableFoodText;
    private TMP_Text AvailableIndustryText;
    private TMP_Text AvailableMilitaryText;
    private TMP_Text AvailableIsoliumText;

    private GameObject currTierPanel;

    public void SetupReferences(Canvas cityCanvas)
    {
        CityCanvas = cityCanvas; 
        MainPanel = CityCanvas.transform.GetChild(0).gameObject;
        HexTypePanel = CityCanvas.transform.GetChild(1).gameObject;
        FoodTierPanel = CityCanvas.transform.GetChild(2).gameObject;
        HousingTierPanel = CityCanvas.transform.GetChild(3).gameObject;
        IndustryTierPanel = CityCanvas.transform.GetChild(4).gameObject;
        MilitaryTierPanel = CityCanvas.transform.GetChild(5).gameObject;
        DefenseTierPanel = CityCanvas.transform.GetChild(6).gameObject;
        ResearchTierPanel = CityCanvas.transform.GetChild(7).gameObject;
        IsoliumTierPanel = CityCanvas.transform.GetChild(8).gameObject;
        ResourcePanel = CityCanvas.transform.GetChild(9).gameObject;

        AvailableHexText = ResourcePanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        AvailablePopText = ResourcePanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        AvailableFoodText = ResourcePanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        AvailableIndustryText = ResourcePanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        AvailableMilitaryText = ResourcePanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        AvailableIsoliumText = ResourcePanel.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>();

        ResetCityUIState();
    }

    public static void ResetCityUIState()
    {
        Instance.MainPanel.SetActive(true);
        Instance.HexTypePanel.SetActive(false);
        Instance.FoodTierPanel.SetActive(false);
        Instance.HousingTierPanel.SetActive(false);
        Instance.IndustryTierPanel.SetActive(false);
        Instance.MilitaryTierPanel.SetActive(false);
        Instance.DefenseTierPanel.SetActive(false);
        Instance.ResearchTierPanel.SetActive(false);
        Instance.IsoliumTierPanel.SetActive(false);
        Instance.ResourcePanel.SetActive(true);

        SetResourcesText();
    }

    public static void SetTierPanel(GameObject panel)
    {
        Instance.currTierPanel = panel;
    }

    public static void EnableHexTierPanel()
    {
        Instance.currTierPanel.SetActive(true);
    }

    public static void DisableHexTierPanel()
    {
        Instance.currTierPanel.SetActive(false);
    }

    public static void SetResourcesText()
    {
        SetAvailableHexesText(Resource_Manager.Instance.AvailableHexes);
        SetAvailablePopulationText(Resource_Manager.Instance.AvailablePopulation, Resource_Manager.Instance.AvailableHousing);
        SetAvailableFoodText(Resource_Manager.Instance.AvailableFood);
        SetAvailableIndustryText(Resource_Manager.Instance.AvailableIndustry);
        SetAvailableMilitaryText(Resource_Manager.Instance.AvailableMilitary, Resource_Manager.Instance.MaximumMilitary);
        SetAvailableIsoliumText(Resource_Manager.Instance.AvailableIsolium);
    }

    public static void SetAvailableHexesText(int hexes)
    {
        Instance.AvailableHexText.text = hexes.ToString();
    }

    public static void SetAvailablePopulationText(int currPop, int maxPop)
    {
        Instance.AvailablePopText.text = currPop + " / " + maxPop;
    }

    public static void SetAvailableFoodText(int food)
    {
        Instance.AvailableFoodText.text = food.ToString();
    }

    public static void SetAvailableIndustryText(int industry)
    {
        Instance.AvailableIndustryText.text = industry.ToString();
    }

    public static void SetAvailableMilitaryText(int currMilitary, int maxMilitary)
    {
        Instance.AvailableMilitaryText.text = currMilitary + " / " + maxMilitary;
    }

    public static void SetAvailableIsoliumText(int isolium)
    {
        Instance.AvailableIsoliumText.text = isolium.ToString();
    }
}
