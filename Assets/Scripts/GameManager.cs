using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private List<GameObject> animalPrefabs; // Assign Tiger, Penguin, Deer prefabs in Inspector
    [Header("Spawn Ranges")]
    [SerializeField]
    private float spawnRangeX_Lower = 10f;
    [SerializeField]
    private float spawnRangeX_Upper = 20f;
    [SerializeField]
    private float spawnRangeZ = 10f;
    [Header("Game Settings")]
    [SerializeField]
    private int initialAnimalCount = 3;
    [SerializeField]
    private int pointsPerFeed = 10;

    private List<Animal> spawnedAnimals = new List<Animal>();
    private int score = 0;
    private int scoreToSpawnNextAnimal = 50;
    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Spawn initial animals
        for (int i = 0; i < initialAnimalCount; i++)
        {
            SpawnAnimal();
        }
    }

    public void SpawnAnimal()
    {
        if (isGameOver) return;
        if (animalPrefabs == null || animalPrefabs.Count == 0)
        {
            Debug.LogError("Animal prefabs list is not assigned or empty in GameManager.");
            return;
        }

        int randomIndex = Random.Range(0, animalPrefabs.Count);
        GameObject prefabToSpawn = animalPrefabs[randomIndex];

        // Calculate spawn position with new range logic
        float randomX = Random.Range(spawnRangeX_Lower, spawnRangeX_Upper);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);

        GameObject animalGO = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Animal animalComp = animalGO.GetComponent<Animal>();

        if (animalComp != null)
        {
            spawnedAnimals.Add(animalComp);
            Debug.Log($"Spawned a {animalComp.AnimalName}. Total animals: {spawnedAnimals.Count}");
        }
    }

    public void AnimalDied(Animal animal)
    {
        if (spawnedAnimals.Contains(animal))
        {
            spawnedAnimals.Remove(animal);
        }
    }

    public void AddScoreOnFeed()
    {
        if (isGameOver) return;
        score += pointsPerFeed;
        Debug.Log($"Score: {score}");

        if (score >= scoreToSpawnNextAnimal)
        {
            Debug.Log("Score threshold reached! Spawning a new animal.");
            SpawnAnimal();
            // Increase the score needed for the next spawn
            scoreToSpawnNextAnimal += 50;
        }
    }

    public void GameOver()
    {
        if (isGameOver) return; // Don't run game over logic multiple times

        isGameOver = true;
        Debug.Log("Game Over! Final Score: " + score);
        Time.timeScale = 0; // Pause the game
    }
}
