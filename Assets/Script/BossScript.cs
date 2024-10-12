using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour, IEnemy
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    public int health {get => _health; set => _health = value;}
    public int damage { get => _damage; set => _damage = value; }
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    float moveDistance = 5.3f;
    float descendDistance = 6.13f;
    float moveDownSpeed = 5f;
    Vector3 startPosition;
    bool movingRight = true;
    bool descending = true;

    public HealthBar healthBar;

    void Start()
    {
        startPosition = transform.position;
        healthBar.gameObject.SetActive(false);

    }
    public void Move()
    {
        if (descending)
        {
            transform.position += Vector3.down * moveDownSpeed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - descendDistance)
            {
                healthBar.gameObject.SetActive(true);

                descending = false;
            }
        }
        else
        {
            if (movingRight)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                if (transform.position.x >= startPosition.x + moveDistance)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                if (transform.position.x <= startPosition.x - moveDistance)
                {
                    movingRight = true;
                }
            }
        }

    }

    public int Attack()
    {
        return 40;

    }

    public void TakeDamage(int amount)
    {

    }


    void Update(){
        Move();
    }
}
