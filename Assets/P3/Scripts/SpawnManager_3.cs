using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3 : MonoBehaviour
{
    [SerializeField] private GameObject[] spherePrefab;

    void Start()
    {
        InvokeRepeating("SpawnSphere", 1, 5);
    }

    void SpawnSphere()
    {
        int index = Random.Range(0, spherePrefab.Length);
        Instantiate(spherePrefab[index], new Vector3(0, 14, 0), spherePrefab[index].transform.rotation);
    }
}
