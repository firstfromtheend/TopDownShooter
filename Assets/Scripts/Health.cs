using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem deathVFX;

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
        if (health <= 0)
        {
            Destroy(gameObject);
            PlayDeathVFX();
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
