using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    SO_WaveConfig waveConfig;
    List<Transform> waypoints;

    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        // here we can change Vector2 on Vector3, coz we don't care abot Z coordinate and it make condition in second IF a little bit less
        // e.x. in commentary below
        if (waypointIndex < waypoints.Count)
        {
            Vector2 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.EnemyMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            //if (transform.position == targetPosition)
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
