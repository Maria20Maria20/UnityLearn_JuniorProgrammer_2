using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb; 
    private GameManager_1 gameManager; 
    private float minSpeed = 102; //����������� �������� �������, � �������� ��������� ���� ������
    private float maxSpeed = 106; //������������ �������� �������, � �������� ��������� ���� ������
    private float maxTorque = 10; //������������ �������� �������, � �������� ��������� ���� ������
    private float xRange = 4; //������� �� ��� �
    private float ySpawnPos = 3; //������� �� ��� Y

    public int pointValue; //������� ����� ���������� ������, � �������� ��������� ���� ������ (������ ������ ������ ���-�� ����� ���)
    public ParticleSystem explosionParticle; //������ ������

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
        if (gameManager.isGameActive&&!gameManager.paused) //���� ���� ������� � �� �� �����, ��:
        {
            Destroy(gameObject); 
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //��������� ������ ������ �� ������� �������, � �������� ��������� ���� ������
            gameManager.UpdateScore(pointValue); //���-�� ����� ������������� �� ��, ������� ������� � �������� ������� �������, � ������� ��������� ���� ������
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

    public void DestroyTarget() //������� ��� �������� ��������, � ������� ��������� ���� ������
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
