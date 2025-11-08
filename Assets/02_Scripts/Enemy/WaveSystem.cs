using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private int currentWave;
    [SerializeField] private EnemyWave waveTemplate;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private List<BaseEnemy> enemyPrefabs;
    public delegate void WaveComplete(int wavesCompleted);
    public WaveComplete onWaveComplete;
    private static WaveSystem instance;
    public static WaveSystem Instance{ get { return instance; } }
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private int maxEnemiesAllowedSimultaneously = 20;
    private List<BaseEnemy> deactivatedEnemies = new List<BaseEnemy>();

    private List<BaseEnemy> pooledEnemies = new List<BaseEnemy>();
    private int currentEnemyPrefab = 0;
    public float strengthMultiplierPerWave = 1f;
    private int deadEnemies;
    private int enemyCount;
    private int enemiesLeftToSpawn;
    private void Awake()
    {
        if(instance == null || instance == this)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void Start()
    {
        InitNewWave();
    }

    private void InitNewWave() 
    {
        currentWave++;
        enemyCount = waveTemplate.overallEnemyCountInWave * currentWave;
        enemiesLeftToSpawn = Mathf.Clamp(enemyCount,0,maxEnemiesAllowedSimultaneously);
        deadEnemies = 0;
        //PreapareEnemiesPooled();
        //SetTargetForAllEnemies(player.transform);


    }



    private void PrepareEnemiesInstaniated()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.Log("No Spawnpoints set");
            return;
        }

        for (int i = 0; i < enemiesLeftToSpawn; i++)
        {
            SpawnNewEnemieInstaniated();
        }
    }

    private void SpawnNewEnemieInstaniated()
    {
        BaseEnemy tmpEnemy = Instantiate(enemyPrefabs[currentEnemyPrefab]);
        tmpEnemy.player = player;
        tmpEnemy.target = player.transform;
        currentEnemyPrefab++;
        if (currentEnemyPrefab >= enemyPrefabs.Count)
        {
            currentEnemyPrefab = 0;
        }
        enemiesLeftToSpawn--;
    }

    private void PreapareEnemiesPooled() 
    {
        if (spawnPoints.Count == 0) 
        {
            Debug.Log("No Spawnpoints set");
            return;
        }
        int needEnemies = Mathf.RoundToInt(maxEnemiesAllowedSimultaneously*1.5f)-pooledEnemies.Count;
        for (int i = 0; i < needEnemies; i++)
        {
            BaseEnemy tmpEnemy = Instantiate(enemyPrefabs[currentEnemyPrefab]);
            tmpEnemy.player = player;
            currentEnemyPrefab++;
            if(currentEnemyPrefab >= enemyPrefabs.Count)
            {
                currentEnemyPrefab = 0;
            }
            pooledEnemies.Add(tmpEnemy);
            deactivatedEnemies.Add(tmpEnemy);
        }
        for(int i = enemiesLeftToSpawn-1; i >= 0; i--)
        {
            if(i >= deactivatedEnemies.Count) 
            {
                continue;
            }
            ActivateEnemy(deactivatedEnemies[i]);

        }
        return;
    }

    private void ActivateEnemy(BaseEnemy enemyToActivate) 
    {
        enemiesLeftToSpawn--;
        int currentSpawnpoint = Random.Range(0, spawnPoints.Count);
        enemyToActivate.transform.position = spawnPoints[currentSpawnpoint].transform.position;
        //enemyToActivate.gameObject.SetActive(true);
        enemyToActivate.ResetValues();
        deactivatedEnemies.Remove(enemyToActivate);


    }

    public void SetTargetForAllEnemies(Transform target) 
    {
        foreach(BaseEnemy enemy in pooledEnemies) 
        {
            enemy.SetTarget(target);
        }
    }

    public void EnemyDied(BaseEnemy enemy) 
    {
        deadEnemies++;
        deactivatedEnemies.Add(enemy);
        if(deadEnemies >= enemyCount) 
        {
            onWaveComplete?.Invoke(currentWave);
            InitNewWave();
            return;
        }
        enemiesLeftToSpawn++;
    }


    private async void SpawnIntervalInstaniated() 
    {
        if (enemiesLeftToSpawn <= 0)
        {
            return;
        }
        SpawnNewEnemieInstaniated();
        await Task.Delay(Mathf.RoundToInt(waveTemplate.spawnInterval * 1000));
        SpawnIntervalInstaniated();

    }

    private async void SpawnIntervalPooled() 
    {
        if(enemiesLeftToSpawn <= 0) 
        {
            return;
        }
        int randID = Random.Range(0,deactivatedEnemies.Count);
        ActivateEnemy(deactivatedEnemies[randID]);
        await Task.Delay(Mathf.RoundToInt( waveTemplate.spawnInterval*1000) );
        SpawnIntervalPooled();
    }



}
