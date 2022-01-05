using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private float forwardInput;
    private Rigidbody boardRb;

    void Start()
    {
        boardRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Horizontal1");
        boardRb.transform.Rotate(forwardInput, 0.0f, 0.0f, Space.Self);
    }

}
