using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    // [SerializeField] private GameObject enemyPrefabs;

    [SerializeField] private List<GameObject> enemyPrefabs;

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

    private int wave = 3; // So luong wave trong game
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
        // BossSpawner();
    }



    void Update()
    {
        ListEnemyExits.RemoveAll(enemy => enemy == null);

    

    }

    public void Spawner(GameObject enemy)
    {
        float randomX = Random.Range(-8.2f, 8.2f);

        Vector3 enemySpawner = new Vector3(randomX, 8f, 0f);

        Instantiate(enemy, enemySpawner, Quaternion.identity);
        ListEnemyExits.Add(enemy);
    }

    public void SpawnerHorizontal(GameObject enemy)
    {
        for (float i = -8.2f; i < 8.2f; i++)
        {
            Vector3 enemySpawner = new Vector3(i * spacing, 4.8f, 0f);

            Instantiate(enemy, enemySpawner, Quaternion.identity);
            ListEnemyExits.Add(enemy);

        }
    }

    public void SpawnerHighSpeed(GameObject enemy)
    {



    }

    void BossSpawner()
    {
        Vector3 enemySpawner = new Vector3(0f, 8f, 0f);
        GameObject boss = Instantiate(enemyPrefabs[3], enemySpawner, Quaternion.identity);


        HealthBar healthBar = boss.GetComponentInChildren<HealthBar>();


        boss.GetComponent<Health_Enemy>().healthBar = healthBar;

        // healthBar.transform.position = transform.position;
        // ListEnemyExits.Add(enemy);

    }


    IEnumerator EnemySpawner()
    {
        if (ListEnemyExits.Count < maxEnemy)
            yield return new WaitForSeconds(startWait);
        while (waveCount <= wave)
        {
            StartCoroutine(scoreManager.WavePanel(waveCount));
            int typeEnemy = Random.Range(1, 2);
            yield return new WaitForSeconds(2);
            for (int i = 1; i <= hazardCount; i++)
            {
                Spawner(enemyPrefabs[0]);
                powerUp_Items.ItemDropRate();
                if (waveCount >= 2)
                {
                    Spawner(Obstacle);
                    for (int j = 0; j < enemyHorizontal; j++)
                    {
                        SpawnerHorizontal(enemyPrefabs[typeEnemy]);
                    }
                }
                if (waveCount == wave && i == hazardCount)
                {
                    BossSpawner();
                    for(int k = 0; k <= bossItem; k++){
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
        // scoreManager.GameOver();
    }
}



