using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPool : MonoBehaviour
{

    public static BulletPool SingleTonPulletPool;
    [Range(10, 100)] [SerializeField] private int poolSize;

    [SerializeField] private GameObject basicBulletPrefabs;

    private Stack<GameObject> bulletStack;

    void Awake(){
        SingleTonPulletPool = this;
    }
    void Start()
    {
        SetUpBasicPoolBasic();
        SetUpParallelPool();
    }

    void Update()
    {
        
    }
    void SetUpBasicPoolBasic(){
        if(basicBulletPrefabs == null){
            return;
        }

        bulletStack = new Stack<GameObject>();

        GameObject instance;

        for (int i = 0; i < poolSize; i++)
        {
            instance = Instantiate(basicBulletPrefabs);
            instance.SetActive(false);
            bulletStack.Push(instance);
        }

    }

    void SetUpParallelPool(){
         if(basicBulletPrefabs == null){
            return;
        }

        bulletStack = new Stack<GameObject>();

        GameObject instanceLeft;
        GameObject instanceRight;
        Vector3 leftPosition = transform.position + new Vector3(-0.6f, 0, 0);
        Vector3 rightPosition = transform.position + new Vector3(0.6f, 0, 0);

        for (int i = 0; i < poolSize; i++)
        {
            instanceLeft = Instantiate(basicBulletPrefabs, leftPosition, Quaternion.identity);
            instanceRight = Instantiate(basicBulletPrefabs, rightPosition, Quaternion.identity);
            instanceLeft.SetActive(false);
            instanceRight.SetActive(false);
            bulletStack.Push(instanceLeft);
            bulletStack.Push(instanceRight);
        }
    }

    

    public GameObject GetPolledBullet(Vector3 ObjectPosition, Quaternion ObjectQuaternion){

         if(basicBulletPrefabs == null){
            return null;
        }

        if(bulletStack.Count == 0){
            GameObject extraBullet =  Instantiate(basicBulletPrefabs);
            bulletStack.Push(extraBullet);
        }

        GameObject bullet = bulletStack.Pop();
        bullet.transform.position = ObjectPosition;
        bullet.transform.rotation = ObjectQuaternion;
        return bullet;
    }

    public void ReturnBullet(GameObject bullet){
        bulletStack.Push(bullet);
        bullet.SetActive(false);
        

    }
}
