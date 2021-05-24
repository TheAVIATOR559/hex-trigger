using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hex_Type_Button : MonoBehaviour
{
    [SerializeField] GameObject panelToEnable;

    [SerializeField] List<Button> parentButtons = new List<Button>();

    private bool IsSelected = false;
    private Button myButton;

    private void Awake()
    {
        foreach(Transform child in transform.parent)
        {
            if(child != transform)
            {
                parentButtons.Add(child.GetComponent<Button>());
            }
        }
        myButton = GetComponent<Button>();
    }

    public void OnClick()
    {
        if(panelToEnable.activeSelf)
        {
            DisableTierPanel();
        }
        else
        {
            EnableTierPanel();
        }
    }

    public void EnableTierPanel()
    {
        panelToEnable.SetActive(true);
        IsSelected = true;
        foreach(Button button in parentButtons)
        {
            button.interactable = false;
        }
    }

    public void DisableTierPanel()
    {
        panelToEnable.SetActive(false);
        IsSelected = false;
        foreach(Button button in parentButtons)
        {
            button.interactable = true;
        }
    }

    private void OnDisable()
    {
        myButton.interactable = true;
    }

    private void Update()
    {
        if(IsSelected)
        {
            if(Input.GetMouseButtonUp(1))
            {
                DisableTierPanel();
            }
        }
    }
}
