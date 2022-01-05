using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereBlue : MonoBehaviour
{
    private Counter counter; 

    void Start()
    {
        counter = GameObject.Find("GameManager").GetComponent<Counter>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoxBlue")) 
        {
            counter.Count += 1; 
            Destroy(gameObject); 
        }
        else if(other.gameObject.CompareTag("BoxBlack")) 
        {
            counter.Count -= 1; 
            Destroy(gameObject); 
        }
        counter.CounterText.text = "Count : " + counter.Count; 
    }
}
