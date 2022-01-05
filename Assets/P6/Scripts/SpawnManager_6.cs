using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_6 : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; 

    private float startDelay = 2; 
    private float spawnInterval = 2; 
    private Vector3 spawnPos = new Vector3(25, 0, 0); 
    private PlayerController_6 playerControllerScript; 

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval); 
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController_6>(); 
    }


    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
