using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{


    [Range(10, 100)] [SerializeField] private int poolSize;
    [SerializeField] private PooledObject objectToPool;
    private Stack<PooledObject> PoolStack;

    void Start(){
        SetUpPool();
    }

    void SetUpPool(){
        if(objectToPool == null){
            return;
        }
        PoolStack = new Stack<PooledObject>();
        PooledObject instance;

        for(int i = 0; i < poolSize; i++){
            instance = Instantiate(objectToPool);
            instance._pool = this;
            instance.gameObject.SetActive(false);
            PoolStack.Push(instance);
        }
    }

    public PooledObject GetPooledObject(){
        if(objectToPool == null){
            return null;
        }
        if(PoolStack.Count == 0){
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance._pool = this;
            return newInstance;
        }

        PooledObject nextInstance = PoolStack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject){
        PoolStack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);

    }


    

    
}
