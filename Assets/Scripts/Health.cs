using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthShip = 50;
    //public int HealthShip { get; }

    [SerializeField] int points = 10;

    [SerializeField] ParticleSystem deathVFX;

    [SerializeField] bool applyCameraShake;

    CameraScreenShake cameraScreenShake;

    AudioPlayer audioPlayer;

    [SerializeField] bool isPlayer;

    ScoreKeeper scoreKeeper;

    LevelManager levelManager;

    private void Awake()
    {
        cameraScreenShake = Camera.main.GetComponent<CameraScreenShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.Damage);
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damageValue)
    {
        healthShip -= damageValue;
        ShakeCamera();
        if (healthShip <= 0)
        {
            if (!isPlayer)
            {
                AddScore();
            }
            else
            {
                levelManager.loadGameOver();
            }
            PlayDeathVFX();
            Destroy(gameObject);
        }
    }

    private void AddScore()
    {
        scoreKeeper.PlayerScore = points;
    }

    private void ShakeCamera()
    {
        if (cameraScreenShake != null && applyCameraShake)
        {
            cameraScreenShake.PlayCameraShake();
        }
    }

    void PlayDeathVFX()
    {
        if (deathVFX != null)
        {
            ParticleSystem instance = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
            audioPlayer.PlayPlayerDeath();
        }
    }

    public int GetHealth()
    {
        return healthShip;
    }
}
