using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum EnemyType
// {
//     Obstacle,
//     AlienShip,
//     AlienShipHorizontal,
//     AlienSelfDestruct,
//     AlienTurnBack,
//     BossShip
// }
public enum EnemyType
{
    Obstacle,
    EnemyBlue,
    EnemyGreen,
    EnemyRed,
    EnemyGray,
    BossShip
}
public interface IEnemy
{
    public int damage { get; set; }
    public float moveSpeed { get; set; }
    public int health { get; set; }

    public void Move();

    public int Attack();

    public void TakeDamage(int amount);

}
[RequireComponent(typeof(PooledObject))]
public class EnemyFactory : PooledObject
{


}
