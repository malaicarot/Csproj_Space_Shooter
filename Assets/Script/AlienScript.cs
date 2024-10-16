using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : EnemyFactory, IEnemy
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    public int health {get => _health; set => _health = value;}
    public int damage { get => _damage; set => _damage = value; }
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }


    public void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    public int Attack()
    {
        return 20;

    }

    public void TakeDamage(int dame)
    {
        health -= dame;

    }

    void Update()
    {
        Move();
    }
}
