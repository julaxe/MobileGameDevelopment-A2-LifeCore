using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum  BulletType
{
    PlayerBullet,
    EnemyBullet
}
public class Bullet : MonoBehaviour
{
    public BulletType bulletType;
    public float speed = 20.0f;
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite; 
    private Vector2 movingDirection = Vector2.zero;
    void Start()
    {
        if (bulletType == BulletType.EnemyBullet)
        {
            this.gameObject.layer = 9;
        }
        else
        {
            this.gameObject.layer = 8;
        }

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        movingDirection = direction;
    }
    

    private void FixedUpdate()
    {
        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sprite.flipX = false;
        }

        rb.velocity = movingDirection * speed;
    }
}
