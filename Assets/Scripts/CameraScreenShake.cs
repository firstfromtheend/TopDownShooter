using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void PlayCameraShake()
    {
        StartCoroutine(ShakeScreen());
    }

    IEnumerator ShakeScreen()
    {
        float coroutineStartedAt = Time.time;
        while (Time.time - coroutineStartedAt < shakeDuration)
        {
            transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
