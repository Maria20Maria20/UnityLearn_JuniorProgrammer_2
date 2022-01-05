using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    Rigidbody rigidBody; 
    private float speed = 20.0f; //скорость движени€ бота
    [SerializeField] private float timer = 10.0f; //таймер. Ќужен дл€ удалени€ ботов, которые уже прошли мимо персонажа игрока

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        timer -= Time.deltaTime; 
        if (timer < 0) 
        {
            Destroy(gameObject); 
        }

        rigidBody.velocity = new Vector3(0,0,-1) * speed; 
    }
}
