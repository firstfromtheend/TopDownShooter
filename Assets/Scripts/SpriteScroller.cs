using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        material.mainTextureOffset += moveSpeed * Time.deltaTime;
    }
}
