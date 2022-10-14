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
                SetText(_totalFood_Text, _totalFood, amount);
                break;
            case FoodType.Bunny: 
                _totalBunny += amount;
                SetText(_totalBunny_Text, _totalBunny, amount);
                break;
            case FoodType.Wolf: 
                _totalWolf += amount;
                SetText(_totalWolf_Text, _totalWolf, amount);
                break;
            default:
                Debug.LogError("Update Total_ FoodType error");
                break;
        }
    }

    private void SetText(TMP_Text textBox, int total, int amount) {
        if (amount > 0)
        {
            StartCoroutine(FlashText(textBox, true));
            textBox.text = total.ToString();
        }
        else {
            StartCoroutine(FlashText(textBox, false));
            textBox.text = total.ToString();
        }
    }

    IEnumerator FlashText(TMP_Text textbox, bool isPositive) {
        if (isPositive) 
            textbox.color = Color.green;
        else
            textbox.color = Color.red;

        yield return new WaitForSeconds(1);

        textbox.color = Color.white;
    }
}
public enum FoodType { Food, Bunny, Wolf}
