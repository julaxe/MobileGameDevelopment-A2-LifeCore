using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerRunningState", menuName = "ScriptableObjects/PlayerStates/PlayerRunningState", order = 1)]
public class PlayerRunningState : PlayerStateBase
{
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerRun");
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (Rb.velocity.magnitude < velocityToRun)
        {
            PlayerStateMachine.PopCurrentState();
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