using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class SweetDeal : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float despawnTimer; // 7 seconds

    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > despawnTimer)
        {
            Destroy(gameObject);
        }
    }

    public void ResetDespawnTimer()
    {
        currentTime = 0f;
    }

    public void InitializeSprite(Sprite victim)
    {
        spriteRenderer.sprite = victim;
    }
}
