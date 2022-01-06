using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //���� ������ ����� ��� ��������� �������: ������, �������� � ��������
    private Button button; //������ ���������
    private GameManager_1 gameManager;
    [SerializeField] private int difficulty; //���������� ��� ��������� ��������� ����. ��� EasyButton = 1, MediumButton = 2, HardButton = 3
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_1>();
        button.onClick.AddListener(SetDifficulty); 
    }

    void SetDifficulty() //������� ��� ��������� ���������, ������� ������ �����
    {
        Debug.Log(button.gameObject.name + " ������");
        gameManager.StartGame(difficulty); //�� ���� ����� ��������� ��������� ���� ���������� � ������ ��������� ��������� (difficulty)
    }
}
