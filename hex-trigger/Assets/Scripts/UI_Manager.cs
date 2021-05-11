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
    private GameObject MilitaryPanel;

    private TMP_Text AvailableHexText;
    private TMP_Text AvailablePopText;
    private TMP_Text AvailableFoodText;
    private TMP_Text AvailableIndustryText;
    private TMP_Text AvailableMilitaryText;
    private TMP_Text AvailableIsoliumText;

    private GameObject currTierPanel;

    private Color defaultTextColor;

    private bool HexTextFlashing = false;
    private bool PopTextFlashing = false;
    private bool FoodTextFlashing = false;
    private bool IndustryTextFlashing = false;
    private bool MilitaryTextFlashing = false;
    private bool IsoliumTextFlashing = false;

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
        MilitaryPanel = CityCanvas.transform.GetChild(10).gameObject;

        AvailableHexText = ResourcePanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        AvailablePopText = ResourcePanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        AvailableFoodText = ResourcePanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        AvailableIndustryText = ResourcePanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        AvailableMilitaryText = ResourcePanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        AvailableIsoliumText = ResourcePanel.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>();

        defaultTextColor = AvailableHexText.color;

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
        Instance.MilitaryPanel.SetActive(false);

        UpdateResourcesText();
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

    public static void UpdateResourcesText()
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

    public static void FlashMissingResources(BuildingCost cost)
    {
        if(!Instance.HexTextFlashing && Resource_Manager.Instance.AvailableHexes < cost.RequiredHexes)
        {
            Instance.HexTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableHexText, Instance.EndHexFlashing));
        }

        if (!Instance.FoodTextFlashing && Resource_Manager.Instance.AvailableFood < cost.RequiredFood)
        {
            Instance.FoodTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableFoodText, Instance.EndFoodFlashing));
        }

        if (!Instance.PopTextFlashing && Resource_Manager.Instance.AvailablePopulation < cost.RequiredPopulation)
        {
            Instance.PopTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailablePopText, Instance.EndPopFlashing));
        }

        if (!Instance.IndustryTextFlashing && Resource_Manager.Instance.AvailableIndustry < cost.RequiredIndustry)
        {
            Instance.IndustryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIndustryText, Instance.EndIndustryFlashing));
        }

        if (!Instance.MilitaryTextFlashing && Resource_Manager.Instance.AvailableMilitary < cost.RequiredMilitary)
        {
            Instance.MilitaryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableMilitaryText, Instance.EndMilitaryFlashing));
        }

        if (!Instance.IsoliumTextFlashing && Resource_Manager.Instance.AvailableIsolium < cost.RequiredIsolium)
        {
            Instance.IsoliumTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIsoliumText, Instance.EndIsoliumFlashing));
        }
    }

    private IEnumerator FlashRed(TMP_Text text, System.Action method)
    {
        float endTime = Time.time + 1f;

        while (Time.time < endTime)
        {
            text.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            text.color = defaultTextColor;
            yield return new WaitForSeconds(0.1f);
        }

        text.color = defaultTextColor;
        method();
    }

    private void EndHexFlashing()
    {
        Instance.HexTextFlashing = false;
    }

    private void EndPopFlashing()
    {
        Instance.PopTextFlashing = false;
    }

    private void EndFoodFlashing()
    {
        Instance.FoodTextFlashing = false;
    }

    private void EndIndustryFlashing()
    {
        Instance.IndustryTextFlashing = false;
    }

    private void EndMilitaryFlashing()
    {
        Instance.MilitaryTextFlashing = false;
    }

    private void EndIsoliumFlashing()
    {
        Instance.IsoliumTextFlashing = false;
    }
}
