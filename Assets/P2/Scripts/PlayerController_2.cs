using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed = 10.0f; //скорость перемещения персонажа игрока
    [SerializeField] private float xRange = 10; //ограничитель движения по горизонтали
    [SerializeField] private float yMin; //минимальное значение положения персонажа игрока по вертикали
    [SerializeField] private float yMax; //максимальное значение положения персонажа игрока по вертикали
    [SerializeField] private Transform projectileSpawnPoint; 


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal1");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); 
        verticalInput = Input.GetAxis("Vertical2");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        if (transform.position.x < -xRange) 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) 
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); 
        }

        if (transform.position.y < yMin) 
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }



        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject pooledProjectile = ObjectPool.SharedInstance.GetPooledObject(); 
            if (pooledProjectile != null) 
            {
                pooledProjectile.transform.position = projectileSpawnPoint.transform.position; 
                pooledProjectile.SetActive(true); 
            }

        }

    }


}
