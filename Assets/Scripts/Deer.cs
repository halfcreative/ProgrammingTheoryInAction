using UnityEngine;

// Deer is a child class of Animal, demonstrating INHERITANCE.
public class Deer : Animal
{
    private void Awake()
    {
        AnimalName = "Deer";
    }

    public override void MakeSound()
    {
        Debug.Log("The deer makes a gentle call.");
    }

    public override void Eat()
    {
        HungerLevel -= 20; // Deer are grazers.
        Debug.Log($"{AnimalName} grazes on some grass.");
    }
}
