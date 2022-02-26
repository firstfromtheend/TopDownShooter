using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLiftime = 5f;
    [SerializeField] float firingRate = 1f;

    [Header("AI")]
    [SerializeField] float firingRateVriance = 0f;
    [SerializeField] float enemyMinFiringRate = 0.1f;
    [SerializeField] bool useAI;


    [HideInInspector] public bool isFiring;

    Coroutine fireCoroutine;

    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Destroy(projectile, projectileLiftime);
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.velocity = transform.up * projectileSpeed;

            if (!useAI)
            {
                yield return new WaitForSeconds(firingRate);
            }
            else
            {
                float enemyFiringRate = Random.Range(firingRate - firingRateVriance, firingRate + firingRateVriance);
                enemyFiringRate = Mathf.Clamp(enemyMinFiringRate, enemyFiringRate, float.MaxValue);
                yield return new WaitForSeconds(enemyFiringRate);
            }
        }
    }
}
