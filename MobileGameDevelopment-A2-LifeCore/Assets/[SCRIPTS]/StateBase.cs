using UnityEditor;
using UnityEngine;

public class StateBase : ScriptableObject
{
    public virtual void OnEnterState(GameObject gameObjectRef) { }
    public virtual void OnHandleInputState() { }
    public virtual void OnUpdateState() { }
    public virtual void OnFixedUpdateState() { }
    public virtual void OnExitState() { }
}