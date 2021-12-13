using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerIdleState", menuName = "ScriptableObjects/PlayerStates/PlayerIdleState", order = 1)]
public class PlayerIdleState : PlayerStateBase
{
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerIdle");
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
        PlayerStateMachine.PushStateByKey("Shoot");
    }
}