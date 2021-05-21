using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Defense : Building
{
    [SerializeField] private GameObject RangeHighlighter;

    public override void Initalize()
    {
        base.Initalize();

        RangeHighlighter.SetActive(false);
    }
    //TODO implement me
}
