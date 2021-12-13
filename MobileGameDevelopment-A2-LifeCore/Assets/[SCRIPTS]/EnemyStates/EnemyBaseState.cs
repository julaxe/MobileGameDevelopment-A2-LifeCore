using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyBaseState : StateBase
{
    protected Enemy EnemyRef;
    protected Player PlayerRef;
    protected LifeCore LifeCoreRef;
    protected BulletPool EnemyBulletPool;
    protected StateMachine EnemyStateMachine;
    protected Rigidbody2D EnemyRigidBody;

    private float seekingVelocity = 5.0f;
    private GameObject bulletSpawnerGameObject;
    private Vector2 bulletSpawnPointLocal;
    
    protected float RadiusLifeCore = 3.5f;

    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        EnemyRef = gameObjectRef.GetComponent<Enemy>();
        PlayerRef = GameObject.Find("Player").GetComponent<Player>();
        LifeCoreRef = GameObject.Find("LifeCore").GetComponent<LifeCore>();
        EnemyStateMachine = gameObjectRef.GetComponent<StateMachine>();
        EnemyBulletPool = gameObjectRef.GetComponent<BulletPool>();
        bulletSpawnerGameObject = EnemyRef.transform.Find("BulletSpawnPoint").gameObject;
        bulletSpawnPointLocal = EnemyRef.transform.Find("BulletSpawnPoint").localPosition;
        EnemyRigidBody = gameObjectRef.GetComponent<Rigidbody2D>();
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (EnemyRigidBody.velocity.x < 0)
        {
            EnemyRef.facingRight = false;
            EnemyRef.GetComponent<SpriteRenderer>().flipX = false;
            bulletSpawnPointLocal.x = Math.Abs(bulletSpawnPointLocal.x)*-1;
        }
        else if (EnemyRigidBody.velocity.x > 0)
        {
            EnemyRef.facingRight = true;
            EnemyRef.GetComponent<SpriteRenderer>().flipX = true;
            bulletSpawnPointLocal.x = Math.Abs(bulletSpawnPointLocal.x);
        }

        bulletSpawnerGameObject.transform.localPosition = bulletSpawnPointLocal;
    }

    public void Seek(GameObject gameObject)
    {
        Vector2 direction = (gameObject.transform.position - EnemyRef.transform.position).normalized;
        Vector2 velocity = direction * seekingVelocity;
        EnemyRigidBody.velocity = velocity;
    }

    public bool InsideDetectionRadius(float radius, GameObject gameObject)
    {
        float distanceToObject = (gameObject.transform.position - EnemyRef.transform.position).magnitude;
        return distanceToObject <= radius;
    }

    public void Shoot(GameObject gameObject)
    {
        Vector2 direction = (gameObject.transform.position - EnemyRef.transform.position).normalized;
        Bullet bullet = EnemyBulletPool.GetBulletFromPool().transform.Find("Bullet").GetComponent<Bullet>();
        bullet.SetDirection(direction);
        bullet.transform.position = bulletSpawnerGameObject.transform.position;
        SoundManager.Instance.Play("EnemyShoot");
        
    }
}
