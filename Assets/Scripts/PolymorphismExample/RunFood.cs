using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFood : MonoBehaviour
{
    List<IFood> _foods = new List<IFood>();
    
    // Start is called before the first frame update
    void Start()
    {
        _foods.Add(new Burgers());
        _foods.Add(new Tacos());
        foreach (IFood food in _foods) {
            food.WhatAmI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
