
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWalkingState", menuName = "ScriptableObjects/PlayerStates/PlayerWalkingState", order = 1)]
public class PlayerWalkState : PlayerStateBase
{
    
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerWalk");
        
        //add some force
        Rb.AddForce(Vector2.right * MoveX * walkingForce);
    }
    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (Rb.velocity == Vector2.zero && MoveX == 0)
        {
            PlayerStateMachine.PopCurrentState();
        }

        if (Rb.velocity.magnitude > velocityToRun)
        {
            PlayerStateMachine.PushStateByKey("Run");
        }
    }

    protected override void PressMoveRight()
    {
        base.PressMoveRight();
        Rb.AddForce(Vector2.right * MoveX * walkingForce);
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
        PlayerStateMachine.PushStateByKey("RunningShoot");
    }
}
