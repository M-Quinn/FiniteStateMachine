using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimal 
{
    void DieFromStarvation();
    void FoodIsGone();
    GameObject GetFoodObject();

}
