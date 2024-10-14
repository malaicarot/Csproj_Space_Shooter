using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AlienTurnBack : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    public int health { get => _health; set => _health = value; }
    public int damage { get => _damage; set => _damage = value; }
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    Vector3 Position;
    Vector3 TurnBack = new Vector3(180f, 0f, 0f);
    [SerializeField] float distanceTurnBack = -5.6f;

    
    bool descending = true;

    void Start()
    {


    }
    public void Move()
    {
        if (descending)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        }
        else
        {
        
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
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
        Position = transform.position;
        if (Position.y <= distanceTurnBack)
        {
            descending = false;
            moveSpeed *= 2;
        }
        Move();
    }
}
