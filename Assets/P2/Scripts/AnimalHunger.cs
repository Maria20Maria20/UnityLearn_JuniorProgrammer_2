using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private int amountToBeFed; //максимальное значение сытости (когда животные уже перестают просить есть и пропадает слайдер).

    private int currentFedAmount = 0; //по дефолту животные полностью голодны
    private GameManager gameManager; 

    void Start()
    {
        hungerSlider.maxValue = amountToBeFed; 
        hungerSlider.value = 0; 
        hungerSlider.fillRect.gameObject.SetActive(false); 

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void FeedAnimal(int amount) //функция для кормёжки животных
    {
        currentFedAmount += amount; 
        hungerSlider.fillRect.gameObject.SetActive(true); 
        hungerSlider.value = currentFedAmount; 

        if (currentFedAmount >= amountToBeFed) 
        {
            gameManager.AddScore(amountToBeFed); 
            Destroy(gameObject, 0.1f); //животное исчезает
        }

    }
}
