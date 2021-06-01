using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Highlighter : MonoBehaviour
{
    [SerializeField] float VerticalOffset;
    [SerializeField] Color GodSeatColor;
    [SerializeField] Color HousingColor;
    [SerializeField] Color FoodColor;
    [SerializeField] Color IndustryColor;
    [SerializeField] Color IsoliumColor;
    [SerializeField] Color ResearchColor;
    [SerializeField] Color MilitaryColor;
    [SerializeField] Color DefenseColor;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        City_Manager.Instance.hexHighlight = this;
        this.gameObject.SetActive(false);
    }

    public void MoveToHex(Hex hex)
    {
        transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + VerticalOffset, hex.transform.position.z);

        SetColor(hex.ConnectedBuilding.HexType);
    }

    public void SetColor(Enums.Hex_Types type)
    {
        switch (type)
        {
            case Enums.Hex_Types.FOOD:
                rend.material.color = FoodColor;
                break;
            case Enums.Hex_Types.HOUSING:
                rend.material.color = HousingColor;
                break;
            case Enums.Hex_Types.INDUSTRY:
                rend.material.color = IndustryColor;
                break;
            case Enums.Hex_Types.MILITARY:
                rend.material.color = MilitaryColor;
                break;
            case Enums.Hex_Types.RESEARCH:
                rend.material.color = ResearchColor;
                break;
            case Enums.Hex_Types.ISOLIUM:
                rend.material.color = IsoliumColor;
                break;
            case Enums.Hex_Types.DEFENSE:
                rend.material.color = DefenseColor;
                break;
            case Enums.Hex_Types.GOD_SEAT:
                rend.material.color = GodSeatColor;
                break;
            default:
                rend.material.color = Color.white;
                break;
        }
    }
}
