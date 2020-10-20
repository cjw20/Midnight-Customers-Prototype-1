using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("Wiggle", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Wiggle()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        
    }
}
