using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject powerupPrefab;

    private float startDelay = 2;
    private float spawnIntervalEnemy = 3.5f;
    private float spawnIntervalPowerup = 20.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnIntervalEnemy);
        InvokeRepeating("SpawnPowerup", startDelay, spawnIntervalPowerup);
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int x = Random.Range(-10, 10);
        Instantiate(enemyPrefabs[enemyIndex], new Vector3(x,1,24.2f), enemyPrefabs[enemyIndex].transform.rotation);

    }

    void SpawnPowerup()
    {
        int xz = Random.Range(-10, 10);
        Instantiate(powerupPrefab, new Vector3(xz, 1, xz), powerupPrefab.transform.rotation);
    }
}
