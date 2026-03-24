# Programming Theory In Action
The final project of the Unity Junior Programmer Pathway
https://learn.unity.com/pathway/junior-programmer/unit/apply-object-oriented-principles/tutorial/submission-programming-theory-in-action?version=6.0

## Project Submission Guidelines
    A successful submission will include:

    A link to your project’s GitHub repo, showing multiple commits with commit messages and at least two branches
    Demonstration of abstraction (higher-level methods that abstract unnecessary details)
    Demonstration of inheritance (parent/child classes)
    Demonstration of polymorphism (method overriding or overloading)
    Demonstration of encapsulation (getters and setters)

---

## Game Idea: My First Zoo

The player manages a small zoo. They can add different types of animals to habitats. Each animal has unique behaviors, sounds, and needs. The player's job is to keep the animals happy by feeding them and taking care of them.

### How it Demonstrates OOP Principles

#### 1. Inheritance (Parent/Child Classes)

This is a perfect scenario for inheritance. We can create a base `Animal` class with common properties and methods, and then create specific animal types that inherit from it.

*   **`Animal` (Parent Class):**
    *   Properties: `name`, `age`, `hungerLevel`
    *   Methods: `Eat()`, `Sleep()`, `MakeSound()`

*   **`Lion` (Child of `Animal`):**
    *   Inherits all properties and methods from `Animal`.
    *   Could have a specific property like `maneSize`.

*   **`Snake` (Child of `Animal`):**
    *   Inherits from `Animal`.
    *   Could have a specific property like `isVenomous`.

#### 2. Polymorphism (Method Overriding)

With our inherited classes, we can override methods to give each animal unique behavior.

*   The base `Animal` class has a `virtual` method: `public virtual void Eat()`.
*   In the `Lion` class, we **override** it: `public override void Eat() { // Logic to check for correct food }`

Now, you can have a list of `Animal` objects, and when you call `animal.MakeSound()` on each one, it will perform the correct action (roar, hiss, etc.) without you needing to know the specific type.

#### 3. Encapsulation (Getters and Setters)

We need to protect the internal state of our animals. We don't want another script to be able to set an animal's health to a negative number, for example.

*   In the `Animal` class, we would declare health as a `private` variable: `private int health;`
*   We then provide controlled, `public` access to it via properties (getters and setters): `public int Health { get; private set; }`
*   We can then have public methods to modify the state safely: `public void TakeDamage(int amount) { if (amount > 0) { Health -= amount; } }`

#### 4. Abstraction (Higher-Level Methods)

Abstraction is about hiding complex implementation details behind a simple interface. A `Player` or `Zookeeper` script would be a great place to demonstrate this.

*   Imagine a `Zookeeper` script with a simple public method: `public void FeedAnimal(Animal animalToFeed)`.
*   Inside this method, you would call `animalToFeed.Eat()`. The `Zookeeper` doesn't need to know *how* the animal eats or what happens to its `hungerLevel`. The complexity is abstracted away.

---

## MVP Objectives

To meet the project requirements, the minimum viable product will include:

*   A base `Animal` class.
*   At least two specific animal classes inheriting from `Animal` (e.g., `Lion`, `Snake`).
*   Clear implementation of all four OOP principles.
*   Simple 3D models for at least two animal types (can be primitive shapes).
*   A simple plane or terrain for the zoo ground.
*   Basic UI to display a selected animal's information (name, hunger, etc.).
*   Player interaction to perform at least one action (e.g., a "Feed" button).

## Stretch Goals

If time permits, the following features would be great additions:

*   **Programming:**
    *   More diverse animal types with unique properties.
    *   Different types of food, with animals having preferences.
    *   A "happiness" metric for animals.
    *   A `Zookeeper` class to manage player actions and inventory.
    *   Saving and loading the zoo's state.
*   **Art & Visuals:**
    *   More detailed 3D models for animals and a zookeeper character.
    *   Animations for animal behaviors (eating, sleeping, making sounds).
    *   Habitat models (enclosures, trees, water sources).
    *   Particle effects for feedback (e.g., hearts for happiness).
    *   A simple day/night cycle.
*   **Audio:**
    *   Sound effects for animal actions and UI interactions.
    *   Ambient background music or environmental sounds.
*   **Gameplay:**
    *   Player movement/control of the zookeeper character.
    *   A simple economy system for buying animals and food.
    *   More complex UI, including an inventory system.