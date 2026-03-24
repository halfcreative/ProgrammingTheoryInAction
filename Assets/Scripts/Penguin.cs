using UnityEngine;

// Penguin is a child class of Animal, demonstrating INHERITANCE.
public class Penguin : Animal
{
    private void Awake()
    {
        AnimalName = "Penguin";
    }

    public override void MakeSound()
    {
        Debug.Log("The penguin makes a squawking sound.");
    }

    public override void Eat()
    {
        HungerLevel -= 25; // Penguins love fish.
        Debug.Log($"{AnimalName} gulps down a fish.");
    }
}
