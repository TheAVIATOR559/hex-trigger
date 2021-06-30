using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Power : Building
{
    [SerializeField] private GameObject RangeHighlighter;

    public override void Initalize()
    {
        base.Initalize();

        RangeHighlighter.SetActive(false);
    }

    public override void DetermineBuildingTier()
    {
        //short circuit
    }

    //todo power implementation

    ///<summary> Power Implementation Needs
    /// Total range of power distribution :: provided as Constants.POWER_TIER_PROD
    /// List of Hexes that are recieving power :: only used on creation and destruction ??better way to do it??
    /// Building will need a bool for if they are receiving power :: will need to add integration of power bool to effects and resource prod
    /// Will need a way of getting hexes within a circular radius :: ?? rejig hex offset into a cube coord system (https://www.redblobgames.com/grids/hexagons/)
    /// </summary>
}
