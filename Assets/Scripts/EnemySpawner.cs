using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnMode { Manual, Auto }

    [Header("Spawn Mode")]
    public SpawnMode spawnMode = SpawnMode.Manual;

    [Header("Manual Mode")]
    public GameObject enemyPrefab;

    [Header("Auto Mode")]
    public GameObject[] enemyPrefabs;
    public float spawnTime = 2f;

    void Start()
    {
        if (spawnMode == SpawnMode.Auto)
        {
            InvokeRepeating("SpawnEnemy", 1f, spawnTime);
        }
    }

    void Update()
    {
        if (spawnMode == SpawnMode.Manual && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], transform.position, Quaternion.identity);
    }
}