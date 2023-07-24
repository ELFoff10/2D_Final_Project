using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Serializable]
    public class Wave
    {
        public string WaveName;
        public List<EnemyGroup> EnemyGroups;
        public int WaveQuota; // The total number of enemies to spawn in this wave
        public float SpawnInterval;
        public int SpawnCount; // The number of enemies already spawned in this wave
    }

    [Serializable]
    public class EnemyGroup
    {
        public string EnemyName;
        public int EnemyCount;
        public int SpawnCount;
        public GameObject EnemyPrefab;
    }

    public List<Wave> Waves; // Of all the waves in the game
    public int CurrentWaveCount; // The index of the current wave

    [Header("Spawner Attributes")]
    private float _spawnTimer; // Timer use to determine when to spawn the next enemy
    public int EnemiesAlive;
    public int MaxEnemiesAllowed;
    public bool MaxEnemiesReached;
    public float WaveInterval;

    [Header("Spawn Positions")]
    public List<Transform> RelativeSpawnPoints; // A list to store all the relative spawn points of enemies
    
    private Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    private void Update()
    {
        if (CurrentWaveCount < Waves.Count && Waves[CurrentWaveCount].SpawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }
        
        _spawnTimer += Time.deltaTime;

        if (!(_spawnTimer >= Waves[CurrentWaveCount].SpawnInterval)) return;
        
        _spawnTimer = 0f;
        SpawnEnemies();
    }

    private void CalculateWaveQuota()
    {
        var currentWaveQuota = Waves[CurrentWaveCount].EnemyGroups.Sum(enemyGroup => enemyGroup.EnemyCount);
        Waves[CurrentWaveCount].WaveQuota = currentWaveQuota;
    }

    /// <summary>
    /// This method will stop spawning enemies if the amount of enemies on the map is maximum.
    /// The method will only spawn enemies in a particular wave until it is time for the next wave's enemies to be spawned.
    /// </summary>
    private void SpawnEnemies()
    {
        // Check if the minimum of enemies in the wave have been spawned
        if (Waves[CurrentWaveCount].SpawnCount < Waves[CurrentWaveCount].WaveQuota && !MaxEnemiesReached)
        {
            // Spawn each type of enemy until the quota is filled
            foreach (var enemyGroup in Waves[CurrentWaveCount].EnemyGroups)
            {            
                // Check if the minimum number of enemies of this type have been spawned
                if (enemyGroup.SpawnCount < enemyGroup.EnemyCount)
                {
                    if (EnemiesAlive >= MaxEnemiesAllowed)
                    {
                        MaxEnemiesReached = true;
                        return;
                    }
                
                    // Spawn the enemy at a random position close to the player
                    Instantiate(enemyGroup.EnemyPrefab, _player.position + RelativeSpawnPoints[Random.Range(0, RelativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.SpawnCount++;
                    Waves[CurrentWaveCount].SpawnCount++;
                    EnemiesAlive++;
                }
            }
        }
        
        // Reset the maxEnemiesReached flag if the number of enemies alive dropped below the maximum amount
        if (EnemiesAlive < MaxEnemiesAllowed)
        {
            MaxEnemiesReached = false;
        }
    }
    
    public void OnEnemyKilled()
    {
        EnemiesAlive--;
    }

    private IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(WaveInterval);
        if (CurrentWaveCount >= Waves.Count - 1) yield break;
        CurrentWaveCount++;
        CalculateWaveQuota();
    }
}