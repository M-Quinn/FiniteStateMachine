using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField][Tooltip("The Maximum amount that the animal can eat")]
    int _hungerMax = 50;
    [SerializeField][Tooltip("The level at which the animal will begin looking for food")]
    int _hungerLevel;
    [SerializeField][Tooltip("The Current Hunger")]
    int _currentHunger;
    public bool IsHungry { get; private set; } = false;
    public bool IsStarving { get; private set; } = false;

    private void Start()
    {
        StartCoroutine(DecreaseHunger());
    }

    private void Update()
    {
        IsHungry = (_currentHunger <= _hungerLevel);
        IsStarving = (_currentHunger <= 0);
    }

    public void Eat() {
        _currentHunger = _hungerMax;
    }

    IEnumerator DecreaseHunger() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            _currentHunger--;
        }
    }

}
