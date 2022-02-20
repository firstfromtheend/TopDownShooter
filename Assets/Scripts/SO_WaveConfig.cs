using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave config", fileName = "New wave config")]
public class SO_WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5;
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

    // replacement for get in enemyMoveSpeed
    //public float GetEnemyMiveSpeed()
    //{
    //    return enemyMoveSpeed;
    //}
}
