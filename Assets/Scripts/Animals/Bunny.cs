using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Animal, IAnimal
{
    protected override void Start()
    {
        base.Start();
        _foodTag = "Food";
        UI_Stats.UpdateFood(FoodType.Bunny, 1);
    }
    public override void Die()
    {
        UI_Stats.UpdateFood(FoodType.Bunny, -1);
    }
}
