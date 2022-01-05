using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_4 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab; //������ ������� �������� ��� ������ ������
    [SerializeField] private GameObject[] powerupPrefabs; //������ ������� �������� ���������
    [SerializeField] private int enemyCount; //���������� �������� ������ �� �����
    [SerializeField] private int waveNumber = 1; //�� ������� ������ ������� �����

    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject[] miniEnemyPrefabs; //������ ����-������, ������� ������� ����
    [SerializeField] private int bossRound; //����� ������� ������� �������� ����

    private float spawnRange = 5.0f; //����������� ��������� ������� ��� ��������� �����

    void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length); 
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        SpawnEnemyWave(waveNumber);
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy_4>().Length; 
        if (enemyCount == 0) 
        {
            waveNumber++; 
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber); 
            }
            else 
            {
                SpawnEnemyWave(waveNumber); 
            }
            int randomPowerup = Random.Range(0, powerupPrefabs.Length); 
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange); 
        float z = Random.Range(0, spawnRange); 
        Vector3 randomPos = new Vector3(x, 0.6f, z); 
        return randomPos;                                                                                                                                                                                                                                                                               
    }

    void SpawnEnemyWave(int enemiesToSpawn) //����� ������
    {

        for(int i = 0; i < enemiesToSpawn; i++) 
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation); 

        }
    }

    void SpawnBossWave(int currentRound) 
    {
        int miniEnemysToSpawn; 
        if (bossRound != 0) 
        {
            miniEnemysToSpawn = currentRound / bossRound; 
        }
        else 
        {
            miniEnemysToSpawn = 1; 
        }

        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation); 
        boss.GetComponent<Enemy_4>().miniEnemySpawnCount = miniEnemysToSpawn; 
    }

    public void SpawnMiniEnemy(int amount) //����� ����-������
    {
        for(int i = 0; i < amount; i++) 
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(), miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }
}
