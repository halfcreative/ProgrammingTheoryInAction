using UnityEngine;

// Tiger is a child class of Animal, demonstrating INHERITANCE.
public class Tiger : Animal
{
    private void Awake()
    {
        // Set properties specific to this animal type.
        AnimalName = "Tiger";
    }

    // POLYMORPHISM: This method overrides the base Animal's MakeSound() method.
    // When MakeSound() is called on a Tiger instance, this specific version will be executed.
    public override void MakeSound()
    {
        Debug.Log("The tiger lets out a mighty ROAR!");
    }

    // POLYMORPHISM: We can also override the Eat method for specific behavior.
    public override void Eat()
    {
        HungerLevel -= 40; // Tigers are big eaters!
        Debug.Log($"{AnimalName} devours a large piece of meat.");
    }
}
