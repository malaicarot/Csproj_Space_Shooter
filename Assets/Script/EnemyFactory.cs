using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Obstacle,
    AlieShip,
    AlieShipHorizontal,
    BossShip
}
public interface IEnemy
{
    public int damage { get; set; }
    public float moveSpeed { get; set; }

    public void Move();

    public int Attack();

    public void TakeDamage();

}

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle;

    [SerializeField] private List<GameObject> AlienShip;

    [SerializeField] private GameObject BossShip;

    public GameObject CreateEnemy(EnemyType enemyType, Vector3 spawnPosition)
    {
        GameObject enemy = null;

        switch (enemyType)
        {
            case EnemyType.Obstacle:
                enemy = Instantiate(Obstacle, spawnPosition, Quaternion.identity);
                break;
            case EnemyType.AlieShip:
                enemy = Instantiate(AlienShip[0], spawnPosition, Quaternion.identity);
                break;
            case EnemyType.AlieShipHorizontal:
                for (float i = -8.2f; i < 8.2f; i++)
                {
                    Vector3 enemySpawner = spawnPosition;
                    enemySpawner.x *= i;
                    enemy = Instantiate(AlienShip[1], enemySpawner, Quaternion.identity);
                    
                }

                break;
            case EnemyType.BossShip:
                enemy = Instantiate(BossShip, spawnPosition, Quaternion.identity);
                break;
            default:
                Debug.Log("Type Not Found!");
                break;
        }
        return enemy;
    }

}
