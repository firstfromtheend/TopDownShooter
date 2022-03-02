using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] AudioClip playerShoot;
    [SerializeField] [Range(0f, 1f)] float playerShootVolume = 1f;

    [SerializeField] AudioClip playerDeath;
    [SerializeField] [Range(0f, 1f)] float playerDethVolume = 1f;
    
    [Header("Enemy")]
    [SerializeField] AudioClip enemyShoot;
    [SerializeField] [Range(0f, 1f)] float enemyShootVolume = 0.5f;

    public void PlayPlayerShoot()
    {
        if (playerShoot != null)
        {
            AudioSource.PlayClipAtPoint(playerShoot, Camera.main.transform.position, playerShootVolume);
        }
    }
    public void PlayPlayerDeath()
    {
        if (playerDeath != null)
        {
            AudioSource.PlayClipAtPoint(playerDeath, Camera.main.transform.position, playerDethVolume);
        }
    }
    
    public void EnemyPlayerShoot()
    {
        if (enemyShoot != null)
        {
            AudioSource.PlayClipAtPoint(enemyShoot, Camera.main.transform.position, enemyShootVolume);
        }
    }
}
