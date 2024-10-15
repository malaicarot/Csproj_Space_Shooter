using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMover : MonoBehaviour
{
    public float speed = 6.0f;
    private Animator animator;

    public ScoreManage _ScoreManager;
    private Lazer_Shooter _BulletEffect;

    [SerializeField] GameObject ExplodePrefabs;
    [SerializeField] int maxHealth = 100;
    public int currentHealth { get; set; }
    [SerializeField] HealthBar healthBar;

    private Vector2 xMaxPosition;
    private Vector2 yMaxPosition;


    void Start()
    {
        animator = GetComponent<Animator>();
        _BulletEffect = FindObjectOfType<Lazer_Shooter>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        xMaxPosition = new Vector2(-8.3f, 8.3f);
        yMaxPosition = new Vector2(-4.58f, 4.58f);
    }

    void Update()
    {


        if (_ScoreManager._gameState == gameState.gameOver)
        {
            return;

        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isFlying = moveHorizontal != 0 || moveVertical != 0;
        animator.SetBool("isFlying", isFlying);

        float xNewPosition = transform.position.x + (moveHorizontal * speed * Time.deltaTime);
        float yNewPosition = transform.position.y + (moveVertical * speed * Time.deltaTime);

        if (isFlying)
        {
            if (xNewPosition < xMaxPosition.x || xNewPosition > xMaxPosition.y)
            {
                xNewPosition = transform.position.x;
            }

            if (yNewPosition < yMaxPosition.x || yNewPosition > yMaxPosition.y)
            {
                yNewPosition = transform.position.y;
            }
            transform.position = new Vector3(xNewPosition, yNewPosition, 0f);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Healing(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Obstacle") || other.CompareTag("Boss") || other.CompareTag("Exploder"))
        {
            if (gameObject.CompareTag("Player"))
            {
                takeDamage(100);
                _ScoreManager.GameOver();
                Instantiate(ExplodePrefabs, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Item_Healing"))
        {
            Healing(30);
            Destroy(other.gameObject);
            SoundController._instance.PowerUpAudioPlay();

        }
        else if (other.CompareTag("Item_BulletCone"))
        {
            _BulletEffect.ActiveBulletCone(10f);
            Destroy(other.gameObject);
            SoundController._instance.PowerUpAudioPlay();
        }
        else if (other.CompareTag("Item_BulletParallel"))
        {
            _BulletEffect.ActiveBulletParallel(10f);
            Destroy(other.gameObject);
            SoundController._instance.PowerUpAudioPlay();

        }
        else if (other.CompareTag("Item_RateOfFire"))
        {
            StartCoroutine(_BulletEffect.SpeedUpSpawnBullet());
            Destroy(other.gameObject);
            SoundController._instance.PowerUpAudioPlay();
        }
    }
}



