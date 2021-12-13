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
        CheckScreenPosition();

    }

    private void CheckScreenPosition()
    {
        float screenWidth = 15.0f;
        if (transform.position.x > screenWidth)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else if (transform.position.x < -screenWidth)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.parent.gameObject.SetActive(false);
        if (other.gameObject.layer == 6) // player
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.hp -= 10;
            SoundManager.Instance.Play("PlayerHit");
        }
        else if (other.gameObject.layer == 7) // enemy
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.hp -= 30;
            GameStatusSingleton.Instance.score += 10;
        }
        else if (other.gameObject.layer == 10)//life core
        {
            LifeCore lifeCore = other.gameObject.GetComponent<LifeCore>();
            lifeCore.hp -= 20;
        }
    }
}
