using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave config", fileName = "New wave config")]
public class SO_WaveConfig : ScriptableObject
{
    [SerializeField] float timeBetweenSpawns = 2f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.5f;

    [SerializeField] public List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;

    [SerializeField] float enemyMoveSpeed = 5;

    [SerializeField] int pointsByEnemy = 10;

    public float EnemyMoveSpeed 
    {
        get { return enemyMoveSpeed; }
        set { enemyMoveSpeed = value; }
    }
    
    public Transform GetStartWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float randomSpawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(randomSpawnTime, minSpawnTime, float.MaxValue);
    }

    public int GetPointsByEnemy()
    {
        return pointsByEnemy;
    }

    // replacement for get in EnemyMoveSpeed
    //public float GetEnemyMiveSpeed()
    //{
    //    return enemyMoveSpeed;
    //}
}
