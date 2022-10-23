using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class SweetDeal : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeSprite(Sprite victim)
    {
        spriteRenderer.sprite = victim;
    }
}
