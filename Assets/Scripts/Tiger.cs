using UnityEngine;

// Tiger is a child class of Animal, demonstrating INHERITANCE.
public class Tiger : Animal
{
    private void Awake()
    {
        AnimalName = "Tiger";
    }

    public override void MakeSound()
    {
        Debug.Log("The tiger lets out a mighty ROAR!");
    }

    public override void Eat()
    {
        HungerLevel -= 40; // Tigers are big eaters!
        Debug.Log($"{AnimalName} devours a large piece of meat.");
    }
}
