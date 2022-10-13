using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduce : MonoBehaviour
{
    [SerializeField] GameObject _AnimalPrefab;

    public void ReproduceAnimal(Vector3 location) {
        location.x += 1;//Adds offset
        Instantiate(_AnimalPrefab, location, Quaternion.identity);
    }
}
