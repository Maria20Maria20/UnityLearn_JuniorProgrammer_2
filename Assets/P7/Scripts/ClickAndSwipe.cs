using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer),typeof(BoxCollider))] 

public class ClickAndSwipe : MonoBehaviour
{
    private GameManager_1 gameManager; 
    private Camera cam; 
    private Vector3 mousePos; //подключаю Vector3, чтоб отслеживать позицию курсора
    private TrailRenderer trail; 
    private BoxCollider col; 
    private bool swiping = false; //по дефолту курсор не свайпают
    private Target target;

    void Awake() 
    {
        cam = Camera.main; 
        trail = GetComponent<TrailRenderer>(); 
        col = GetComponent<BoxCollider>(); 
        trail.enabled = false; 
        col.enabled = false; 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_1>();


    }

    void UpdateMousePosition() //функция для отслеживания позиции курсора
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos; 
    }

    void UpdateComponents() 
    {
        trail.enabled = swiping;
        col.enabled = swiping; 
    }

    void Update() 
    {
        if (gameManager.isGameActive) //если игра активна, то:
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true; //можно свайпать по предметам
                UpdateComponents(); 
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false; //нельзя свайпать по предметам
                UpdateComponents(); 
            }
            if (swiping) 
            {
                UpdateMousePosition(); 
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget(); 
        }
    }
}
