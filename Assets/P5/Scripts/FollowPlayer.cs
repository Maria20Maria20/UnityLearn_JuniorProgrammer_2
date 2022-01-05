using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //этот скрипт нужен дл€ того, чтоб камера следовала за персонажем игрока (за машиной), когда он начнЄт двигатьс€
    [SerializeField] private GameObject player; 
    private Vector3 offset; 
    private Vector3 offsetBack = new Vector3(0,5,-15); //первое положение камеры (сверху) 
    public Vector3 offsetOn = new Vector3(0, 2, 1); //второе положение камеры (на месте водител€)
    bool conditions = false; //условие дл€ переключени€ камеры (true - на месте водител€, false - сверху)
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            conditions =!conditions; 
        }
        offset = conditions ? offsetOn : offsetBack; 
        transform.position = player.transform.position + offset; 
    }
}
