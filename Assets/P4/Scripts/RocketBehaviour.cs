using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    //в этом скрипте содержится логика самонаводящихся ракет, которыми стреляет персонаж игрока во врагов
    private Transform target; //позиция цели, на которую будет направлена самонаводящаяся ракета (позиция врагов)
    private float speed = 15.0f; //скорость самонаводящейся ракеты
    private bool homing; //проверка, используются ли самонаводящиеся ракеты

    private float rocketStrength = 15.0f; //сила удара ракеты
    private float aliveTimer = 1.0f; //кол-во секунд, когда снаряд будет находиться в игре после того, как вылетел за пределы экрана

    void Update()
    {
        if (homing && target != null) 
        {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized; 
            transform.position += moveDirection * speed * Time.deltaTime; 
            transform.LookAt(target); 
        }
    }

    public void Fire(Transform newTarget) //функция для стреляния ракетами
    {
        target = newTarget; 
        homing = true; 
        Destroy(gameObject,aliveTimer);
    }

    void OnCollisionEnter(Collision col) 
    {
        if (target != null) 
        {
            if (col.gameObject.CompareTag(target.tag)) 
            {
                Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>(); 
                Vector3 away = -col.contacts[0].normal;
                targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse); 
                Destroy(gameObject); 
            }
        }
    }
}
