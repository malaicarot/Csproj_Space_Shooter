using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Pool;



public class ObjectPool : MonoBehaviour
{


    [Range(10, 100)][SerializeField] private int poolSize;
    [SerializeField] private List<PooledObject> objectToPool;
    private Dictionary<string, Stack<PooledObject>> poolDictionary;

    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        if (objectToPool == null || objectToPool.Count == 0)
        {
            return;
        }
        poolDictionary = new Dictionary<string, Stack<PooledObject>>();
        foreach (var obj in objectToPool)
        {
            Stack<PooledObject> objStack = new Stack<PooledObject>();
            for (int i = 0; i < poolSize; i++)
            {
                PooledObject instance = Instantiate(obj);
                instance._pool = this;
                instance.gameObject.SetActive(false);
                objStack.Push(instance);
            }
            poolDictionary.Add(obj.name, objStack);
        }


    }

    public PooledObject GetPooledObject(string objType)
    {
        if (string.IsNullOrEmpty(objType) || !poolDictionary.ContainsKey(objType))
        {
            return null;
        }
        if (poolDictionary[objType].Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool.Find(obj => obj.name == objType));
            newInstance._pool = this;
            return newInstance;
        }

        PooledObject nextInstance = poolDictionary[objType].Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        if(!poolDictionary.ContainsKey(pooledObject.name)){
            Debug.Log(pooledObject);
            Destroy(pooledObject.gameObject);
        }
        poolDictionary[pooledObject.name].Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
