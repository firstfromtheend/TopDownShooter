using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool isLooping;
    [SerializeField] List<SO_WaveConfig> waveConfigsList;
    [SerializeField] float timeBetweenWaves = 2f;
    SO_WaveConfig currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public SO_WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (SO_WaveConfig wave in waveConfigsList)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                        currentWave.GetStartWaypoint().position, 
                        Quaternion.Euler(0, 0, 180),
                        transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
