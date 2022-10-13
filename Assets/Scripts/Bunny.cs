using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    Hunger _hunger;
    Reproduce _reproduce;
    [SerializeField] LayerMask _foodMask;
    [SerializeField] float _speed = 2.5f;
    GameObject _foodFound;
    Vector3 _wanderPosition;
    // Start is called before the first frame update
    void Start()
    {
        _hunger = GetComponent<Hunger>();
        _reproduce = GetComponent<Reproduce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_foodFound != null)
        {
            var direction = _foodFound.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * _speed * Time.deltaTime);
        }
        else if (_hunger.HungerLevel <= 25)
        {
            FindFood(transform.position, 25f, _foodMask);
        }
        else if (_wanderPosition == null)
        {
            GetWanderPosition();
        }
        else if (_wanderPosition != null) {
            var direction = _wanderPosition - transform.position;
            direction.Normalize();
            transform.Translate(direction * _speed * Time.deltaTime);
            //If reached destination, get new destination
            if (Vector3.Distance(transform.position, _wanderPosition) <= 1) {
                GetWanderPosition();
            }
        }
    }

    private void FindFood(Vector3 center, float radius, LayerMask foodMask)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, foodMask);
        foreach (var hitCollider in hitColliders)
        {
            _foodFound = hitCollider.gameObject;
            break;
        }
    }

    private void GetWanderPosition() {
        _wanderPosition = new Vector3(Random.Range(-49, 50), 0, Random.Range(-49, 50));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Food")) {
            _hunger.Eat();
            Destroy(collision.gameObject);
            Debug.Log("Collided with food");
        }
    }
}
