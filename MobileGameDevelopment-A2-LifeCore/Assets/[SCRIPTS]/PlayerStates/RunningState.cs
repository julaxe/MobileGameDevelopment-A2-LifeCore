using UnityEditor;
using UnityEngine;

public class RunningState : State
{
    Vector2 _moveDirection;
    public override void Enter(PlayerController player) 
    {
        Debug.Log("RunningState Enter");
    }
    public override void HandleInput(PlayerController player) 
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        _moveDirection = new Vector2(moveX, moveY);

        if (moveY == 0.0f && moveX == 0.0f && player.rb2D.velocity.magnitude == 0.0f)
        {
            player.PopState();
        }
    }
    public override void Update(PlayerController player) { }

    public override void FixedUpdate(PlayerController player)
    {
        player.rb2D.AddForce(_moveDirection * player.moveForce);
    }
    public override void Exit(PlayerController player) 
    {
        Debug.Log("--------Running State Exit---------");
    }
}