using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_4 : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; //�������� ����������� ��������� ������
    [SerializeField] private float forwardInput;
    [SerializeField] private bool hasPowerup; //���������� ��� ����, ���� ������, ���� � ��������� ������ ��������� ��� ��� (������ �� � �� ����� ��� ���) 
    [SerializeField] private GameObject powerupIndicator; //������� ������ ���������� ��� ��������� (��������, ������� ����������, ��� ���� ���������)
    [SerializeField] private PowerUpType currentPowerUp = PowerUpType.None; //������������ ����� PowerUp

    [SerializeField] private GameObject rocketPrefab; 
    private GameObject tmpRocket; //���������� ��� ����������� �������� ������� ������
    private Coroutine powerupCountdown; //�������� ������ ��� ��������� ��������� (� ��������� ��������������� �����)

    [SerializeField] private float hangTime; //�����, ����� �������� ������ ��� ������ ��������� � ����������� ���������
    [SerializeField] private float smashSpeed; //�������� ����� ��� ������ �����
    [SerializeField] private float explosionForce; //���� ������ ��� ��������� ������ ���������
    [SerializeField] private float explosionRadius; //������, �� ������� ���������������� ����� ��������� ������ ���������
    bool smashing = false; 
    float floorY;

    private Rigidbody playerRB; 
    private GameObject focalPoint; //����� ��� �������� ������ ��
    private float powerupStrength = 15.0f; //���-�� ������, �� ������� �������� ���� ��� ���������� � ���� ���������

    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); 
        focalPoint = GameObject.Find("FocalPoint"); 
    }

    void Update()
    {
        if (transform.position.y < -3) //���� �������� ������ ������ �� ������� ����, ��:
        {
            transform.position = new Vector3(0, 0.42f, 0); //��������� ��� � �������� �������
        }

        forwardInput = Input.GetAxis("Vertical2"); 
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position; 
        if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F)) 
        {
            LaunchRockets(); 
        }
        if (currentPowerUp == PowerUpType.Smash && Input.GetKeyDown(KeyCode.Space) && !smashing) 
        {
            smashing = true; 
            StartCoroutine(Smash()); 
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup")) 
        {
            hasPowerup = true; 
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType; 
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            if (powerupCountdown != null) 
            {
                StopCoroutine(powerupCountdown); 
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine()); 
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp==PowerUpType.Pushback) 
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); 
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); 

            Debug.Log("Player collided with"+collision.gameObject.name+" with powerup set to "+currentPowerUp.ToString()); 
        }
        if (collision.gameObject.CompareTag("EnemyPower")) 
        {
            Rigidbody playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>(); 
            Vector3 awayFromPlayer = (transform.position - collision.gameObject.transform.position); 
            playerRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); 
            Debug.Log("Collided with" + collision.gameObject.name + " with powerup set to" + hasPowerup); 
        }
    }
    void LaunchRockets() //������� ��� ������� ��������������� �����
    {
        foreach(var enemy in FindObjectsOfType<Enemy_4>())
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity); 
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform); 
        }
    }
    IEnumerator PowerupCountdownRoutine() 
    {
        yield return new WaitForSeconds(7); 
        hasPowerup = false; 
        currentPowerUp = PowerUpType.None; 
        powerupIndicator.gameObject.SetActive(false);
    }
    IEnumerator Smash() 
    {
        var enemies = FindObjectsOfType<Enemy_4>(); 
        floorY = transform.position.y; 
        float jumpTime = Time.time + hangTime; 

        while (Time.time < hangTime) 
        {
            playerRB.velocity = new Vector2(playerRB.transform.position.x, smashSpeed); 
            yield return null; 
        }

        while (transform.position.y > floorY)
        {
            playerRB.velocity = new Vector2(playerRB.transform.position.x, -smashSpeed*2); 
            yield return null; 
        }

        for(int i = 0; i < enemies.Length; i++) 
        {
            if (enemies != null) 
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
        smashing = false; 
    }
}
