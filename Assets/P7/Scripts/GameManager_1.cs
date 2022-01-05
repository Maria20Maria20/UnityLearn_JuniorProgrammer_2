using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class GameManager_1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    public bool isGameActive; //проверка, активна ли сейчас игра
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject pauseScreen;
    public bool paused; //проверка, пауза сейчас или нет
    private int score;
    public int lives; 
    private float spawnRate = 1.0f; //таймер для появления объектов (кубов, врагов)


    IEnumerator SpawnTarget() 
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); 
            int index = Random.Range(0, targets.Count); 
            Instantiate(targets[index]); 
        }
    }

    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd; 
        scoreText.text = "Очки: " + score;
    }

    public void UpdateLives(int livesToAdd) 
    {
        if (lives <= 0) 
        {
            lives = 0; 
            livesToAdd=0; 
            GameOver(); 
        }
        livesText.text = "Жизни: " + lives; 
    }

    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true); 
        restartButton.gameObject.SetActive(true); 
        isGameActive = false; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) 
    {
        titleScreen.gameObject.SetActive(false); 
        isGameActive = true; 
        lives = 3; 
        score = 0; 
        spawnRate /= difficulty; //устанавливаем сложность
        StartCoroutine(SpawnTarget()); 
        UpdateScore(0); 
        UpdateLives(3); 
    }

    void ChangePaused() //функция, вызывающаяся, если нужно поставить игру на паузу
    {
        if (!paused)
        {
            paused = true; 
            pauseScreen.SetActive(true); 
            Time.timeScale = 0; //приостановка физических вычислений (всё замирает)
        }
        else 
        {
            paused = false; 
            pauseScreen.SetActive(false); 
            Time.timeScale = 1; //активация физических вычислений (игра снова запускается)

        }
    }

    void Update() 
    {
        if (isGameActive) 
        {
            if (Input.GetKeyDown(KeyCode.P)) //если нажать на кнопку P, то:
            {
                ChangePaused(); //включится экран паузы (а если он включен, то выключится)
            }

        }
    }
}
