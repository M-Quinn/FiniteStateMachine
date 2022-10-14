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
    }

}
