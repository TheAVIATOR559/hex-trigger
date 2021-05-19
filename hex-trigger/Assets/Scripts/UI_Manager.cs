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

    private Image AvailableHexImage;
    private Image AvailablePopImage;
    private Image AvailableFoodImage;
    private Image AvailableIndustryImage;
    private Image AvailableMilitaryImage;
    private Image AvailableIsoliumImage;

    private TMP_Text GruntCountText;
    private TMP_Text ShooterCountText;
    private TMP_Text DefenderCountText;
    private TMP_Text GunnerCountText;
    private TMP_Text SniperCountText;
    private TMP_Text ScoutCountText;
    private TMP_Text AceCountText;
    private TMP_Text CannoneerCountText;
    private TMP_Text GuardianCountText;

    private GameObject currTierPanel;

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

        AvailableHexImage = ResourcePanel.transform.GetChild(0).GetComponent<Image>();
        AvailablePopImage = ResourcePanel.transform.GetChild(1).GetComponent<Image>();
        AvailableFoodImage = ResourcePanel.transform.GetChild(2).GetComponent<Image>();
        AvailableIndustryImage = ResourcePanel.transform.GetChild(3).GetComponent<Image>();
        AvailableMilitaryImage = ResourcePanel.transform.GetChild(4).GetComponent<Image>();
        AvailableIsoliumImage = ResourcePanel.transform.GetChild(5).GetComponent<Image>();

        GruntCountText = MilitaryPanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        ShooterCountText = MilitaryPanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        DefenderCountText = MilitaryPanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        GunnerCountText = MilitaryPanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        SniperCountText = MilitaryPanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        ScoutCountText = MilitaryPanel.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>();
        AceCountText = MilitaryPanel.transform.GetChild(6).GetChild(1).GetComponent<TMP_Text>();
        CannoneerCountText = MilitaryPanel.transform.GetChild(7).GetChild(1).GetComponent<TMP_Text>();
        GuardianCountText = MilitaryPanel.transform.GetChild(8).GetChild(1).GetComponent<TMP_Text>();

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
        SetAvailableMilitaryText(Resource_Manager.Instance.CurrentMilitary, Resource_Manager.Instance.MaximumMilitary);
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

    public static void UpdateUnitCountText()
    {
        Instance.GruntCountText.text = Resource_Manager.Instance.GruntCount.ToString();
        Instance.ShooterCountText.text = Resource_Manager.Instance.ShooterCount.ToString();
        Instance.DefenderCountText.text = Resource_Manager.Instance.DefenderCount.ToString();
        Instance.GunnerCountText.text = Resource_Manager.Instance.GunnerCount.ToString();
        Instance.SniperCountText.text = Resource_Manager.Instance.SniperCount.ToString();
        Instance.ScoutCountText.text = Resource_Manager.Instance.ScoutCount.ToString();

        Instance.AceCountText.text = Resource_Manager.Instance.AceCount + " / " + Resource_Manager.Instance.MaximumAces;
        Instance.CannoneerCountText.text = Resource_Manager.Instance.CannoneerCount + " / " + Resource_Manager.Instance.MaximumCannoneers;
        Instance.GuardianCountText.text = Resource_Manager.Instance.GuardianCount + " / " + Resource_Manager.Instance.MaximumGuardians;
    }

    public static void SetGruntCountText(int count)
    {
        Instance.GruntCountText.text = count.ToString();
    }

    public static void SetShooterCountText(int count)
    {
        Instance.ShooterCountText.text = count.ToString();
    }

    public static void SetDefenderCountText(int count)
    {
        Instance.DefenderCountText.text = count.ToString();
    }

    public static void SetGunnerCountText(int count)
    {
        Instance.GunnerCountText.text = count.ToString();
    }

    public static void SetSniperCountText(int count)
    {
        Instance.SniperCountText.text = count.ToString();
    }

    public static void SetScoutCountText(int count)
    {
        Instance.ScoutCountText.text = count.ToString();
    }

    public static void SetAceCountText(int count)
    {
        Instance.AceCountText.text = count + " / " + Resource_Manager.Instance.MaximumAces;
    }

    public static void SetCannoneerText(int count)
    {
        Instance.CannoneerCountText.text = count + " / " + Resource_Manager.Instance.MaximumCannoneers;
    }

    public static void SetGuardianText(int count)
    {
        Instance.GuardianCountText.text = count + " / " + Resource_Manager.Instance.MaximumGuardians;
    }

    public static void FlashMissingResources(BuildingCost cost)
    {
        if(!Instance.HexTextFlashing && Resource_Manager.Instance.AvailableHexes < cost.RequiredHexes)
        {
            Instance.HexTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableHexImage, Instance.EndHexFlashing));
        }

        if (!Instance.FoodTextFlashing && Resource_Manager.Instance.AvailableFood < cost.RequiredFood)
        {
            Instance.FoodTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableFoodImage, Instance.EndFoodFlashing));
        }

        if (!Instance.PopTextFlashing && Resource_Manager.Instance.AvailablePopulation < cost.RequiredPopulation)
        {
            Instance.PopTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailablePopImage, Instance.EndPopFlashing));
        }

        if (!Instance.IndustryTextFlashing && Resource_Manager.Instance.AvailableIndustry < cost.RequiredIndustry)
        {
            Instance.IndustryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIndustryImage, Instance.EndIndustryFlashing));
        }

        if (!Instance.MilitaryTextFlashing && Resource_Manager.Instance.CurrentMilitary < cost.RequiredMilitary)
        {
            Instance.MilitaryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableMilitaryImage, Instance.EndMilitaryFlashing));
        }

        if (!Instance.IsoliumTextFlashing && Resource_Manager.Instance.AvailableIsolium < cost.RequiredIsolium)
        {
            Instance.IsoliumTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIsoliumImage, Instance.EndIsoliumFlashing));
        }
    }

    public static void FlashMissingResources(UnitTrainingCost cost)
    {
        if (!Instance.FoodTextFlashing && Resource_Manager.Instance.AvailableFood < cost.RequiredFood)
        {
            Instance.FoodTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableFoodImage, Instance.EndFoodFlashing));
        }

        if (!Instance.IndustryTextFlashing && Resource_Manager.Instance.AvailableIndustry < cost.RequiredIndustry)
        {
            Instance.IndustryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIndustryImage, Instance.EndIndustryFlashing));
        }

        if (!Instance.MilitaryTextFlashing && Resource_Manager.Instance.CurrentMilitary + cost.RequiredMilitary > Resource_Manager.Instance.MaximumMilitary)
        {
            Instance.MilitaryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableMilitaryImage, Instance.EndMilitaryFlashing));
        }

        if (!Instance.IsoliumTextFlashing && Resource_Manager.Instance.AvailableIsolium < cost.RequiredIsolium)
        {
            Instance.IsoliumTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIsoliumImage, Instance.EndIsoliumFlashing));
        }
    }

    private IEnumerator FlashRed(Image image, System.Action method)
    {
        float endTime = Time.time + 1f;

        while (Time.time < endTime)
        {
            image.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            image.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }

        image.color = Color.white;
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
