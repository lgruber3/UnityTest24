using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public float spawnRange = 10.0f; // The range within which to spawn the objects

    void Start()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    // Method to generate a random position within the spawn range
    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0, z);
    }

    // Method to spawn the object at a given position
    void SpawnObject()
    {
        Vector3 spawnPosition = GenerateRandomPosition();
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
    IEnumerator SpawnObjectCoroutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(5.0f);
        }
    }
}