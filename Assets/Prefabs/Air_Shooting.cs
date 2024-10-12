using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air_Shooting : MonoBehaviour
{
    [SerializeField] private float speed = 7f;


    [SerializeField] GameObject ExplodePrefabs;


    public string ParentName { get; set; }

    [SerializeField] private Vector3 direction;

    private ScoreManage scoreManager;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManage>();
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
                Destroy(gameObject);
                boss.TakeDamage(10);

            }
        }
        if ((ParentName == "Enemy" || ParentName == "Boss") && other.CompareTag("Player"))
        {

            if (player.currentHealth == 0)
            {
                DestroyEnemy(other.gameObject);
                scoreManager.GameOver();
            }
            player.takeDamage(20);
            Destroy(gameObject);

        }
    }

    void DestroyEnemy(GameObject other)
    {
        GameObject exploder = Instantiate(ExplodePrefabs, transform.position, Quaternion.identity);
        exploder.transform.localScale = other.gameObject.transform.localScale * 4;
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
