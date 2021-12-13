
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerInAirState", menuName = "ScriptableObjects/PlayerStates/PlayerInAirState", order = 1)]
public class PlayerInAirState : PlayerStateBase
{
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerJump");
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (CapsuleCollider.IsTouchingLayers())
        {
            PlayerStateMachine.PopCurrentState();
        }

        CapsuleCollider.enabled = Rb.velocity.y <= 0;
    }
    protected override void PressMoveRight()
    {
        base.PressMoveRight();
        Rb.AddForce(Vector2.right * MoveX * walkingForce);
    }

    protected override void PressFire()
    {
        base.PressFire();
        PlayerStateMachine.PushStateByKey("InAirShoot");
    }
}
