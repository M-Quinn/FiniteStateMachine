using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField]
    int _hungerMax = 50;
    [SerializeField]
    int _hungerLevel;
    public int HungerLevel { get => _hungerLevel; }

    private void Start()
    {
        StartCoroutine(DecreaseHunger());
    }

    public void Eat() {
        _hungerLevel = _hungerMax;
    }

    IEnumerator DecreaseHunger() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            _hungerLevel--;
        }
    }

}
