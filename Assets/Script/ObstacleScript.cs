using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour, IEnemy
{

    [SerializeField] private float _moveSpeed;

    [SerializeField] private int _damage;


    public int damage { get => _damage; set => _damage = value; }
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    public void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

    }

    public int Attack()
    {
        return 0;

    }

    public void TakeDamage()
    {


    }
}
