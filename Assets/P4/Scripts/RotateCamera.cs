using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed=40.0f; //скорость вращения вокруг FocalPoint

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal1"); 
        transform.Rotate(Vector3.down, horizontalInput * Time.deltaTime * rotationSpeed); 
    }
}
