using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Hex_Button : MonoBehaviour
{
    [SerializeField] Enums.Hex_Types hexType;

    public void OnClick()
    {
        //highlight available hex locations
        City_Manager.ActivateAvailableHexHighlights();

        //instantiate hex blueprint based on hex type
        City_Manager.Instance.hexBlueprint = Instantiate(Prefab_Manager.GetPrefab(Enums.HexTypeToPrefab(hexType)), Hex.GetWorldCoordFromHexCoord(City_Manager.Instance.availbleHexPositions[0]), Quaternion.Euler(-90, 0, 0)).AddComponent<Hex_Blueprint>();

        //disable place hex panel
        UI_Manager.DisablePlaceHexPanel();
    }
}
