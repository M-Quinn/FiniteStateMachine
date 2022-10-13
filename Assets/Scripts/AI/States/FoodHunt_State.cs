using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHunt_State : IState
{
    GameObject food;
    GameObject self;
    float speed;
    Bunny bunnyScript;

    public FoodHunt_State(Bunny bunnyScript, GameObject self, float speed) {
        this.bunnyScript = bunnyScript;
        this.self = self;
        this.speed = speed;
    }

    public void Execute()
    {
        var direction = food.transform.position - self.transform.position;
        direction.Normalize();
        self.transform.Translate(direction * speed * Time.deltaTime);
    }

    public void OnEnter()
    {
        food = bunnyScript.GetFoodObject();
    }

    public void OnExit()
    {
        
    }
}
