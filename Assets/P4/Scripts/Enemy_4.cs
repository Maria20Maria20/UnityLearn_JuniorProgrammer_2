using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    private GameObject player; 
    private Rigidbody enemyRB;
    [SerializeField] private float speed; //скорость перемещения врага

    [SerializeField] private bool isBoss = false; //по дефолту босс не появляется в начале игры
    [SerializeField] private float spawnInterval; 
    private float nextSpawn; 
    public int miniEnemySpawnCount; //тут указаны мини-враги, которых спаунит босс
    private SpawnManager_4 spawnManager; 

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>(); 
        player = GameObject.Find("Player");

        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpawnManager_4>(); 
        }
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        enemyRB.AddForce(lookDirection * speed * Time.deltaTime);

        if (transform.position.y < -3) 
        {
            Destroy(gameObject); 
        }

        if (isBoss) 
        {
            if (Time.time > nextSpawn) 
            {
                nextSpawn = Time.time + spawnInterval; 
                spawnManager.SpawnMiniEnemy(miniEnemySpawnCount); 
            }
        }
    }

}
