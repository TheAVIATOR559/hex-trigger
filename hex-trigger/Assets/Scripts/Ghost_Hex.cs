using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Hex : MonoBehaviour
{
    public Vector2Int hexCoord;
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnMouseEnter()
    {
        //set hollow version of hex type
        City_Manager.Instance.hexBlueprint.MoveToHex(this);
    }

    private void OnMouseExit()
    {
        //clear hollow version of hex type
        City_Manager.Instance.hexBlueprint.RemoveFromHex();
    }
}
