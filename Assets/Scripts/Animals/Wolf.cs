using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal, IAnimal
{
    protected override void Start()
    {
        base.Start();
        _foodTag = "Bunny";
        UI_Stats.UpdateFood(FoodType.Wolf, 1);
    }
    public override void Die()
    {
        UI_Stats.UpdateFood(FoodType.Wolf, -1);
    }
}
