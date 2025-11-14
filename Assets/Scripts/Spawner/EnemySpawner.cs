using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public int enemyCount = 5;

    private int enemiesAlive = 0;

    [Header("Spawn Area Settings")] 
    public Vector3 spawnAreaMin = new Vector3(-5, -5, 0);
    public Vector3 spawnAreaMax = new Vector3(5, 5, 0);
    public float spawnRadius = 10f;

    [Header("Wave Settings")]
    public float minSpawnInterval = 15f;
    public float maxSpawnInterval = 30f;

    [Header("Enemy Lifetime")]
    public float minEnemyLifetime = 20f;
    public float maxEnemyLifetime = 40f;


    [Header("Player Prefab")]
    public Transform playerPrefab;
    private bool isSpawning = false;
    private Coroutine spawnRoutine;

    [Header("Screen Color Prefab")]
    public GameObject screenColorPrefab;

    void Start()
    {
        
        if (screenColorPrefab != null)
        {
            screenColorPrefab.SetActive(false);
        }
    }

    void Update()
    {
        if (playerPrefab == null) return;
        if (!isSpawning && PlayerInRange())
        {
            StartSpawning();
        }
        else if (isSpawning && !PlayerInRange())
        {
            StopSpawning();
        }
    }




    //Call by other scripts to start/stop spawning waves
    public void StartSpawning()
    {
        if (isSpawning) return;

        isSpawning = true;
        spawnRoutine = StartCoroutine(SpawnWave());
       
    }
    public void StopSpawning()
    {
        if (!isSpawning) return;
        isSpawning = false;

        if (spawnRoutine != null)
        {
             StopCoroutine(spawnRoutine);
        
        }
       
    }



    private bool PlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player not found for range check.");
            return false;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= spawnRadius;
    }


    private IEnumerator SpawnWave()
    {
        while (isSpawning)
        {
            
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();


        }
    }



    void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //set a random lifetime for the enemy
            enemiesAlive++;
            float lifetime = Random.Range(minEnemyLifetime, maxEnemyLifetime);
            StartCoroutine(DestroyEnemyAfterTime(enemy, lifetime));
            if(screenColorPrefab != null)
            {
                screenColorPrefab.SetActive(true);
            }
            
            

        }

        

    }


    IEnumerator DestroyEnemyAfterTime(GameObject enemy, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(enemy);
        enemiesAlive--;

        if(enemiesAlive <= 0 && screenColorPrefab != null)
        {
            screenColorPrefab.SetActive(false);
        }
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
