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

    private GameObject InfoPanel;
    private Image InfoPanelImage;
    private TMP_Text InfoPanelName;
    private GameObject InfoPanelCost;

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

    private GameObject currTierPanel;

    private bool HexTextFlashing = false;
    private bool PopTextFlashing = false;
    private bool FoodTextFlashing = false;
    private bool IndustryTextFlashing = false;
    private bool MilitaryTextFlashing = false;
    private bool IsoliumTextFlashing = false;
    private bool AceTextFlashing = false;
    private bool CannoneerTextFlashing = false;
    private bool GuardianTextFlashing = false;

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

        InfoPanel = CityCanvas.transform.GetChild(11).gameObject;
        InfoPanelImage = InfoPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        InfoPanelName = InfoPanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        InfoPanelCost = InfoPanel.transform.GetChild(0).GetChild(2).gameObject;

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
        AceButtonImage = MilitaryPanel.transform.GetChild(6).GetComponent<Image>();
        CannoneerCountText = MilitaryPanel.transform.GetChild(7).GetChild(1).GetComponent<TMP_Text>();
        CannoneerButtonImage = MilitaryPanel.transform.GetChild(7).GetComponent<Image>();
        GuardianCountText = MilitaryPanel.transform.GetChild(8).GetChild(1).GetComponent<TMP_Text>();
        GuardianButtonImage = MilitaryPanel.transform.GetChild(8).GetComponent<Image>();

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
        Instance.InfoPanel.SetActive(false);

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

    public static void EnableInfoPanel()
    {
        Instance.InfoPanel.SetActive(true);
        Instance.InfoPanelImage.gameObject.SetActive(false);
        Instance.InfoPanelName.gameObject.SetActive(false);
        Instance.InfoPanelCost.SetActive(false);
    }

    public static void DisableInfoPanel()
    {
        Instance.InfoPanel.SetActive(false);
    }

    public static void UpdateInfoPanel(Enums.Building_Type type)
    {
        Instance.InfoPanelImage.gameObject.SetActive(true);
        Instance.InfoPanelName.gameObject.SetActive(true);
        Instance.InfoPanelCost.SetActive(true);

        switch (type)
        {
            case Enums.Building_Type.GARDEN:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GARDEN_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GardenCost);
                break;
            case Enums.Building_Type.FARM:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.FARM_NAME;
                Instance.UpdateInfoCostsPanel(Constants.FarmCost);
                break;
            case Enums.Building_Type.ORCHARD:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.ORCHARD_NAME;
                Instance.UpdateInfoCostsPanel(Constants.OrchardCost);
                break;
            case Enums.Building_Type.RANCH:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.RANCH_NAME;
                Instance.UpdateInfoCostsPanel(Constants.RanchCost);
                break;
            case Enums.Building_Type.HOVEL:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.HOVEL_NAME;
                Instance.UpdateInfoCostsPanel(Constants.HovelCost);
                break;
            case Enums.Building_Type.COTTAGE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.COTTAGE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.CottageCost);
                break;
            case Enums.Building_Type.APARTMENT:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.APARTMENT_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ApartmentCost);
                break;
            case Enums.Building_Type.CONDOMINIUM:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.CONDO_NAME;
                Instance.UpdateInfoCostsPanel(Constants.CondoCost);
                break;
            case Enums.Building_Type.WORKSHOP:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.WORKSHOP_NAME;
                Instance.UpdateInfoCostsPanel(Constants.WorkshopCost);
                break;
            case Enums.Building_Type.FORGE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.FORGE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ForgeCost);
                break;
            case Enums.Building_Type.MILL:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.MILL_NAME;
                Instance.UpdateInfoCostsPanel(Constants.MillCost);
                break;
            case Enums.Building_Type.FOUNDRY:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.FOUNDRY_NAME;
                Instance.UpdateInfoCostsPanel(Constants.FoundryCost);
                break;
            case Enums.Building_Type.BARRACKS:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.BARRACKS_NAME;
                Instance.UpdateInfoCostsPanel(Constants.BarracksCost);
                break;
            case Enums.Building_Type.DORMITORY:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.DORMITORY_NAME;
                Instance.UpdateInfoCostsPanel(Constants.DormitoryCost);
                break;
            case Enums.Building_Type.GARRISON:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GARRISON_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GarrisonCost);
                break;
            case Enums.Building_Type.QUARTERS:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.QUARTERS_NAME;
                Instance.UpdateInfoCostsPanel(Constants.QuartersCost);
                break;
            case Enums.Building_Type.WATCHTOWER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.WATCHTOWER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.WatchTowerCost);
                break;
            case Enums.Building_Type.MISSILE_COMPLEX:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.MISSILE_COMPLEX_NAME;
                Instance.UpdateInfoCostsPanel(Constants.MissileComplexCost);
                break;
            case Enums.Building_Type.LASER_TOWER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.LASER_TOWER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.LaserTowerCost);
                break;
            case Enums.Building_Type.AUTO_MISSILE_COMPLEX:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.AUTO_MISSILE_COMPLEX_NAME;
                Instance.UpdateInfoCostsPanel(Constants.AutoMissileComplexCost);
                break;
            case Enums.Building_Type.AUTO_LASER_TOWER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.AUTO_LASER_TOWER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.AutoLaserTowerCost);
                break;
            case Enums.Building_Type.RESEARCH_LAB:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.RESEARCH_LAB_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ResearchLabCost);
                break;
            case Enums.Building_Type.RESEARCH_COLLEGE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.RESEARCH_COLLEGE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ResearchCollegeCost);
                break;
            case Enums.Building_Type.RESEARCH_INSTITUTE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.RESEARCH_INSTITUTE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ResearchInstituteCost);
                break;
            case Enums.Building_Type.MULTIBRAIN_COMPLEX:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.MULTIBRAIN_COMPLEX_NAME;
                Instance.UpdateInfoCostsPanel(Constants.MultiBrainCost);
                break;
            case Enums.Building_Type.STOCKPILE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.STOCKPILE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.StockpileCost);
                break;
            case Enums.Building_Type.STOREHOUSE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.STOREHOUSE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.StorehouseCost);
                break;
            case Enums.Building_Type.WAREHOUSE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.WAREHOUSE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.WarehouseCost);
                break;
            case Enums.Building_Type.DEPOT:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.DEPOT_NAME;
                Instance.UpdateInfoCostsPanel(Constants.DepotCost);
                break;
            case Enums.Building_Type.SHOOTING_RANGE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SHOOTING_RANGE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ShootingRangeCost);
                break;
            case Enums.Building_Type.DEFENDERS_WALL:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.DEFENDERS_WALL_NAME;
                Instance.UpdateInfoCostsPanel(Constants.DefendersWallCost);
                break;
            case Enums.Building_Type.GUNNERS_ALLEY:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GUNNERS_ALLEY_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GunnersAlleyCost);
                break;
            case Enums.Building_Type.SNIPERS_NEST:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SNIPERS_NEST_NAME;
                Instance.UpdateInfoCostsPanel(Constants.SnipersNestCost);
                break;
            case Enums.Building_Type.SCOUT_CAMP:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SCOUT_CAMP_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ScoutCampCost);
                break;
            case Enums.Building_Type.ACES_ARENA:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.ACES_ARENA_NAME;
                Instance.UpdateInfoCostsPanel(Constants.AcesArenaCost);
                break;
            case Enums.Building_Type.CANNONEERS_TOWER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.CANNONEERS_TOWER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.CannoneersTowerCost);
                break;
            case Enums.Building_Type.GUARDIANS_LAST_STAND:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GUARDIANS_LAST_STAND_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GuardiansLastStandCost);
                break;
            case Enums.Building_Type.GOD_SEAT:
            case Enums.Building_Type.HYDROPONICS_TOWER:
            case Enums.Building_Type.VILLA:
            case Enums.Building_Type.FACTORY:
            case Enums.Building_Type.HEADQUARTERS:
            case Enums.Building_Type.QUANTUM_BRAIN:
            case Enums.Building_Type.DISTRIBUTION_CENTER:
            default:
                break;
        }
    }

    public static void UpdateInfoPanel(Enums.Unit_Type type)
    {
        Instance.InfoPanelImage.gameObject.SetActive(true);
        Instance.InfoPanelName.gameObject.SetActive(true);
        Instance.InfoPanelCost.SetActive(true);

        switch (type)
        {
            case Enums.Unit_Type.GRUNT:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GRUNT_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GRUNT_TRAINING_COST, true);
                break;
            case Enums.Unit_Type.SHOOTER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SHOOTER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.SHOOTER_TRAINING_COST);
                break;
            case Enums.Unit_Type.DEFENDER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.DEFENDER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.DEFENDER_TRAINING_COST);
                break;
            case Enums.Unit_Type.GUNNER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GUNNER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GUNNER_TRAINING_COST);
                break;
            case Enums.Unit_Type.SNIPER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SNIPER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.SNIPER_TRAINING_COST);
                break;
            case Enums.Unit_Type.SCOUT:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.SCOUT_NAME;
                Instance.UpdateInfoCostsPanel(Constants.SCOUT_TRAINING_COST);
                break;
            case Enums.Unit_Type.ACE:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.ACE_NAME;
                Instance.UpdateInfoCostsPanel(Constants.ACE_TRAINING_COST);
                break;
            case Enums.Unit_Type.CANNONEER:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.CANNONEER_NAME;
                Instance.UpdateInfoCostsPanel(Constants.CANNONEER_TRAINING_COST);
                break;
            case Enums.Unit_Type.GUARDIAN:
                //Instance.InfoPanelImage = LOAD IMAGE HERE
                Instance.InfoPanelName.text = Constants.GUARDIAN_NAME;
                Instance.UpdateInfoCostsPanel(Constants.GUARDIAN_TRAINING_COST);
                break;
            default:
                break;
        }
    }

    private void UpdateInfoCostsPanel(BuildingCost cost)
    {
        InfoPanelCost.transform.GetChild(0).gameObject.SetActive(true);
        InfoPanelCost.transform.GetChild(1).gameObject.SetActive(true);
        InfoPanelCost.transform.GetChild(4).gameObject.SetActive(true);
        InfoPanelCost.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredHexes.ToString();
        InfoPanelCost.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredPopulation.ToString();
        InfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
        InfoPanelCost.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
        InfoPanelCost.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
        InfoPanelCost.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
    }

    private void UpdateInfoCostsPanel(UnitTrainingCost cost, bool isGrunt = false)
    {
        if (isGrunt)
        {
            InfoPanelCost.transform.GetChild(0).gameObject.SetActive(false);
            InfoPanelCost.transform.GetChild(4).gameObject.SetActive(false);
            InfoPanelCost.transform.GetChild(1).gameObject.SetActive(true);
            InfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
            InfoPanelCost.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
            InfoPanelCost.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
            InfoPanelCost.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
        }
        else
        {
            InfoPanelCost.transform.GetChild(0).gameObject.SetActive(false);
            InfoPanelCost.transform.GetChild(1).gameObject.SetActive(false);
            InfoPanelCost.transform.GetChild(4).gameObject.SetActive(true);
            InfoPanelCost.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredFood.ToString();
            InfoPanelCost.transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIndustry.ToString();
            InfoPanelCost.transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredMilitary.ToString();
            InfoPanelCost.transform.GetChild(5).GetChild(1).GetComponent<TMP_Text>().text = cost.RequiredIsolium.ToString();
        }

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
        if (!Instance.HexTextFlashing && Resource_Manager.Instance.AvailableHexes < cost.RequiredHexes)
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

        if (!Instance.PopTextFlashing && Resource_Manager.Instance.AvailablePopulation < cost.RequiredMilitary)
        {
            Instance.PopTextFlashing = true;
            Instance.StartCoroutine(Instance.FlashRed(Instance.AvailablePopImage, Instance.EndPopFlashing));
        }

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
}
