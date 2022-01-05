using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //���� ������ ����� ��� ����, ���� ������ ��������� �� ���������� ������ (�� �������), ����� �� ����� ���������
    [SerializeField] private GameObject player; 
    private Vector3 offset; 
    private Vector3 offsetBack = new Vector3(0,5,-15); //������ ��������� ������ (������) 
    public Vector3 offsetOn = new Vector3(0, 2, 1); //������ ��������� ������ (�� ����� ��������)
    bool conditions = false; //������� ��� ������������ ������ (true - �� ����� ��������, false - ������)
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
