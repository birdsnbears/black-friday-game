using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Collider), typeof(SpriteRenderer))]
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
