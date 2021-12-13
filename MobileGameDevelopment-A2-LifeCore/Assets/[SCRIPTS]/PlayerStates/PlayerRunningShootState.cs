using UnityEngine;
[CreateAssetMenu(fileName = "PlayerRunningShootState", menuName = "ScriptableObjects/PlayerStates/PlayerRunningShootState", order = 1)]
public class PlayerRunningShootState : PlayerStateBase
{
    private double timer;
    public float animationTimer = 1.0f;
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Animator.Play("PlayerRunShoot");
        timer = 0.0f;
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        timer += Time.fixedDeltaTime;
        if (timer > animationTimer)
        {
            PlayerStateMachine.PopCurrentState();
        }
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
        timer = 0;
    }
}
