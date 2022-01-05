using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_5 : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] private string inputID; //переменная для определения какого игрока надо перемещать (1 - для первого игрока,2 - для второго игрока)
    [SerializeField] float speed = 20.0f; 
    [SerializeField] float turnSpeed = 20.0f; 
    private float horizontalInput; 
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID); 

        rigidBody.velocity = Vector3.forward * speed; 
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); 
    }
}
