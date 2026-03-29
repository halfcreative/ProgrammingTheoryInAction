using UnityEngine;

// The Animal class serves as the base (parent) class for all specific animal types in the zoo.
// It demonstrates INHERITANCE by providing common properties and methods that child classes can inherit and extend.
public class Animal : MonoBehaviour
{
    // ENCAPSULATION: Internal data (like _animalName, _hungerLevel) is kept private.
    // Public properties (getters/setters) provide controlled access.
    // This prevents external scripts from setting invalid values (e.g., negative hunger).

    [SerializeField]
    private string _animalName = "Animal";
    public string AnimalName
    {
        get { return _animalName; }
        protected set { _animalName = value; } // Child classes can change the name if needed
    }

    [SerializeField]
    private int _age = 1;
    public int Age
    {
        get { return _age; }
        protected set { _age = value; }
    }

    [SerializeField]
    private float _hungerLevel = 50f; // Represents hunger from 0 (full) to 100 (starving)
    public float HungerLevel
    {
        get { return _hungerLevel; }
        protected set
        {
            _hungerLevel = Mathf.Clamp(value, 0, 100);
        }
    }

    [SerializeField]
    private float hungerIncreaseRate = 2f; // How many hunger points per second


    private void Update()
    {
        // Hunger increases over time, a basic simulation of animal needs.
        HungerLevel += hungerIncreaseRate * Time.deltaTime;

        if (HungerLevel >= 100)
        {
            Die();
        }
    }


    // --- OOP Principle Demonstrations ---

    // ABSTRACTION & POLYMORPHISM: This is a virtual method that can be overridden by child classes.
    // A Zookeeper can call Eat() on any animal without knowing the specific implementation.
    public virtual void Eat()
    {
        HungerLevel -= 30;
        Debug.Log($"{AnimalName} eats some food.");
    }

    // POLYMORPHISM: This virtual method is intended to be overridden by each specific
    // animal type to produce a unique sound.
    public virtual void MakeSound()
    {
        Debug.Log("The animal makes a generic sound.");
    }

    private void Die()
    {
        Debug.Log($"{AnimalName} has starved!");
        GameManager.Instance.AnimalDied(this);
        GameManager.Instance.GameOver(); // Triggers the game over state
        Destroy(gameObject);
    }
}
