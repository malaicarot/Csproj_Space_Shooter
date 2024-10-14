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

    public Air_Shooting GetBullet(Vector3 position){
        PooledObject p = SingleTonPulletPool.GetPooledObject();
        Air_Shooting Bullet = p.GetComponent<Air_Shooting>();
        Bullet.transform.position = position;
        return Bullet;
    }
 
}
