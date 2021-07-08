using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military_Unit_Panel : MonoBehaviour
{
    private void OnEnable()
    {
        UI_Manager.UpdateUnitCountText();
    }
}
