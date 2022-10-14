using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int _health;
    int HealthLevel { get => _health; }

    private void TakeDamageFromAnimal() {
        //for simplicity one hit kills
        _health = 0;
        //destroy object
    }
}
