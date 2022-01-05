using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0; //при старте у игрока нет очков
    private int lives = 3; //при старте у игрока 3 ХП

    public void AddLives(int value) //функция для отображения изменения кол-ва ХП (жизней)
    {
        lives += value;
        if (lives <= 0) 
        {
            Debug.Log("Жизни закончились, ты проиграл!");
            lives = 0;
        }
        Debug.Log("Lives=" + lives);

    }

    public void AddScore(int value) //функция для отображения изменения кол-ва очков
    {
        score += value; 
        Debug.Log("Score=" + score);
    }

}
