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

Now, you can have a list of `Animal` objects, and when you call `animal.Eat()` on each one, it will perform the correct action (Lion eats meat chunk, zebra eats grass) without you needing to know the specific type.

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

To meet the project requirements and create a complete, simple game loop, the minimum viable product will include:

### Core Gameplay Mechanics
*   A score or "Zoo Happiness" metric that changes based on animal welfare.
*   Animals' hunger increases over time, which negatively affects the score.
*   Player can click on an animal to select it.
*   Player can click a "Feed" button for a selected animal to decrease its hunger and increase the score.
*   A simple "Game Over" condition (e.g., score drops to zero or a timer runs out).

### OOP Implementation
*   A base `Animal` class demonstrating **encapsulation** for its properties (like hunger).
*   At least two specific animal classes (e.g., `Lion`, `Snake`) demonstrating **inheritance**.
*   A `virtual` method in the base class (e.g., `MakeSound()`) that is overridden in child classes to demonstrate **polymorphism**.
*   A manager script (e.g., `GameManager` or `Zookeeper`) with simple methods like `FeedAnimal()` to demonstrate **abstraction**.

### UI / User Experience
*   A Main Menu scene with "Start Game" and "Quit Game" buttons.
*   A persistent UI in the main game scene to display the current score/happiness and game timer (if applicable).
*   A simple UI panel that appears when an animal is selected, showing its stats and action buttons.
*   A Game Over screen that displays the final score and provides "Restart" and "Quit" options.

### Art & Assets
*   Simple 3D models for at least two animal types (can be primitive shapes like spheres and cubes).
*   A simple plane or terrain for the zoo ground.
*   Basic sound effects for at least one animal action (e.g., eating or making a sound).

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