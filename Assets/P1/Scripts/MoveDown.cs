using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Rigidbody objectRb;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < -25) //���� ������� �������, � �������� ��������� ������ (�����) ������ -25, ��:
        {
            Destroy(gameObject); 
        }
    }
}
