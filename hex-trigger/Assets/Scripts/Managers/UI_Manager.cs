using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Canvas CityCanvas;
    private GameObject MainPanel;
    private GameObject HexTypePanel;
    private GameObject FoodTierPanel;
    private GameObject HousingTierPanel;
    private GameObject IndustryTierPanel;
    private GameObject MilitaryTierPanel;
    private GameObject DefenseTierPanel;
    private GameObject ResearchTierPanel;
    private GameObject IsoliumTierPanel;
    private GameObject StorageTierPanel;
    private GameObject PowerTierPanel;
    private GameObject EntertainmentTierPanel;
    private GameObject MonumentTierPanel;
    private GameObject SpecialTierPanel;

    private GameObject BuildInfoPanel;
    private Image BuildInfoPanelImage;
    private TMP_Text BuildInfoPanelName;
    private GameObject BuilldInfoPanelCost;

    private GameObject InfoPanel;
    private Image InfoPanelImage;
    private TMP_Text InfoPanelName;
    private TMP_Text InfoPanelDesc;
    private TMP_Text InfoPanelBaseProd;
    private TMP_Text InfoPanelAdjProd;
    private TMP_Text InfoPanelBonusToOthers;
    private TMP_Text InfoPanelBonusFromOthers;

    private TMP_Text InfoPanelGodSeatLevel;
    private TMP_Text InfoPanelGodSeatHexRange;
    private TMP_Text InfoPanelGodSeatIsoliumCost;
    private TMP_Text InfoPanelGodSeatIndustryCost;
    private TMP_Text InfoPanelGodSeatFoodCost;
    private TMP_Text InfoPanelGodSeatPopCost;

    private TMP_Text InfoPanelHousingBaseProd;
    private TMP_Text InfoPanelHousingAdjProd;
    private TMP_Text InfoPanelHousingBonusToOthers;
    private TMP_Text InfoPanelHousingBonusFromOthers;
    private TMP_Text InfoPanelHousingHappiness;

    private GameObject ResourcePanel;
    private GameObject MilitaryPanel;

    private TMP_Text AvailablePopText;
    private TMP_Text AvailableFoodText;
    private TMP_Text AvailableIndustryText;
    private TMP_Text AvailableMilitaryText;
    private TMP_Text AvailableIsoliumText;

    private Image AvailablePopImage;
    private Image AvailableFoodImage;
    private Image AvailableIndustryImage;
    private Image AvailableMilitaryImage;
    private Image AvailableIsoliumImage;
    private Image AceButtonImage;
    private Image CannoneerButtonImage;
    private Image GuardianButtonImage;

    private TMP_Text GruntCountText;
    private TMP_Text ShooterCountText;
    private TMP_Text DefenderCountText;
    private TMP_Text GunnerCountText;
    private TMP_Text SniperCountText;
    private TMP_Text ScoutCountText;
    private TMP_Text AceCountText;
    private TMP_Text CannoneerCountText;
    private TMP_Text GuardianCountText;

    private GameObject CityOverviewPanel;
    private TMP_Text FoodProdText;
    private TMP_Text PopGrowthText;
    private TMP_Text IndustryProdText;
    private TMP_Text IsoliumProdText;
    private TMP_Text ResearchSpeedText;
    private TMP_Text ShooterCostReducText;
    private TMP_Text DefenderCostReducText;
    private TMP_Text GunnerCostReducText;
    private TMP_Text SniperCostReducText;
    private TMP_Text ScoutCostReducText;
    private TMP_Text MaxAceCountText;
    private TMP_Text MaxCannoneerCountText;
    private TMP_Text MaxGuardianCountText;
    private TMP_Text MaxHexRangeText;

    private GameObject currTierPanel;
    private List<Button> hexTypeButtons = new List<Button>();

    private GameObject PausedPanel;

    private GameObject OptionsPanel;

    private bool PopTextFlashing = false;
    private bool FoodTextFlashing = false;
    private bool IndustryTextFlashing = false;
    private bool MilitaryTextFlashing = false;
    private bool IsoliumTextFlashing = false;
    private bool AceTextFlashing = false;
    private bool CannoneerTextFlashing = false;
    private bool GuardianTextFlashing = false;

    public static UI_Manager Instance;

    private void Awake()
    {
        Instance = this;

        SetupReferences();
    }

    public void SetupReferences()
    {
        MainPanel = CityCanvas.transform.GetChild(0).gameObject;
        HexTypePanel = CityCanvas.transform.GetChild(1).gameObject;
        FoodTierPanel = CityCanvas.transform.GetChild(2).gameObject;
        HousingTierPanel = CityCanvas.transform.GetChild(3).gameObject;
        IndustryTierPanel = CityCanvas.transform.GetChild(4).gameObject;
        MilitaryTierPanel = CityCanvas.transform.GetChild(5).gameObject;
        DefenseTierPanel = CityCanvas.transform.GetChild(6).gameObject;
        ResearchTierPanel = CityCanvas.transform.GetChild(7).gameObject;
        IsoliumTierPanel = CityCanvas.transform.GetChild(8).gameObject;
        StorageTierPanel = CityCanvas.transform.GetChild(9).gameObject;
        PowerTierPanel = CityCanvas.transform.GetChild(10).gameObject;
        EntertainmentTierPanel = CityCanvas.transform.GetChild(11).gameObject;
        MonumentTierPanel = CityCanvas.transform.GetChild(12).gameObject;
        SpecialTierPanel = CityCanvas.transform.GetChild(13).gameObject;
        ResourcePanel = CityCanvas.transform.GetChild(14).gameObject;
        MilitaryPanel = CityCanvas.transform.GetChild(15).gameObject;

        BuildInfoPanel = CityCanvas.transform.GetChild(16).gameObject;
        BuildInfoPanelImage = BuildInfoPanel.transform.GetChild(0).GetComponent<Image>();
        BuildInfoPanelName = BuildInfoPanel.transform.GetChild(1).GetComponent<TMP_Text>();
        BuilldInfoPanelCost = BuildInfoPanel.transform.GetChild(2).gameObject;

        AvailablePopText = ResourcePanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        AvailableFoodText = ResourcePanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        AvailableIndustryText = ResourcePanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        AvailableMilitaryText = ResourcePanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        AvailableIsoliumText = ResourcePanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();

        AvailablePopImage = ResourcePanel.transform.GetChild(0).GetComponent<Image>();
        AvailableFoodImage = ResourcePanel.transform.GetChild(1).GetComponent<Image>();
        AvailableIndustryImage = ResourcePanel.transform.GetChild(2).GetComponent<Image>();
        AvailableMilitaryImage = ResourcePanel.transform.GetChild(3).GetComponent<Image>();
        AvailableIsoliumImage = ResourcePanel.transform.GetChild(4).GetComponent<Image>();

        GruntCountText = MilitaryPanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        ShooterCountText = MilitaryPanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        DefenderCountText = MilitaryPanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        GunnerCountText = MilitaryPanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        SniperCountText = MilitaryPanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        ScoutCountText = MilitaryPanel.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>();
        AceCountText = MilitaryPanel.transform.GetChild(6).GetChild(1).GetComponent<TMP_Text>();
        AceButtonImage = MilitaryPanel.transform.GetChild(6).GetComponent<Image>();
        CannoneerCountText = MilitaryPanel.transform.GetChild(7).GetChild(1).GetComponent<TMP_Text>();
        CannoneerButtonImage = MilitaryPanel.transform.GetChild(7).GetComponent<Image>();
        GuardianCountText = MilitaryPanel.transform.GetChild(8).GetChild(1).GetComponent<TMP_Text>();
        GuardianButtonImage = MilitaryPanel.transform.GetChild(8).GetComponent<Image>();

        InfoPanel = CityCanvas.transform.GetChild(17).gameObject;
        InfoPanelImage = InfoPanel.transform.GetChild(0).GetComponent<Image>();
        InfoPanelName = InfoPanel.transform.GetChild(1).GetComponent<TMP_Text>();
        InfoPanelDesc = InfoPanel.transform.GetChild(2).GetComponent<TMP_Text>();
        InfoPanelBaseProd = InfoPanel.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelAdjProd = InfoPanel.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelBonusToOthers = InfoPanel.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelBonusFromOthers = InfoPanel.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<TMP_Text>();

        InfoPanelGodSeatLevel = InfoPanel.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelGodSeatHexRange = InfoPanel.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelGodSeatIsoliumCost = InfoPanel.transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        InfoPanelGodSeatIndustryCost = InfoPanel.transform.GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<TMP_Text>();
        InfoPanelGodSeatFoodCost = InfoPanel.transform.GetChild(4).GetChild(2).GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        InfoPanelGodSeatPopCost = InfoPanel.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(0).GetComponent<TMP_Text>();

        InfoPanelHousingBaseProd = InfoPanel.transform.GetChild(5).GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelHousingAdjProd = InfoPanel.transform.GetChild(5).GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelHousingBonusToOthers = InfoPanel.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelHousingBonusFromOthers = InfoPanel.transform.GetChild(5).GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelHousingHappiness = InfoPanel.transform.GetChild(5).GetChild(4).GetChild(1).GetComponent<TMP_Text>();

        CityOverviewPanel = CityCanvas.transform.GetChild(18).gameObject;
        FoodProdText = CityOverviewPanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        PopGrowthText = CityOverviewPanel.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        IndustryProdText = CityOverviewPanel.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        IsoliumProdText = CityOverviewPanel.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        ResearchSpeedText = CityOverviewPanel.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        ShooterCostReducText = CityOverviewPanel.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>();
        DefenderCostReducText = CityOverviewPanel.transform.GetChild(6).GetChild(1).GetComponent<TMP_Text>();
        GunnerCostReducText = CityOverviewPanel.transform.GetChild(7).GetChild(1).GetComponent<TMP_Text>();
        SniperCostReducText = CityOverviewPanel.transform.GetChild(8).GetChild(1).GetComponent<TMP_Text>();
        ScoutCostReducText = CityOverviewPanel.transform.GetChild(9).GetChild(1).GetComponent<TMP_Text>();
        MaxAceCountText = CityOverviewPanel.transform.GetChild(10).GetChild(1).GetComponent<TMP_Text>();
        MaxCannoneerCountText = CityOverviewPanel.transform.GetChild(11).GetChild(1).GetComponent<TMP_Text>();
        MaxGuardianCountText = CityOverviewPanel.transform.GetChild(12).GetChild(1).GetComponent<TMP_Text>();
        MaxHexRangeText = CityOverviewPanel.transform.GetChild(13).GetChild(1).GetComponent<TMP_Text>();

        PausedPanel = CityCanvas.transform.GetChild(19).gameObject;
        OptionsPanel = CityCanvas.transform.GetChild(20).gameObject;

        foreach (Transform child in HexTypePanel.transform)
        {
            hexTypeButtons.Add(child.GetComponent<Button>());
        }

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
        Instance.StorageTierPanel.SetActive(false);
        Instance.PowerTierPanel.SetActive(false);
        Instance.EntertainmentTierPanel.SetActive(false);
        Instance.MonumentTierPanel.SetActive(false);
        Instance.SpecialTierPanel.SetActive(false);
        Instance.ResourcePanel.SetActive(true);
        Instance.MilitaryPanel.SetActive(false);
        Instance.BuildInfoPanel.SetActive(false);
        Instance.InfoPanel.SetActive(false);
        Instance.CityOverviewPanel.SetActive(false);
        Instance.PausedPanel.SetActive(false);
        Instance.OptionsPanel.SetActive(false);

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

    public static void ReEnableHexTypeButtons()
    {
        foreach(Button buttton in Instance.hexTypeButtons)
        {
            buttton.interactable = true;
        }
    }

    public static void EnableBuildInfoPanel()
    {
        Instance.BuildInfoPanel.SetActive(true);
        Instance.BuildInfoPanelImage.gameObject.SetActive(false);
        Instance.BuildInfoPanelName.gameObject.SetActive(false);
        Instance.BuilldInfoPanelCost.SetActive(false);
    }

    public static void DisableBuildInfoPanel()
    {
        Instance.BuildInfoPanel.SetActive(false);
    }

    public static void ClearBuildInfoPanel()
    {
        Instance.BuildInfoPanelImage.gameObject.SetActive(false);
        Instance.BuildInfoPanelName.gameObject.SetActive(false);
        Instance.BuilldInfoPanelCost.SetActive(false);
    }

    public static void UpdateBuildInfoPanel(Enums.Building_Type type)
    {
        Instance.BuildInfoPanelImage.gameObject.SetActive(true);
        Instance.BuildInfoPanelName.gameObject.SetActive(true);
        Instance.BuilldInfoPanelCost.SetActive(true);

        switch (type)
        {
            case Enums.Building_Type.GARDEN:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.BuildInfoPanelName.text = Constants.GARDEN_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GardenCost);
                break;
            case Enums.Building_Type.FARM:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.BuildInfoPanelName.text = Constants.FARM_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.FarmCost);
                break;
            case Enums.Building_Type.ORCHARD:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.BuildInfoPanelName.text = Constants.ORCHARD_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.OrchardCost);
                break;
            case Enums.Building_Type.RANCH:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.BuildInfoPanelName.text = Constants.RANCH_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.RanchCost);
                break;
            case Enums.Building_Type.HOVEL:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.BuildInfoPanelName.text = Constants.HOVEL_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.HovelCost);
                break;
            case Enums.Building_Type.COTTAGE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.BuildInfoPanelName.text = Constants.COTTAGE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CottageCost);
                break;
            case Enums.Building_Type.APARTMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.BuildInfoPanelName.text = Constants.APARTMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ApartmentCost);
                break;
            case Enums.Building_Type.CONDOMINIUM:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.BuildInfoPanelName.text = Constants.CONDO_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CondoCost);
                break;
            case Enums.Building_Type.WORKSHOP:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.BuildInfoPanelName.text = Constants.WORKSHOP_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.WorkshopCost);
                break;
            case Enums.Building_Type.FORGE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.BuildInfoPanelName.text = Constants.FORGE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ForgeCost);
                break;
            case Enums.Building_Type.MILL:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.BuildInfoPanelName.text = Constants.MILL_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.MillCost);
                break;
            case Enums.Building_Type.FOUNDRY:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.BuildInfoPanelName.text = Constants.FOUNDRY_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.FoundryCost);
                break;
            case Enums.Building_Type.BARRACKS:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.BuildInfoPanelName.text = Constants.BARRACKS_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.BarracksCost);
                break;
            case Enums.Building_Type.DORMITORY:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.BuildInfoPanelName.text = Constants.DORMITORY_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.DormitoryCost);
                break;
            case Enums.Building_Type.GARRISON:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.BuildInfoPanelName.text = Constants.GARRISON_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GarrisonCost);
                break;
            case Enums.Building_Type.QUARTERS:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.BuildInfoPanelName.text = Constants.QUARTERS_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.QuartersCost);
                break;
            case Enums.Building_Type.WATCHTOWER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.BuildInfoPanelName.text = Constants.WATCHTOWER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.WatchTowerCost);
                break;
            case Enums.Building_Type.MISSILE_COMPLEX:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.BuildInfoPanelName.text = Constants.MISSILE_COMPLEX_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.MissileComplexCost);
                break;
            case Enums.Building_Type.LASER_TOWER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.BuildInfoPanelName.text = Constants.LASER_TOWER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.LaserTowerCost);
                break;
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.BuildInfoPanelName.text = Constants.AUTO_MISSILE_COMPLEX_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.AutoMissileComplexCost);
                break;
            case Enums.Building_Type.AUTO_LASER_TOWER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.BuildInfoPanelName.text = Constants.AUTO_LASER_TOWER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.AutoLaserTowerCost);
                break;
            case Enums.Building_Type.RESEARCH_LAB:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.BuildInfoPanelName.text = Constants.RESEARCH_LAB_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ResearchLabCost);
                break;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.BuildInfoPanelName.text = Constants.RESEARCH_COLLEGE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ResearchCollegeCost);
                break;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.BuildInfoPanelName.text = Constants.RESEARCH_INSTITUTE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ResearchInstituteCost);
                break;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.BuildInfoPanelName.text = Constants.MULTIBRAIN_COMPLEX_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.MultiBrainCost);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_I:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.BuildInfoPanelName.text = Constants.STOCKPILE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ExtractorMKICost);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_II:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.BuildInfoPanelName.text = Constants.STOREHOUSE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ExtractorMKIICost);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_III:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.BuildInfoPanelName.text = Constants.WAREHOUSE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ExtractorMKIIICost);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_IV:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.BuildInfoPanelName.text = Constants.DEPOT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ExtractorMKIVCost);
                break;
            case Enums.Building_Type.SHOOTING_RANGE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SHOOTER);
                Instance.BuildInfoPanelName.text = Constants.SHOOTING_RANGE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ShootingRangeCost);
                break;
            case Enums.Building_Type.DEFENDERS_WALL:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENDER);
                Instance.BuildInfoPanelName.text = Constants.DEFENDERS_WALL_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.DefendersWallCost);
                break;
            case Enums.Building_Type.GUNNERS_ALLEY:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUNNER);
                Instance.BuildInfoPanelName.text = Constants.GUNNERS_ALLEY_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GunnersAlleyCost);
                break;
            case Enums.Building_Type.SNIPERS_NEST:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SNIPER);
                Instance.BuildInfoPanelName.text = Constants.SNIPERS_NEST_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.SnipersNestCost);
                break;
            case Enums.Building_Type.SCOUT_CAMP:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SCOUT);
                Instance.BuildInfoPanelName.text = Constants.SCOUT_CAMP_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ScoutCampCost);
                break;
            case Enums.Building_Type.ACES_ARENA:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ACE);
                Instance.BuildInfoPanelName.text = Constants.ACES_ARENA_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.AcesArenaCost);
                break;
            case Enums.Building_Type.CANNONEERS_TOWER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_CANNONEER);
                Instance.BuildInfoPanelName.text = Constants.CANNONEERS_TOWER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CannoneersTowerCost);
                break;
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUARDIAN);
                Instance.BuildInfoPanelName.text = Constants.GUARDIANS_LAST_STAND_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GuardiansLastStandCost);
                break;
            case Enums.Building_Type.STOCKPILE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.BuildInfoPanelName.text = Constants.STOCKPILE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.StockpileCost);
                break;
            case Enums.Building_Type.STOREHOUSE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.BuildInfoPanelName.text = Constants.STOREHOUSE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.StorehouseCost);
                break;
            case Enums.Building_Type.WAREHOUSE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.BuildInfoPanelName.text = Constants.WAREHOUSE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.WarehouseCost);
                break;
            case Enums.Building_Type.DEPOT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.BuildInfoPanelName.text = Constants.DEPOT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.DepotCost);
                break;
            case Enums.Building_Type.WATERWHEEL_GENERATOR:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.BuildInfoPanelName.text = Constants.WATERWHEEL_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.WaterwheelCost);
                break;
            case Enums.Building_Type.COAL_FIRED_POWER_PLANT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.BuildInfoPanelName.text = Constants.COAL_FIRED_PLANT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CoalfiredCost);
                break;
            case Enums.Building_Type.HYDROELECTRIC_DAM:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.BuildInfoPanelName.text = Constants.HYDROELECTRIC_DAM_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.HydroelectricCost);
                break;
            case Enums.Building_Type.NUCLEAR_POWER_PLANT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.BuildInfoPanelName.text = Constants.NUCLEAR_POWER_PLANT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.NuclearPlantCost);
                break;
            case Enums.Building_Type.QUANTUM_POWER_PLANT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.BuildInfoPanelName.text = Constants.QUANTUM_POWER_PLANT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.QuantumPlantCost);
                break;
            case Enums.Building_Type.PUBLIC_PARK:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.BuildInfoPanelName.text = Constants.PUBLIC_PARK_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.PublicParkCost);
                break;
            case Enums.Building_Type.CIRCUS:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.BuildInfoPanelName.text = Constants.CIRCUS_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CircusCost);
                break;
            case Enums.Building_Type.THEATER_COMPLEX:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.BuildInfoPanelName.text = Constants.THEATER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.TheaterCost);
                break;
            case Enums.Building_Type.VIRTUAL_REALITY_CAFE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.BuildInfoPanelName.text = Constants.VIRTUAL_REALITY_CAFE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.VirtualRealityCafeCost);
                break;
            case Enums.Building_Type.VOID_PORTAL:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.VOID_PORTAL_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.VoidPortalCost);
                break;
            case Enums.Building_Type.VOID_COMMUNICATOR:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.VOID_COMMUNICATOR_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.VoidCommunicatorCost);
                break;
            case Enums.Building_Type.VOID_RADAR_ARRAY:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.VOID_RADAR_ARRAY_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.VoidRadarArrayCost);
                break;
            case Enums.Building_Type.FACTION_EMBASSY:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.FACTION_EMBASSY_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.FactionEmbassyCost);
                break;
            case Enums.Building_Type.ABYSSAL_PATHFINDER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.ABYSSAL_PATHFINDER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.AbyssalPathfinderCost);
                break;
            case Enums.Building_Type.VOID_RUDDER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.VOID_RUDDER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.VoidRudderCost);
                break;
            case Enums.Building_Type.WEATHER_MANIPULATOR:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.BuildInfoPanelName.text = Constants.WEATHER_MANIPULATOR_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.WeatherManipulatorCost);
                break;
            case Enums.Building_Type.DIPLO_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.DIPLO_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.DiploMonumentCost);
                break;
            case Enums.Building_Type.SCI_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.SCI_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.SciMonumentCost);
                break;
            case Enums.Building_Type.HAPP_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.HAPP_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.HappMonumentCost);
                break;
            case Enums.Building_Type.IND_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.IND_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.IndMonumentCost);
                break;
            case Enums.Building_Type.ISO_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.ISO_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.IsoMonumentCost);
                break;
            case Enums.Building_Type.MIL_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.MIL_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.MilMonumentCost);
                break;
            case Enums.Building_Type.FOOD_MONUMENT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.BuildInfoPanelName.text = Constants.FOOD_MONUMENT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.FoodMonumentCost);
                break;
            case Enums.Building_Type.GOD_SEAT:
            case Enums.Building_Type.HYDROPONICS_TOWER:
            case Enums.Building_Type.VILLA:
            case Enums.Building_Type.FACTORY:
            case Enums.Building_Type.HEADQUARTERS:
            case Enums.Building_Type.QUANTUM_BRAIN:
            case Enums.Building_Type.EXTRACTOR_MK_V:
            case Enums.Building_Type.DISTRIBUTION_CENTER:
            case Enums.Building_Type.QUANTUM_HOLOGRAM_THEATER:
            default:
                break;
        }
    }

    public static void UpdateBuildInfoPanel(Enums.Unit_Type type)
    {
        Instance.BuildInfoPanelImage.gameObject.SetActive(true);
        Instance.BuildInfoPanelName.gameObject.SetActive(true);
        Instance.BuilldInfoPanelCost.SetActive(true);

        switch (type)
        {
            case Enums.Unit_Type.GRUNT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GRUNT);
                Instance.BuildInfoPanelName.text = Constants.GRUNT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GRUNT_TRAINING_COST, true);
                break;
            case Enums.Unit_Type.SHOOTER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SHOOTER);
                Instance.BuildInfoPanelName.text = Constants.SHOOTER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.SHOOTER_TRAINING_COST);
                break;
            case Enums.Unit_Type.DEFENDER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENDER);
                Instance.BuildInfoPanelName.text = Constants.DEFENDER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.DEFENDER_TRAINING_COST);
                break;
            case Enums.Unit_Type.GUNNER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUNNER);
                Instance.BuildInfoPanelName.text = Constants.GUNNER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GUNNER_TRAINING_COST);
                break;
            case Enums.Unit_Type.SNIPER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SNIPER);
                Instance.BuildInfoPanelName.text = Constants.SNIPER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.SNIPER_TRAINING_COST);
                break;
            case Enums.Unit_Type.SCOUT:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SCOUT);
                Instance.BuildInfoPanelName.text = Constants.SCOUT_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.SCOUT_TRAINING_COST);
                break;
            case Enums.Unit_Type.ACE:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ACE);
                Instance.BuildInfoPanelName.text = Constants.ACE_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.ACE_TRAINING_COST);
                break;
            case Enums.Unit_Type.CANNONEER:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_CANNONEER);
                Instance.BuildInfoPanelName.text = Constants.CANNONEER_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.CANNONEER_TRAINING_COST);
                break;
            case Enums.Unit_Type.GUARDIAN:
                Instance.BuildInfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUARDIAN);
                Instance.BuildInfoPanelName.text = Constants.GUARDIAN_NAME;
                Instance.UpdateBuildInfoCostsPanel(Constants.GUARDIAN_TRAINING_COST);
                break;
            default:
                break;
        }
    }

    private void UpdateBuildInfoCostsPanel(BuildingCost cost)
    {
        BuilldInfoPanelCost.transform.GetChild(0).gameObject.SetActive(true);
        BuilldInfoPanelCost.transform.GetChild(1).gameObject.SetActive(true);
        BuilldInfoPanelCost.transform.GetChild(4).gameObject.SetActive(true);
        BuilldInfoPanelCost.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredPopulation.ToString();
        BuilldInfoPanelCost.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
        BuilldInfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
        BuilldInfoPanelCost.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
        BuilldInfoPanelCost.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
    }

    private void UpdateBuildInfoCostsPanel(UnitTrainingCost cost, bool isGrunt = false)
    {
        if (isGrunt)
        {
            BuilldInfoPanelCost.transform.GetChild(3).gameObject.SetActive(false);
            BuilldInfoPanelCost.transform.GetChild(0).gameObject.SetActive(true);
            BuilldInfoPanelCost.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
            BuilldInfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
            BuilldInfoPanelCost.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
            BuilldInfoPanelCost.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
        }
        else
        {
            BuilldInfoPanelCost.transform.GetChild(0).gameObject.SetActive(false);
            BuilldInfoPanelCost.transform.GetChild(3).gameObject.SetActive(true);
            BuilldInfoPanelCost.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
            BuilldInfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
            BuilldInfoPanelCost.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
            BuilldInfoPanelCost.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
        }

    }

    public static void EnableInfoPanel()
    {
        Instance.InfoPanel.SetActive(true);
        Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(true);
        Instance.InfoPanel.transform.GetChild(4).gameObject.SetActive(false);
        Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(false);
    }

    public static void DisableInfoPanel()
    {
        Instance.InfoPanel.SetActive(false);
    }

    public static void UpdateInfoPanel(Enums.Building_Type type, float adjustedProduction = 0, float bonusFromNeighbors = 0, float happiness = 0)
    {
        EnableInfoPanel();

        switch (type)
        {
            case Enums.Building_Type.GOD_SEAT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GOD_SEAT);
                Instance.InfoPanelName.text = Constants.GOD_SEAT_NAME;
                Instance.InfoPanelDesc.text = Constants.GOD_SEAT_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(4).gameObject.SetActive(true);
                Instance.UpdateGodSeatCostPanels();
                break;
            case Enums.Building_Type.GARDEN:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.InfoPanelName.text = Constants.GARDEN_NAME;
                Instance.InfoPanelDesc.text = Constants.GARDEN_DESC;
                Instance.UpdateProductionPanels(Constants.FOOD_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.FARM:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.InfoPanelName.text = Constants.FARM_NAME;
                Instance.InfoPanelDesc.text = Constants.FARM_DESC;
                Instance.UpdateProductionPanels(Constants.FOOD_II_PROD, adjustedProduction, Constants.TIER_II_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.ORCHARD:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.InfoPanelName.text = Constants.ORCHARD_NAME;
                Instance.InfoPanelDesc.text = Constants.ORCHARD_DESC;
                Instance.UpdateProductionPanels(Constants.FOOD_III_PROD, adjustedProduction, Constants.TIER_III_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.RANCH:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.InfoPanelName.text = Constants.RANCH_NAME;
                Instance.InfoPanelDesc.text = Constants.RANCH_DESC;
                Instance.UpdateProductionPanels(Constants.FOOD_IV_PROD, adjustedProduction, Constants.TIER_IV_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.HYDROPONICS_TOWER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_FOOD);
                Instance.InfoPanelName.text = Constants.HYDROPONICS_TOWER_NAME;
                Instance.InfoPanelDesc.text = Constants.HYDROPONICS_TOWER_DESC;
                Instance.UpdateProductionPanels(Constants.FOOD_V_PROD, adjustedProduction, Constants.TIER_V_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.HOVEL:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.InfoPanelName.text = Constants.HOVEL_NAME;
                Instance.InfoPanelDesc.text = Constants.HOVEL_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(true);
                Instance.UpdateHousingProdPanels(Constants.HOUSING_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors, happiness);
                break;
            case Enums.Building_Type.COTTAGE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.InfoPanelName.text = Constants.COTTAGE_NAME;
                Instance.InfoPanelDesc.text = Constants.COTTAGE_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(true);
                Instance.UpdateHousingProdPanels(Constants.HOUSING_II_PROD, adjustedProduction, Constants.TIER_II_BONUS, bonusFromNeighbors, happiness);
                break;
            case Enums.Building_Type.APARTMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.InfoPanelName.text = Constants.APARTMENT_NAME;
                Instance.InfoPanelDesc.text = Constants.APARTMENT_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(true);
                Instance.UpdateHousingProdPanels(Constants.HOUSING_III_PROD, adjustedProduction, Constants.TIER_III_BONUS, bonusFromNeighbors, happiness);
                break;
            case Enums.Building_Type.CONDOMINIUM:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.InfoPanelName.text = Constants.CONDO_NAME;
                Instance.InfoPanelDesc.text = Constants.CONDO_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(true);
                Instance.UpdateHousingProdPanels(Constants.HOUSING_IV_PROD, adjustedProduction, Constants.TIER_IV_BONUS, bonusFromNeighbors, happiness);
                break;
            case Enums.Building_Type.VILLA:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POP);
                Instance.InfoPanelName.text = Constants.VILLA_NAME;
                Instance.InfoPanelDesc.text = Constants.VILLA_DESC;
                Instance.InfoPanel.transform.GetChild(3).gameObject.SetActive(false);
                Instance.InfoPanel.transform.GetChild(5).gameObject.SetActive(true);
                Instance.UpdateHousingProdPanels(Constants.HOUSING_V_PROD, adjustedProduction, Constants.TIER_V_BONUS, bonusFromNeighbors, happiness);
                break;
            case Enums.Building_Type.WORKSHOP:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.InfoPanelName.text = Constants.WORKSHOP_NAME;
                Instance.InfoPanelDesc.text = Constants.WORKSHOP_DESC;
                Instance.UpdateProductionPanels(Constants.INDUSTRY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.FORGE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.InfoPanelName.text = Constants.FORGE_NAME;
                Instance.InfoPanelDesc.text = Constants.FORGE_DESC;
                Instance.UpdateProductionPanels(Constants.INDUSTRY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.MILL:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.InfoPanelName.text = Constants.MILL_NAME;
                Instance.InfoPanelDesc.text = Constants.MILL_DESC;
                Instance.UpdateProductionPanels(Constants.INDUSTRY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.FOUNDRY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.InfoPanelName.text = Constants.FOUNDRY_NAME;
                Instance.InfoPanelDesc.text = Constants.FOUNDRY_DESC;
                Instance.UpdateProductionPanels(Constants.INDUSTRY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.FACTORY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_INDUSTRY);
                Instance.InfoPanelName.text = Constants.FACTORY_NAME;
                Instance.InfoPanelDesc.text = Constants.FACTORY_DESC;
                Instance.UpdateProductionPanels(Constants.INDUSTRY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.BARRACKS:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.InfoPanelName.text = Constants.BARRACKS_NAME;
                Instance.InfoPanelDesc.text = Constants.BARRACKS_DESC;
                Instance.UpdateProductionPanels(Constants.MILITARY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.DORMITORY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.InfoPanelName.text = Constants.DORMITORY_NAME;
                Instance.InfoPanelDesc.text = Constants.DORMITORY_DESC;
                Instance.UpdateProductionPanels(Constants.MILITARY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.GARRISON:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.InfoPanelName.text = Constants.GARRISON_NAME;
                Instance.InfoPanelDesc.text = Constants.GARRISON_DESC;
                Instance.UpdateProductionPanels(Constants.MILITARY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.QUARTERS:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.InfoPanelName.text = Constants.QUARTERS_NAME;
                Instance.InfoPanelDesc.text = Constants.QUARTERS_DESC;
                Instance.UpdateProductionPanels(Constants.MILITARY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.HEADQUARTERS:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MILITARY);
                Instance.InfoPanelName.text = Constants.HEADQUARTERS_NAME;
                Instance.InfoPanelDesc.text = Constants.HEADQUARTERS_DESC;
                Instance.UpdateProductionPanels(Constants.MILITARY_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.WATCHTOWER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.InfoPanelName.text = Constants.WATCHTOWER_NAME;
                Instance.InfoPanelDesc.text = Constants.WATCHTOWER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.MISSILE_COMPLEX:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.InfoPanelName.text = Constants.MISSILE_COMPLEX_NAME;
                Instance.InfoPanelDesc.text = Constants.MISSILE_COMPLEX_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.LASER_TOWER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.InfoPanelName.text = Constants.LASER_TOWER_NAME;
                Instance.InfoPanelDesc.text = Constants.LASER_TOWER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.InfoPanelName.text = Constants.AUTO_MISSILE_COMPLEX_NAME;
                Instance.InfoPanelDesc.text = Constants.AUTO_MISSILE_COMPLEX_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.AUTO_LASER_TOWER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENSE);
                Instance.InfoPanelName.text = Constants.AUTO_LASER_TOWER_NAME;
                Instance.InfoPanelDesc.text = Constants.AUTO_LASER_TOWER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.RESEARCH_LAB:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.InfoPanelName.text = Constants.RESEARCH_LAB_NAME;
                Instance.InfoPanelDesc.text = Constants.RESEARCH_LAB_DESC;
                Instance.UpdateProductionPanels(Constants.RESEARCH_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.InfoPanelName.text = Constants.RESEARCH_COLLEGE_NAME;
                Instance.InfoPanelDesc.text = Constants.RESEARCH_COLLEGE_DESC;
                Instance.UpdateProductionPanels(Constants.RESEARCH_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.InfoPanelName.text = Constants.RESEARCH_INSTITUTE_NAME;
                Instance.InfoPanelDesc.text = Constants.RESEARCH_INSTITUTE_DESC;
                Instance.UpdateProductionPanels(Constants.RESEARCH_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.InfoPanelName.text = Constants.MULTIBRAIN_COMPLEX_NAME;
                Instance.InfoPanelDesc.text = Constants.MULTIBRAIN_COMPLEX_DESC;
                Instance.UpdateProductionPanels(Constants.RESEARCH_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.QUANTUM_BRAIN:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_RESEARCH);
                Instance.InfoPanelName.text = Constants.QUANTUM_BRAIN_NAME;
                Instance.InfoPanelDesc.text = Constants.QUANTUM_BRAIN_DESC;
                Instance.UpdateProductionPanels(Constants.RESEARCH_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_I:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.InfoPanelName.text = Constants.EXTRACTOR_MK_I_NAME;
                Instance.InfoPanelDesc.text = Constants.EXTRACTOR_MK_I_DESC;
                Instance.UpdateProductionPanels(Constants.ISOLIUM_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_II:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.InfoPanelName.text = Constants.EXTRACTOR_MK_II_NAME;
                Instance.InfoPanelDesc.text = Constants.EXTRACTOR_MK_II_DESC;
                Instance.UpdateProductionPanels(Constants.ISOLIUM_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_III:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.InfoPanelName.text = Constants.EXTRACTOR_MK_III_NAME;
                Instance.InfoPanelDesc.text = Constants.EXTRACTOR_MK_III_DESC;
                Instance.UpdateProductionPanels(Constants.ISOLIUM_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_IV:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.InfoPanelName.text = Constants.EXTRACTOR_MK_IV_NAME;
                Instance.InfoPanelDesc.text = Constants.EXTRACTOR_MK_IV_DESC;
                Instance.UpdateProductionPanels(Constants.ISOLIUM_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.EXTRACTOR_MK_V:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ISOLIUM);
                Instance.InfoPanelName.text = Constants.EXTRACTOR_MK_V_NAME;
                Instance.InfoPanelDesc.text = Constants.EXTRACTOR_MK_V_DESC;
                Instance.UpdateProductionPanels(Constants.ISOLIUM_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.SHOOTING_RANGE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SHOOTER);
                Instance.InfoPanelName.text = Constants.SHOOTING_RANGE_NAME;
                Instance.InfoPanelDesc.text = Constants.SHOOTING_RANGE_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.DEFENDERS_WALL:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_DEFENDER);
                Instance.InfoPanelName.text = Constants.DEFENDERS_WALL_NAME;
                Instance.InfoPanelDesc.text = Constants.DEFENDERS_WALL_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.GUNNERS_ALLEY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUNNER);
                Instance.InfoPanelName.text = Constants.GUNNERS_ALLEY_NAME;
                Instance.InfoPanelDesc.text = Constants.GUNNERS_ALLEY_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.SNIPERS_NEST:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SNIPER);
                Instance.InfoPanelName.text = Constants.SNIPERS_NEST_NAME;
                Instance.InfoPanelDesc.text = Constants.SNIPERS_NEST_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.SCOUT_CAMP:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SCOUT);
                Instance.InfoPanelName.text = Constants.SCOUT_CAMP_NAME;
                Instance.InfoPanelDesc.text = Constants.SCOUT_CAMP_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.ACES_ARENA:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ACE);
                Instance.InfoPanelName.text = Constants.ACES_ARENA_NAME;
                Instance.InfoPanelDesc.text = Constants.ACES_ARENA_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.CANNONEERS_TOWER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_CANNONEER);
                Instance.InfoPanelName.text = Constants.CANNONEERS_TOWER_NAME;
                Instance.InfoPanelDesc.text = Constants.CANNONEERS_TOWER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_GUARDIAN);
                Instance.InfoPanelName.text = Constants.GUARDIANS_LAST_STAND_NAME;
                Instance.InfoPanelDesc.text = Constants.GUARDIANS_LAST_STAND_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.STOCKPILE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.InfoPanelName.text = Constants.STOCKPILE_NAME;
                Instance.InfoPanelDesc.text = Constants.STOCKPILE_DESC;
                Instance.UpdateProductionPanels(Constants.STORAGE_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.STOREHOUSE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.InfoPanelName.text = Constants.STOREHOUSE_NAME;
                Instance.InfoPanelDesc.text = Constants.STOREHOUSE_DESC;
                Instance.UpdateProductionPanels(Constants.STORAGE_II_PROD, adjustedProduction, Constants.TIER_II_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.WAREHOUSE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.InfoPanelName.text = Constants.WAREHOUSE_NAME;
                Instance.InfoPanelDesc.text = Constants.WAREHOUSE_DESC;
                Instance.UpdateProductionPanels(Constants.STORAGE_III_PROD, adjustedProduction, Constants.TIER_III_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.DEPOT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.InfoPanelName.text = Constants.DEPOT_NAME;
                Instance.InfoPanelDesc.text = Constants.DEPOT_DESC;
                Instance.UpdateProductionPanels(Constants.STORAGE_IV_PROD, adjustedProduction, Constants.TIER_IV_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.DISTRIBUTION_CENTER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_STORAGE);
                Instance.InfoPanelName.text = Constants.DISTRIBUTION_CENTER_NAME;
                Instance.InfoPanelDesc.text = Constants.DISTRIBUTION_CENTER_DESC;
                Instance.UpdateProductionPanels(Constants.STORAGE_V_PROD, adjustedProduction, Constants.TIER_V_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.WATERWHEEL_GENERATOR:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.InfoPanelName.text = Constants.WATERWHEEL_NAME;
                Instance.InfoPanelDesc.text = Constants.WATERWHEEL_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.COAL_FIRED_POWER_PLANT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.InfoPanelName.text = Constants.COAL_FIRED_PLANT_NAME;
                Instance.InfoPanelDesc.text = Constants.COAL_FIRED_PLANT_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.HYDROELECTRIC_DAM:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.InfoPanelName.text = Constants.HYDROELECTRIC_DAM_NAME;
                Instance.InfoPanelDesc.text = Constants.HYDROELECTRIC_DAM_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.NUCLEAR_POWER_PLANT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.InfoPanelName.text = Constants.NUCLEAR_POWER_PLANT_NAME;
                Instance.InfoPanelDesc.text = Constants.NUCLEAR_POWER_PLANT_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.QUANTUM_POWER_PLANT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_POWER);
                Instance.InfoPanelName.text = Constants.QUANTUM_POWER_PLANT_NAME;
                Instance.InfoPanelDesc.text = Constants.QUANTUM_POWER_PLANT_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.PUBLIC_PARK:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.InfoPanelName.text = Constants.PUBLIC_PARK_NAME;
                Instance.InfoPanelDesc.text = Constants.PUBLIC_PARK_DESC;
                Instance.UpdateProductionPanels(Constants.ENTERTAINMENT_I_PROD, adjustedProduction, Constants.TIER_I_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.CIRCUS:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.InfoPanelName.text = Constants.CIRCUS_NAME;
                Instance.InfoPanelDesc.text = Constants.CIRCUS_DESC;
                Instance.UpdateProductionPanels(Constants.ENTERTAINMENT_II_PROD, adjustedProduction, Constants.TIER_II_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.THEATER_COMPLEX:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.InfoPanelName.text = Constants.THEATER_NAME;
                Instance.InfoPanelDesc.text = Constants.THEATER_DESC;
                Instance.UpdateProductionPanels(Constants.ENTERTAINMENT_III_PROD, adjustedProduction, Constants.TIER_III_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.VIRTUAL_REALITY_CAFE:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.InfoPanelName.text = Constants.VIRTUAL_REALITY_CAFE_NAME;
                Instance.InfoPanelDesc.text = Constants.VIRTUAL_REALITY_CAFE_DESC;
                Instance.UpdateProductionPanels(Constants.ENTERTAINMENT_IV_PROD, adjustedProduction, Constants.TIER_IV_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.QUANTUM_HOLOGRAM_THEATER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_ENTERTAINMENT);
                Instance.InfoPanelName.text = Constants.QUANTUM_THEATER_NAME;
                Instance.InfoPanelDesc.text = Constants.QUANTUM_THEATER_DESC;
                Instance.UpdateProductionPanels(Constants.ENTERTAINMENT_V_PROD, adjustedProduction, Constants.TIER_V_BONUS, bonusFromNeighbors);
                break;
            case Enums.Building_Type.VOID_PORTAL:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.VOID_PORTAL_NAME;
                Instance.InfoPanelDesc.text = Constants.VOID_PORTAL_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.VOID_COMMUNICATOR:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.VOID_COMMUNICATOR_NAME;
                Instance.InfoPanelDesc.text = Constants.VOID_COMMUNICATOR_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.VOID_RADAR_ARRAY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.VOID_RADAR_ARRAY_NAME;
                Instance.InfoPanelDesc.text = Constants.VOID_RADAR_ARRAY_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.FACTION_EMBASSY:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.FACTION_EMBASSY_NAME;//TODO will need to add name of faction to this
                Instance.InfoPanelDesc.text = Constants.FACTION_EMBASSY_DESC;//TODO will need to add name of faction to this
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.ABYSSAL_PATHFINDER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.ABYSSAL_PATHFINDER_NAME;
                Instance.InfoPanelDesc.text = Constants.ABYSSAL_PATHFINDER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.VOID_RUDDER:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.VOID_RUDDER_NAME;
                Instance.InfoPanelDesc.text = Constants.VOID_RUDDER_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.WEATHER_MANIPULATOR:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_SPECIAL);
                Instance.InfoPanelName.text = Constants.WEATHER_MANIPULATOR_NAME;
                Instance.InfoPanelDesc.text = Constants.WEATHER_MANIPULATOR_DESC;
                Instance.UpdateProductionPanels(-1, -1, -1, -1);
                break;
            case Enums.Building_Type.DIPLO_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.DIPLO_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.DIPLO_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.SCI_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.SCI_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.SCI_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.HAPP_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.HAPP_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.HAPP_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.IND_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.IND_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.IND_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.ISO_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.ISO_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.ISO_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.MIL_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.MIL_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.MIL_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            case Enums.Building_Type.FOOD_MONUMENT:
                Instance.InfoPanelImage.sprite = Prefab_Manager.GetImage(Enums.Images.ICON_MONUMENT);
                Instance.InfoPanelName.text = Constants.FOOD_MONUMENT_NAME;//TODO names?
                Instance.InfoPanelDesc.text = Constants.FOOD_MONUMENT_DESC;//TODO desc?
                Instance.UpdateProductionPanels(-1, -1, -1, -1);//TODO uhh, this will hurt
                break;
            default:
                break;
        }
    }

    private void UpdateGodSeatCostPanels()
    {
        InfoPanelGodSeatLevel.text = Resource_Manager.Instance.GodSeatLevel.ToString();
        InfoPanelGodSeatHexRange.text = Resource_Manager.Instance.MaximumHexRange.ToString();
        InfoPanelGodSeatIsoliumCost.text = Resource_Manager.Instance.GodSeatUpgradeIsoliumCost.ToString();
        InfoPanelGodSeatIndustryCost.text = Resource_Manager.Instance.GodSeatUpgradeIndustryCost.ToString();
        InfoPanelGodSeatFoodCost.text = Resource_Manager.Instance.GodSeatUpgradeFoodCost.ToString();
        InfoPanelGodSeatPopCost.text = Resource_Manager.Instance.GodSeatUpgradePopCost.ToString();
    }

    private void UpdateHousingProdPanels(float baseProd, float adjProd, float bonusToNeighbors, float bonusFromNeighbors, float happiness)
    {
        InfoPanelHousingBaseProd.text = baseProd.ToString();
        InfoPanelHousingAdjProd.text = adjProd.ToString();
        InfoPanelHousingBonusToOthers.text = "+" + (bonusToNeighbors * 100) + "%";
        InfoPanelHousingBonusFromOthers.text = "+" + (bonusFromNeighbors * 100) + "%";
        InfoPanelHousingHappiness.text = happiness.ToString();
    }

    private void UpdateProductionPanels(float baseProd, float adjProd, float bonusToNeighbors, float bonusFromNeighbors)
    {
        ///may need own override for defense hexes
        if(baseProd == -1)
        {
            InfoPanelBaseProd.text = "N/A";
        }
        else
        {
            InfoPanelBaseProd.text = baseProd.ToString();
        }
        
        if(adjProd == -1)
        {
            InfoPanelAdjProd.text = "N/A";
        }
        else
        {
            InfoPanelAdjProd.text = adjProd.ToString();
        }

        if(bonusToNeighbors == -1)
        {
            InfoPanelBonusToOthers.text = "N/A";
        }
        else
        {
            InfoPanelBonusToOthers.text = "+" + (bonusToNeighbors * 100) + "%";
        }

        if(bonusFromNeighbors == -1)
        {
            InfoPanelBonusFromOthers.text = "N/A";
        }
        else
        {
            InfoPanelBonusFromOthers.text = "+" + (bonusFromNeighbors * 100) + "%";
        }
    }

    public static void EnableCityOverviewPanel()
    {
        Instance.CityOverviewPanel.SetActive(true);
        Instance.UpdateCityOverviewPanel();
    }

    public static void DisableCityOverviewPanel()
    {
        Instance.CityOverviewPanel.SetActive(false);
    }

    private void UpdateCityOverviewPanel()
    {
        FoodProdText.text = Resource_Manager.Instance.FoodProduction.ToString();
        PopGrowthText.text = Resource_Manager.Instance.PopulationGrowthRate.ToString();
        IndustryProdText.text = Resource_Manager.Instance.IndustryProduction.ToString();
        IsoliumProdText.text = Resource_Manager.Instance.IsoliumProduction.ToString();
        ResearchSpeedText.text = Resource_Manager.Instance.ResearchProduction.ToString();
        ShooterCostReducText.text = ((1 - Resource_Manager.Instance.ShooterTrainingCostReduction) * 100) + "%";
        DefenderCostReducText.text = ((1 - Resource_Manager.Instance.DefenderTrainingCostReduction) * 100) + "%";
        GunnerCostReducText.text = ((1 - Resource_Manager.Instance.GunnerTrainingCostReduction) * 100) + "%";
        SniperCostReducText.text = ((1 - Resource_Manager.Instance.SniperTrainingCostReduction) * 100) + "%";
        ScoutCostReducText.text = ((1 - Resource_Manager.Instance.ScoutTrainingCostReduction) * 100) + "%";
        MaxAceCountText.text = Resource_Manager.Instance.MaximumAces.ToString();
        MaxCannoneerCountText.text = Resource_Manager.Instance.MaximumCannoneers.ToString();
        MaxGuardianCountText.text = Resource_Manager.Instance.MaximumGuardians.ToString();
        MaxHexRangeText.text = Resource_Manager.Instance.MaximumHexRange.ToString();
    }

    public static void UpdateResourcesText()
    {
        SetAvailablePopulationText(Resource_Manager.Instance.CurrentPopulation, Resource_Manager.Instance.MaximumPopulation);
        SetAvailableFoodText(Resource_Manager.Instance.CurrentFood, Resource_Manager.Instance.MaximumFood);
        SetAvailableIndustryText(Resource_Manager.Instance.CurrentIndustry, Resource_Manager.Instance.MaximumIndustry);
        SetAvailableMilitaryText(Resource_Manager.Instance.CurrentMilitary, Resource_Manager.Instance.MaximumMilitary);
        SetAvailableIsoliumText(Resource_Manager.Instance.CurrentIsolium, Resource_Manager.Instance.MaximumIsolium);
    }

    public static void SetAvailablePopulationText(int currPop, int maxPop)
    {
        Instance.AvailablePopText.text = currPop + " / " + maxPop;
    }

    public static void SetAvailableFoodText(int food, int maxFood)
    {
        Instance.AvailableFoodText.text = food + " / " + maxFood;
    }

    public static void SetAvailableIndustryText(int industry, int maxIndustry)
    {
        Instance.AvailableIndustryText.text = industry + " / " + maxIndustry;
    }

    public static void SetAvailableMilitaryText(int currMilitary, int maxMilitary)
    {
        Instance.AvailableMilitaryText.text = currMilitary + " / " + maxMilitary;
    }

    public static void SetAvailableIsoliumText(int isolium, int maxIsolium)
    {
        Instance.AvailableIsoliumText.text = isolium + " / " + maxIsolium;
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
        if (!Instance.FoodTextFlashing && Resource_Manager.Instance.CurrentFood < cost.RequiredFood)
        {
            Instance.FoodTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableFoodImage, Instance.EndFoodFlashing));
        }

        if (!Instance.PopTextFlashing && Resource_Manager.Instance.CurrentPopulation < cost.RequiredPopulation)
        {
            Instance.PopTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailablePopImage, Instance.EndPopFlashing));
        }

        if (!Instance.IndustryTextFlashing && Resource_Manager.Instance.CurrentIndustry < cost.RequiredIndustry)
        {
            Instance.IndustryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIndustryImage, Instance.EndIndustryFlashing));
        }

        if (!Instance.MilitaryTextFlashing && Resource_Manager.Instance.CurrentMilitary < cost.RequiredMilitary)
        {
            Instance.MilitaryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableMilitaryImage, Instance.EndMilitaryFlashing));
        }

        if (!Instance.IsoliumTextFlashing && Resource_Manager.Instance.CurrentIsolium < cost.RequiredIsolium)
        {
            Instance.IsoliumTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIsoliumImage, Instance.EndIsoliumFlashing));
        }
    }

    public static void FlashMissingResources(UnitTrainingCost cost)
    {
        //if is Ace/Cannoneer/Guardian and does not have corresponding space
        if (!Instance.AceTextFlashing && cost.SpecialUnitType == 1 && Resource_Manager.Instance.AceCount + cost.RequiredMilitary > Resource_Manager.Instance.MaximumAces)
        {
            Instance.AceTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AceButtonImage, Instance.EndAceFlashing));
        }

        if (!Instance.CannoneerTextFlashing && cost.SpecialUnitType == 2 && Resource_Manager.Instance.CannoneerCount + cost.RequiredMilitary > Resource_Manager.Instance.MaximumCannoneers)
        {
            Instance.CannoneerTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.CannoneerButtonImage, Instance.EndCannoneerFlashing));
        }

        //Debug.Log(Instance.GuardianTextFlashing + " :: " + cost.SpecialUnitType + " :: " + Resource_Manager.Instance.GuardianCount + " :: " + cost.RequiredMilitary + " :: " + Resource_Manager.Instance.MaximumGuardians);

        if (!Instance.GuardianTextFlashing && cost.SpecialUnitType == 3 && Resource_Manager.Instance.GuardianCount + cost.RequiredMilitary > Resource_Manager.Instance.MaximumGuardians)
        {
            //Debug.Log("derp");
            Instance.GuardianTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.GuardianButtonImage, Instance.EndGuardianFlashing));
        }

        if (!Instance.PopTextFlashing && Resource_Manager.Instance.CurrentPopulation < cost.RequiredMilitary)
        {
            Instance.PopTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailablePopImage, Instance.EndPopFlashing));
        }

        if (!Instance.FoodTextFlashing && Resource_Manager.Instance.CurrentFood < cost.RequiredFood)
        {
            Instance.FoodTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableFoodImage, Instance.EndFoodFlashing));
        }

        if (!Instance.IndustryTextFlashing && Resource_Manager.Instance.CurrentIndustry < cost.RequiredIndustry)
        {
            Instance.IndustryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableIndustryImage, Instance.EndIndustryFlashing));
        }

        if (!Instance.MilitaryTextFlashing && Resource_Manager.Instance.CurrentMilitary + cost.RequiredMilitary > Resource_Manager.Instance.MaximumMilitary)
        {
            Instance.MilitaryTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailableMilitaryImage, Instance.EndMilitaryFlashing));
        }

        if (!Instance.IsoliumTextFlashing && Resource_Manager.Instance.CurrentIsolium < cost.RequiredIsolium)
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

    private void EndAceFlashing()
    {
        AceTextFlashing = false;
    }

    private void EndCannoneerFlashing()
    {
        CannoneerTextFlashing = false;
    }

    private void EndGuardianFlashing()
    {
        GuardianTextFlashing = false;
    }

    public static void ShowPausePanel()
    {
        Instance.PausedPanel.SetActive(true);
    }

    public static void HidePausePanel()
    {
        Instance.PausedPanel.SetActive(false);
    }
}
