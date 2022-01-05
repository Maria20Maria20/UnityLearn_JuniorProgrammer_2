using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    [SerializeField] private List<GameObject> pooledObjects; //список с объектами, которые создадутся в начале игры
    [SerializeField] private GameObject objectToPool; //игровой объект, который будет спауниться
    [SerializeField] private int amountToPool; //кол-во объектов, которые будут созданы до начала игры


    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++) 
        {
            tmp = Instantiate(objectToPool); 
            tmp.SetActive(false); 
            pooledObjects.Add(tmp); 
        }
    }

    public GameObject GetPooledObject() //функция для возвращения списка с объектами
    {
        for(int i = 0; i < amountToPool; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; 
            }
        }
        return null; 
    }

}
