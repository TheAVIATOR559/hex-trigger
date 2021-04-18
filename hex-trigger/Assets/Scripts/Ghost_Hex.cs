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
        Debug.Log("Entered a hex");
        City_Manager.Instance.hexBlueprint.MoveToHex(this);
    }

    private void OnMouseExit()
    {
        Debug.Log("Moved off a hex");
        City_Manager.Instance.hexBlueprint.RemoveFromHex();
    }
}
