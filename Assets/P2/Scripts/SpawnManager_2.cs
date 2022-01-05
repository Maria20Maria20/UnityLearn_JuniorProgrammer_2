using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_2 : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs; 

    private float startDelay = 2; //сколько секунд спустя будут генерироваться объекты 
    private float spawnInterval = 1.5f; //интервал для спауна (то есть каждые 1.5 секунды будет генерироваться новый объект)
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int x = Random.Range(-10, 10);
        Instantiate(animalPrefabs[animalIndex], new Vector3(x, 20, 0), animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int y = Random.Range(3, 10);
        Vector3 rotation = new Vector3(0, 0, 90);
        Instantiate(animalPrefabs[animalIndex], new Vector3(-20, y, 0), Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int y = Random.Range(3, 10);
        Vector3 rotation = new Vector3(0, 0, -90);
        Instantiate(animalPrefabs[animalIndex], new Vector3(20, y, 0), Quaternion.Euler(rotation));
    }
}
