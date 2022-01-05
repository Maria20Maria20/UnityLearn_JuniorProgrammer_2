using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTwo : MonoBehaviour 
{
    //этот скрипт нужен для того, чтоб камера следовала за персонажем второго игрока (за машиной), когда он начнёт двигаться
    [SerializeField] private GameObject player; 
    private Vector3 offset; 
    private Vector3 offsetBack = new Vector3(0, 5, -15); //первое положение камеры (сверху) 
    private Vector3 offsetOn = new Vector3(0, 2, 1); //второе положение камеры (на месте водителя)
    bool conditions = false; //условие для переключения камеры (true - на месте водителя, false - сверху)
    void LateUpdate() 
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            conditions = !conditions; 
        }
        offset = conditions ? offsetOn : offsetBack; 
        transform.position = player.transform.position + offset; 
    }
}
