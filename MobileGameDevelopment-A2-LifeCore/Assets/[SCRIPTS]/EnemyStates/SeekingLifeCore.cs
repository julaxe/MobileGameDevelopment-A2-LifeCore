
using UnityEngine;
[CreateAssetMenu(fileName = "SeekingLifeCore", menuName = "ScriptableObjects/EnemyStates/SeekingLifeCore", order = 1)]
public class SeekingLifeCore : EnemyBaseState
{
    
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        Seek(LifeCoreRef.gameObject);
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        if (InsideDetectionRadius(RadiusLifeCore, LifeCoreRef.gameObject))
        {
            EnemyStateMachine.PushStateByKey("ShootingLifeCore");
        }
        Seek(LifeCoreRef.gameObject);
    }
}
