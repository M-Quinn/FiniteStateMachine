using System;
using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour, IAnimal
{
    Hunger _hunger;
    Reproduce _reproduce;
    [SerializeField] LayerMask _foodMask;
    [SerializeField] float _speed = 2.5f;
    GameObject _foodFound;
    Vector3 _wanderPosition;
    StateMachine _stateMachine;
    public string _foodTag = "";

    [SerializeField]
    int _amountToReproduce;
    int _amountEaten = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _hunger = GetComponent<Hunger>();
        _reproduce = GetComponent<Reproduce>();
        _stateMachine = new StateMachine();


        var WanderingState = new Wander_State(_speed, this.gameObject);
        var FoodHuntState = new FoodHunt_State(this, gameObject, _speed);

        Func<bool> FoundFood() => () => _foodFound != null;
        Func<bool> NoFood() => () => _foodFound == null;

        _stateMachine.AddTransition(FoodHuntState, WanderingState, NoFood());
        _stateMachine.AddTransition(WanderingState, FoodHuntState, FoundFood());

        _stateMachine.SetState(WanderingState);

    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Execute();

        if (_hunger.HungerLevel <= 25)
        {
            StartCoroutine(FindFood(_foodMask));
        }
    }

    public GameObject GetFoodObject()
    {
        return _foodFound;
    }
    public void FoodIsGone()
    {
        _foodFound = null;
    }

    IEnumerator FindFood(LayerMask foodMask) {
        var radius = 5;
        while (_foodFound == null) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, foodMask);
            foreach (var hitCollider in hitColliders)
            {
                _foodFound = hitCollider.gameObject;
                break;
            }
            yield return null;
            radius += 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(_foodTag))
        {
            _amountEaten++;
            _hunger.Eat();
            if (collision.transform.TryGetComponent(out Animal animal))
            {
                animal.Die();
            }
            else
                UI_Stats.UpdateFood(FoodType.Food, -1);
            Destroy(collision.gameObject);
            if (_amountEaten >= _amountToReproduce)
            {
                _reproduce.ReproduceAnimal(transform.position);
                _amountEaten = 0;
            }
        }
    }

    virtual public void Die()
    {

    }
}

