
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerShoot", menuName = "ScriptableObjects/PlayerStates/PlayerShoot", order = 1)]
public class PlayerShoot : PlayerStateBase
{
    private double timer;
    public float animationTimer = 1.0f;
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerShoot");
        timer = 0;
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        timer += Time.fixedDeltaTime;
        if (timer > animationTimer)
        {
            PlayerStateMachine.PopCurrentState();
        }
    }

    protected override void PressMoveRight()
    {
        base.PressMoveRight();
        PlayerStateMachine.PushStateByKey("Walk");
    }

    protected override void PressJump()
    {
        base.PressJump();
        PlayerStateMachine.PushStateByKey("InAir");
        Rb.AddForce(Vector2.up * jumpForce);
    }

    protected override void PressFire()
    {
        base.PressFire();
        //shoot the bullet
        timer = 0;
    }
}
