using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem deathVFX;

    [SerializeField] bool applyCameraShake;

    CameraScreenShake cameraScreenShake;

    private void Awake()
    {
        cameraScreenShake = Camera.main.GetComponent<CameraScreenShake>();
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
        health -= damageValue;
        ShakeCamera();
        if (health <= 0)
        {
            PlayDeathVFX();
            Destroy(gameObject);
        }
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
        }
    }
}
