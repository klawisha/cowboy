using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]GameObject enemyPrefab;
    [SerializeField]float spawnTimer = 5f;
    [SerializeField]int maxEnemyCount = 2;
    int i = 0;
    void SpawnEnemy()
    {
        while(i < maxEnemyCount)
        {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        i++;
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }



    void StopSpawning()
    {
        CancelInvoke();
    }

    void Start()
    {
        //StartSpawning();
    }


    void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
        EventManager.onPlayerDeath += StopSpawning;
    }

    void onDisable()
    {
        StopSpawning();
        EventManager.onStartGame -= StartSpawning;
        EventManager.onPlayerDeath -= StopSpawning;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
