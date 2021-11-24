using UnityEditor;
using UnityEngine;

public class State
{
    public virtual void Enter(PlayerController player) { }
    public virtual void HandleInput(PlayerController player) { }
    public virtual void Update(PlayerController player) { }
    public virtual void FixedUpdate(PlayerController player) { }
    public virtual void Exit(PlayerController player) { }
}