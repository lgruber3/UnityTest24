using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; 
    public float spawnRadius = 5f; 
    public int enemyCount = 5; 
    public float spawnInterval = 5f;
    public float delay = 3f;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            StartCoroutine(SpawnEnemies());
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0; 
        
        spawnPosition += transform.position;
        
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}