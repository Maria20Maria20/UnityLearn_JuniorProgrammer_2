using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //этот скрипт нужен для настройки уровней: лёгкого, среднего и сложного
    private Button button; //кнопки сложности
    private GameManager_1 gameManager;
    [SerializeField] private int difficulty; //переменная для установки сложности игры. Для EasyButton = 1, MediumButton = 2, HardButton = 3
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_1>();
        button.onClick.AddListener(SetDifficulty); 
    }

    void SetDifficulty() //функция для установки сложности, которую выбрал игрок
    {
        Debug.Log(button.gameObject.name + " нажато");
        gameManager.StartGame(difficulty); //то есть после установки сложности игра начинается с учётом выбранной сложности (difficulty)
    }
}
