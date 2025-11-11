using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 5;

    public Vector3 spawnAreaMin = new Vector3(-5, -5, 0);
    public Vector3 spawnAreaMax = new Vector3(5, 5, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        for(int i = 0; i< enemyCount;i++)
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        
    }
}
