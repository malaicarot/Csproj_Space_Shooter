using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    public static EnemyPool SingleTonEnemyPool;
    void Awake(){
        SingleTonEnemyPool = this;
    }

    public EnemyFactory CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        PooledObject objOfPool = GetPooledObject(enemyType.ToString());
        EnemyFactory Enemy = objOfPool.GetComponent<EnemyFactory>();
        Enemy.transform.position = position;
        Enemy.transform.rotation = quaternion;
        return Enemy;
    }


}
