using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;

    public float spawnInterval = 1.2f;
    public float xRange = 8f;
    public float spawnY = 6f;

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, monsterPrefabs.Length);
        float randomX = Random.Range(-xRange, xRange);

        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);
        Instantiate(monsterPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}