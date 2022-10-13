using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander_State : IState
{
    Vector3 wanderPosition;
    GameObject self;
    float speed;

    public Wander_State(float speed, GameObject self) {
        this.self = self;
        this.speed = speed;
    }

    public void Execute()
    {
        var direction = wanderPosition - self.transform.position;
        direction.Normalize();
        self.transform.Translate(direction * speed * Time.deltaTime);
        //If reached destination, get new destination
        if (Vector3.Distance(self.transform.position, wanderPosition) <= 1)
        {
            GetWanderPosition();
        }
    }

    private void GetWanderPosition()
    {
        wanderPosition = new Vector3(Random.Range(-49, 50), 0, Random.Range(-49, 50));
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

}
