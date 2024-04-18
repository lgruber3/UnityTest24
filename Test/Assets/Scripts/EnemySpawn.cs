using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnRadius = 5f; 
    public int enemyCount = 5; 
    public float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), spawnInterval, spawnInterval);
    }

    // Method to spawn a set number of enemies
    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    // Method to spawn an enemy
    void SpawnEnemy()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0; 
        
        spawnPosition += transform.position;
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}