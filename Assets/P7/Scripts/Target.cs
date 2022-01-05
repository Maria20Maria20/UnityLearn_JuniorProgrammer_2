using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb; 
    private GameManager_1 gameManager; 
    private float minSpeed = 102; //минимальная скорость объекта, к которому прикреплён этот скрипт
    private float maxSpeed = 106; //максимальная скорость объекта, к которому прикреплён этот скрипт
    private float maxTorque = 10; //максимальное вращение объекта, к которому прикреплён этот скрипт
    private float xRange = 4; //позиция по оси Х
    private float ySpawnPos = 3; //позиция по оси Y

    public int pointValue; //сколько очков прибавляет объект, к которому прикреплён этот скрипт (каждый объект разное кол-во очков даёт)
    public ParticleSystem explosionParticle; //эффект взрыва

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_1>(); 
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);  
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 
        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown() 
    {
        if (gameManager.isGameActive&&!gameManager.paused) //если игра активна и не на паузе, то:
        {
            Destroy(gameObject); 
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //спаунится эффект взрыва по позиции объекта, к которому прикреплён этот скрипт
            gameManager.UpdateScore(pointValue); //кол-во очков увеличивается на то, которое указано в иерархии каждого объекта, к которым прикреплён этот скрипт
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); 
        if (!gameObject.CompareTag("Bad")) 
        {
            gameManager.lives -= 1; 
            gameManager.UpdateLives(3); 
        }
    }

    public void DestroyTarget() //функция для удаления объектов, к которым прикреплён этот скрипт
    {
        if (gameManager.isGameActive) 
        {
            Destroy(gameObject); 
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); 
            gameManager.UpdateScore(pointValue); 
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed) * Time.deltaTime;

    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque); 
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0); 

    }
}
