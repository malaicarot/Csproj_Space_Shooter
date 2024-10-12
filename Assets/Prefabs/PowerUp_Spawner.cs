using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PowerUp_Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUpPrefabs;
    public int rateDrop = 90;
    public void ItemSpawner()
    {
        float randomX = Random.Range(-8.2f, 8.2f);

        Vector3 enemySpawner = new Vector3(randomX, 4.8f, 0f);

        int randomIndex = Random.Range(0, powerUpPrefabs.Count);

        Instantiate(powerUpPrefabs[randomIndex], enemySpawner, Quaternion.identity);
    }

    public void ItemDropRate(){
        int rate = Random.Range(rateDrop, 100);
        if(rate % 2 == 0){
            ItemSpawner();
        }
    }
}
