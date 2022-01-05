using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //���� ������ ���������� ��������� ����� (����������� � ����) ��� �������� ������� ��������
    private float speed = 10.0f; //�������� �����������
    private PlayerController_6 playerControllerScript; 
    private float leftBound = -20.0f; //��������� �����������, ��� ������� �� ��� �� ����� �� �����

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController_6>();  
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)  
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);  
         }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))  
         {
            Destroy(gameObject);  
        }

    }
}
