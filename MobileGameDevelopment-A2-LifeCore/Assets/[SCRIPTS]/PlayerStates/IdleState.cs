using UnityEditor;
using UnityEngine;

public class IdleState : State
{
    public override void Enter(PlayerController player) 
    {
        Debug.Log("Idle State entered");
    }
    public override void HandleInput(PlayerController player) 
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if(moveX != 0.0f || moveY != 0.0f)
        {
            player.PushNewState(new RunningState());
        }

    }
    public override void Update(PlayerController player) { }

    public override void FixedUpdate(PlayerController player) {
    
    }
    public override void Exit(PlayerController player) { }
}