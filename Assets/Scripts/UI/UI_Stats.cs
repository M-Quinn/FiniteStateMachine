using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stats : MonoBehaviour
{
    [SerializeField] TMP_Text _totalFood_Text, _totalBunny_Text, _totalWolf_Text;

    int _totalFood = 0, _totalBunny = 0, _totalWolf = 0;

    public static Action<FoodType, int> UpdateFood;
    private void OnEnable()
    {
        UpdateFood += UpdateTotals;
    }

    private void UpdateTotals(FoodType foodType, int amount) {
        switch (foodType){
            case FoodType.Food:
                _totalFood+= amount;
                _totalFood_Text.text = _totalFood.ToString();
                break;
            case FoodType.Bunny: 
                _totalBunny += amount;
                _totalBunny_Text.text = _totalBunny.ToString();
                break;
            case FoodType.Wolf: 
                _totalWolf += amount;
                _totalWolf_Text.text = _totalWolf.ToString();
                break;
            default:
                Debug.LogError("Update Total_ FoodType error");
                break;
        }
    }
}
public enum FoodType { Food, Bunny, Wolf}
