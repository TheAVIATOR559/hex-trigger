using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent_Mask : MonoBehaviour
{
    private Material maskMat;

    private void Awake()
    {
        maskMat = transform.GetChild(0).GetComponent<Renderer>().material;
    }

    public void SetScale(float x, float y, float z)
    {
        transform.localScale = new Vector3(x, y, z);
    }

    public void SetFillValue(float amount)
    {
        maskMat.SetFloat("_Fill_Rate", amount);
    }
}
