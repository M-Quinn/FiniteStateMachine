using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject _foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood() {
        while (true) {
            yield return new WaitForSeconds(1.5f);
            var location = new Vector3(Random.Range(-49, 50), 0, Random.Range(-49, 50));
            UI_Stats.UpdateFood(FoodType.Food, 1);
            Instantiate(_foodPrefab, location, Quaternion.identity);
        }
    }
}
