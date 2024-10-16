using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public enum BulletType{
    Basic,
    Enemy,
    Boss

}
[RequireComponent(typeof(PooledObject))]

public class Lazer_Shooter : PooledObject
{
    // public GameObject lazerPrefabs;
    [SerializeField] private float timer;
    [SerializeField] private float shootInterval = 1.5f;

    [SerializeField] public string parentName;

    [SerializeField] private AudioClip lazerSound;

    private bool isBulletParallel = false;
    private bool isBulletCone = false;
    void Start()
    {


    }
    void Update()
    {
        timer += Time.deltaTime;
        if (parentName == "Boss")
        {
            isBulletCone = true;

        }

        if (timer >= shootInterval)
        {
            Shooting();
            timer = 0;
        }

    }

    public IEnumerator SpeedUpSpawnBullet()
    {
        shootInterval -= 0.5f;
        yield return new WaitForSeconds(3f);
        shootInterval += 0.5f;

    }
    void Shooting()
    {
        SoundController._instance.ShootAudioPlay();

        if (isBulletParallel)
        {
            Vector3 leftPosition = transform.position + new Vector3(-0.6f, 0, 0);
            Vector3 rightPosition = transform.position + new Vector3(0.6f, 0, 0);

            Air_Shooting BulletLeft = BulletPool.SingleTonPulletPool.GetBullet(BulletType.Basic.ToString(), leftPosition, Quaternion.identity);
            Air_Shooting air_Shooting_Left = BulletLeft.GetComponent<Air_Shooting>();

            air_Shooting_Left.ParentName = parentName;


            Air_Shooting BulletRight = BulletPool.SingleTonPulletPool.GetBullet(BulletType.Basic.ToString(), rightPosition, Quaternion.identity);
            Air_Shooting air_Shooting_Right = BulletRight.GetComponent<Air_Shooting>();
            air_Shooting_Right.ParentName = parentName;
        }
        else if (isBulletCone)
        {

            float[] angles = { -25f, -15f, 0, 15f, 25f };
            foreach (float angle in angles)
            {
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Air_Shooting Bullet = BulletPool.SingleTonPulletPool.GetBullet(BulletType.Basic.ToString(), transform.position, rotation);

                Air_Shooting air_Shooting = Bullet.GetComponent<Air_Shooting>();

                air_Shooting.ParentName = parentName;
            }
        }
        else
        {
            Air_Shooting Bullet = BulletPool.SingleTonPulletPool.GetBullet(BulletType.Basic.ToString(), transform.position, Quaternion.identity);
            Air_Shooting air_Shooting = Bullet.GetComponent<Air_Shooting>();
            air_Shooting.ParentName = parentName;
        }
    }

    public void ActiveBulletParallel(float duration)
    {
        StartCoroutine(BulletParallelEffect(duration));

    }
    IEnumerator BulletParallelEffect(float duration)
    {
        isBulletParallel = true;

        yield return new WaitForSeconds(duration);

        isBulletParallel = false;

    }

    public void ActiveBulletCone(float duration)
    {
        StartCoroutine(BulletConeEffect(duration));

    }
    IEnumerator BulletConeEffect(float duration)
    {
        isBulletCone = true;

        yield return new WaitForSeconds(duration);

        isBulletCone = false;
    }
}
