using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyLazerPrefabs;
    [SerializeField] private GameObject Obstacle;


    private List<GameObject> ListEnemyExits = new List<GameObject>();
    private ScoreManage scoreManager;

    private PowerUp_Spawner powerUp_Items;
    private float spawnItems = 3f;
    [SerializeField] private float hazardCount = 5f; // so luong ke thu
    [SerializeField] private float spwawnWait = 0.5f; // thoi gian moi ke dich sinh ra
    [SerializeField] private float startWait = 1f; // Thoi gian cho khi bat dau game
    [SerializeField] private float waitWave = 3f; // thoi gian doi giua cac wave

    [SerializeField] EnemyFactory EnemFactory;

    [SerializeField] private int wave = 3; // So luong wave trong game
    private int waveCount = 1;

    private int enemyHorizontal = 0;

    public float spacing = 5.0f;

    private int maxEnemy = 10;

    private int bossItem = 6;


    /****************/

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManage>();
        powerUp_Items = FindObjectOfType<PowerUp_Spawner>();
        StartCoroutine(EnemySpawner());
    }


    void Update()
    {
        ListEnemyExits.RemoveAll(enemy => enemy == null);

    }

    public void Spawner(EnemyType enemyType)
    {
        Vector3 enemySpawner;
        float randomX = Random.Range(-8.2f, 8.2f);
        if (enemyType == EnemyType.BossShip)
        {
            enemySpawner = new Vector3(0f, 8f, 0f);
        }
        else if (enemyType == EnemyType.AlienShipHorizontal)
        {
            enemySpawner = new Vector3(spacing, 4.8f, 0f);
        }
        else
        {
            enemySpawner = new Vector3(randomX, 8f, 0f);
        }

        GameObject enemy = EnemFactory.CreateEnemy(enemyType, enemySpawner);

        if (enemyType != EnemyType.BossShip)
        {
            ListEnemyExits.Add(enemy);
        }
    }
    IEnumerator EnemySpawner()
    {
        if (ListEnemyExits.Count < maxEnemy)
            yield return new WaitForSeconds(startWait);
        while (waveCount <= wave)
        {
            StartCoroutine(scoreManager.WavePanel(waveCount));
            yield return new WaitForSeconds(2);
            for (int i = 1; i <= hazardCount; i++)
            {
                if(waveCount <= 1){
                    Spawner(EnemyType.AlienShip);

                }
                powerUp_Items.ItemDropRate();
                if (waveCount >= 2)
                {
                    Spawner(EnemyType.AlienTurnBack);
                    Spawner(EnemyType.Obstacle);
                    if(waveCount >= 3){
                        Spawner(EnemyType.AlienSelfDestruct);

                    }
                    for (int j = 0; j < enemyHorizontal; j++)
                    {
                        Spawner(EnemyType.AlienShipHorizontal);
                    }
                }
                if (waveCount == wave && i == hazardCount)
                {
                    Spawner(EnemyType.BossShip);
                    for (int k = 0; k <= bossItem; k++)
                    {
                        powerUp_Items.ItemDropRate();
                        yield return new WaitForSeconds(spawnItems);
                    }
                }

                yield return new WaitForSeconds(spwawnWait);
            }

            hazardCount += 3;
            waveCount++;
            enemyHorizontal++;
            powerUp_Items.rateDrop -= 10;
            spacing--;
            yield return new WaitForSeconds(waitWave);
        }
    }
}



