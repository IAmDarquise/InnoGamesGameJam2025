using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private int currentWave;
    [SerializeField] private EnemyWave waveTemplate;
    [SerializeField] private Transform player;
    [SerializeField] private List<BaseEnemy> enemyPrefabs;
    
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private int maxEnemiesAllowedSimultaneously = 20;
    private List<BaseEnemy> pooledEnemies = new List<BaseEnemy>();
    private int currentEnemyPrefab = 0;
    public float strengthMultiplierPerWave = 1f;
    private void InitNewWave() 
    {
        currentWave++;

        
    
    }


    private void PreapareEnemies() 
    {
        if (spawnPoints.Count == 0) 
        {
            Debug.Log("No Spawnpoints set");
            return;
        }
        int needEnemies = maxEnemiesAllowedSimultaneously-pooledEnemies.Count;
        int currentEnemyCount = pooledEnemies.Count;
        foreach (BaseEnemy enemy in pooledEnemies)
        {
            ActivateEnemy(enemy);

        }
        if (needEnemies <= 0)
        {
            return;
        }
        for (int i = 0; i < needEnemies; i++)
        {
            var tmpEnemy = Instantiate(enemyPrefabs[currentEnemyPrefab]);
            currentEnemyPrefab++;
            if(currentEnemyPrefab >= enemyPrefabs.Count)
            {
                currentEnemyPrefab = 0;
            }
            pooledEnemies.Add(tmpEnemy);
            ActivateEnemy(tmpEnemy);
        }
        return;
    }

    private void ActivateEnemy(BaseEnemy enemyToActivate) 
    {
        int currentSpawnpoint = Random.Range(0, spawnPoints.Count);
        enemyToActivate.transform.position = spawnPoints[currentSpawnpoint].transform.position;
        enemyToActivate.gameObject.SetActive(true);


    }

    public void SetTargetForAllEnemies(Transform target) 
    {
        foreach(BaseEnemy enemy in pooledEnemies) 
        {
            enemy.SetTarget(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
