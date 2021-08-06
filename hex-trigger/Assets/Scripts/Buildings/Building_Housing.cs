using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Housing : Building
{
    public int Happiness = 0;

    public void AddHappiness(int amount)
    {
        Happiness += amount;
        Resource_Manager.AddPopGrowth(amount);
    }

    public void RemoveHappiness(int amount)
    {
        Happiness -= amount;
        Resource_Manager.RemovePopGrowth(amount);
    }
}
