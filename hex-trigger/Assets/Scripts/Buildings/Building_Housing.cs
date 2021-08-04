using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Housing : Building
{
    [SerializeField] int Happiness = 0;

    public void AddHappiness(int amount)
    {
        Happiness += amount;
    }

    public void RemoveHappiness(int amount)
    {
        if(Happiness - amount <= 0)
        {
            Happiness = 0;
        }
        else
        {
            Happiness -= amount;
        }
    }
}
