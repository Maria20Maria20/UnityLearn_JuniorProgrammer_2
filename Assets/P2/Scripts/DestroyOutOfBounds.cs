using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //этот скрипт нужен для удаления объектов, которые за пределами экрана находятся
    private float topBound = 20; //ограничитель. тут указывается в какой точке объект будет удалён 
    private float rightleftBound = 20; //ограничитель для животных, идущих по горизонтали
    private GameManager gameManager; 

    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (transform.position.y > topBound || transform.position.y < -topBound) 
        {
            if (transform.position.y < -topBound)
            {
                gameManager.AddLives(-1); 
                Destroy(gameObject);
            }

            gameObject.SetActive(false);
        }

        if (transform.position.x > rightleftBound || transform.position.x < -rightleftBound)
        {
            gameManager.AddLives(-1); 
            Destroy(gameObject); 

        }


    }
}
