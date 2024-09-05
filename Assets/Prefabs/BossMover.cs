using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMover : MonoBehaviour
{

    [SerializeField] float speed = 2.0f;
    [SerializeField] float moveDistance = 5.3f;
    [SerializeField] float moveDownSpeed = 5f;
    [SerializeField] float descendDistance = 6.13f;


    [SerializeField] public HealthBar healthBar;

    Vector3 startPosition;
    bool movingRight = true;
    bool descending = true;

    void Start()
    {
        startPosition = transform.position;
        healthBar.gameObject.SetActive(false);
        
    }


    void Update()
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
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= startPosition.x + moveDistance)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= startPosition.x - moveDistance)
                {
                    movingRight = true;
                }
            }
        }
    }
}
