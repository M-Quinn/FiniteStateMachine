using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHunt_State : IState
{
    GameObject food;
    GameObject self;
    float speed;
    IAnimal animalScript;

    public FoodHunt_State(IAnimal animalScript, GameObject self, float speed) {
        this.animalScript = animalScript;
        this.self = self;
        this.speed = speed;
    }

    public void Execute()
    {
        if (food == null)
        {
            animalScript.FoodIsGone();
        }
        else {
            var direction = food.transform.position - self.transform.position;
            direction.Normalize();
            self.transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }

    public void OnEnter()
    {
        food = animalScript.GetFoodObject();
    }

    public void OnExit()
    {
        
    }
}
