using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(PooledObject))]
public class Air_Shooting : PooledObject
{

    [SerializeField] public float speed = 7f;

    [SerializeField] GameObject ExplodePrefabs;

    public string ParentName { get; set; }

    private Vector3 direction;

    private ScoreManage scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManage>();
        if (ParentName == "Player")
        {
            direction = new Vector3(0f, 1f, 0f);
        }
        else
        {
            direction = Vector3.down;
        }

    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        AirMover player = other.gameObject.GetComponent<AirMover>();
        Health_Enemy boss = other.gameObject.GetComponent<Health_Enemy>();

        if (ParentName == "Player")
        {
            if (other.CompareTag("Enemy"))
            {
                ScoreManage.AddScore(1);
                DestroyEnemy(other.gameObject);

            }
            else if (other.CompareTag("Obstacle"))
            {
                DestroyEnemy(other.gameObject);
            }
            else if (other.CompareTag("Boss"))
            {
                if (boss.currentHealth == 0)
                {
                    DestroyEnemy(other.gameObject);
                    scoreManager.GameOver();
                }
                Release();
                boss.TakeDamage(10);
            }
            // else if (other.CompareTag("Boundary"))
            // {
            //     Release();
            // }

        }
        if (ParentName == "Enemy" || ParentName == "Boss")
        {

            if (other.CompareTag("Player"))
            {
                if (player.currentHealth == 0)
                {
                    DestroyEnemy(other.gameObject);
                    scoreManager.GameOver();
                }
                player.takeDamage(20);
                Release();
            }
            // else if (other.CompareTag("Boundary"))
            // {
            //     Release();
            // }
        }
    }

    void DestroyEnemy(GameObject other)
    {
        GameObject exploder = Instantiate(ExplodePrefabs, transform.position, Quaternion.identity);
        exploder.transform.localScale = other.gameObject.transform.localScale * 4;
        EnemyFactory returnToPool = other.gameObject.GetComponent<EnemyFactory>();
        returnToPool.ReturnToPool();

    }
}
