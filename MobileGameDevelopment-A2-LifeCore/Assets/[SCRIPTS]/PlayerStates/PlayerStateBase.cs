
using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerStateBase : StateBase
{
    protected GameObject PlayerRef;
    protected Player PlayerPlayerRef;
    protected StateMachine PlayerStateMachine;
    protected Animator Animator;
    protected OnScreenInput ScreenInput;
    protected Rigidbody2D Rb;
    protected CapsuleCollider2D CapsuleCollider;

    protected float MoveX;
    protected bool Jump;
    protected bool Fire;

    //moving variables
    protected float jumpForce = 200.0f;
    protected float walkingForce = 10.0f;
    protected float velocityToRun = 1.5f;
    
    //bullet
    private Vector3 bulletSpawnPointLocal;
    private Transform bulletSpawnTransform;
    private BulletPool bulletPool;
    
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        PlayerRef = gameObjectRef;
        PlayerPlayerRef = PlayerRef.GetComponent<Player>();
        PlayerStateMachine = PlayerRef.GetComponent<StateMachine>();
        Animator = PlayerRef.GetComponent<Animator>();
        Rb = PlayerRef.GetComponent<Rigidbody2D>();
        CapsuleCollider = PlayerRef.GetComponent<CapsuleCollider2D>();
        ScreenInput = GameObject.Find("PlayerUI/Canvas/OnScreenControllers").GetComponent<OnScreenInput>();
        bulletSpawnPointLocal = PlayerRef.transform.Find("BulletSpawnPoint").localPosition;
        bulletSpawnTransform = PlayerRef.transform.Find("BulletSpawnPoint");
        bulletPool = PlayerRef.GetComponent<BulletPool>();


        OnHandleInputState();
        //Debug.Log("Entered: "+ this.name);
    }

    public override void OnHandleInputState()
    {
        base.OnHandleInputState();
        MoveX = ScreenInput.MoveX;
        Jump = ScreenInput.Jump;
        
        //Jump = Input.GetKey()
        if (MoveX < 0)
        {
            PlayerPlayerRef.facingRight = false;
            PlayerRef.GetComponent<SpriteRenderer>().flipX = true;
            bulletSpawnPointLocal.x = Math.Abs(bulletSpawnPointLocal.x)*-1;
        }
        else if (MoveX > 0)
        {
            PlayerPlayerRef.facingRight = true;
            PlayerRef.GetComponent<SpriteRenderer>().flipX = false;
            bulletSpawnPointLocal.x = Math.Abs(bulletSpawnPointLocal.x);
        }

        PlayerRef.transform.Find("BulletSpawnPoint").localPosition = bulletSpawnPointLocal;

        if (Fire == false)
        {
            if (ScreenInput.Shoot)
            {
                PressFire();
            }
        }
        Fire = ScreenInput.Shoot;
        
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (MoveX != 0.0f)
        {
            PressMoveRight();
        }

        if (Jump)
        {
            PressJump();
        }
        
    }

    protected virtual void PressJump()
    {
    }

    protected virtual void PressMoveRight()
    {
    }


    protected virtual void PressFire()
    {
        Bullet bullet = bulletPool.GetBulletFromPool().transform.Find("Bullet").GetComponent<Bullet>();
        bullet.transform.position = bulletSpawnTransform.position;
        if (PlayerPlayerRef.facingRight)
        {
            bullet.SetDirection(Vector2.right);
        }
        else
        {
            bullet.SetDirection(Vector2.left);
        }

    }

}
