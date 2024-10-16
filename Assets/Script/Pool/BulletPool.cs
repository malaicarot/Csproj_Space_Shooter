using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPool : ObjectPool
{

    public static BulletPool SingleTonPulletPool;
    void Awake(){
        SingleTonPulletPool = this;
    }

    public Air_Shooting GetBullet(string BulletType, Vector3 position, Quaternion quaternion){
        PooledObject objOfPool = SingleTonPulletPool.GetPooledObject(BulletType);
        Air_Shooting Bullet = objOfPool.GetComponent<Air_Shooting>();
        Bullet.transform.position = position;
        Bullet.transform.rotation = quaternion;
        return Bullet;
    }






 
}
