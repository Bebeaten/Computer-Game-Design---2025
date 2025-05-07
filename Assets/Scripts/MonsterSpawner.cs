using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject monsterPrefab;
    public Vector3 spawnPosition = new Vector3(0, 0, 0);  // User-settable in Inspector

    [Header("Timing Settings")]
    public float startDelay = 3f;
    public float initialSpawnInterval = 5f;
    public float minSpawnInterval = 1f;
    public float intervalDecreaseRate = 1f;
    public float intervalDecreaseTime = 10f;

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(BeginSpawningAfterDelay());
    }

    IEnumerator BeginSpawningAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(SpawnLoop());
        StartCoroutine(DecreaseIntervalOverTime());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnMonster();
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    IEnumerator DecreaseIntervalOverTime()
    {
        while (currentSpawnInterval > minSpawnInterval)
        {
            yield return new WaitForSeconds(intervalDecreaseTime);
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - intervalDecreaseRate);
            Debug.Log("Spawn interval decreased to: " + currentSpawnInterval);
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefab == null) return;
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
