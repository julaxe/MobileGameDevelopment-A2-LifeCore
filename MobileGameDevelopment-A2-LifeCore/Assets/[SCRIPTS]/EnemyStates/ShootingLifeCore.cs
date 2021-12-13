
using UnityEngine;
[CreateAssetMenu(fileName = "ShootingLifeCore", menuName = "ScriptableObjects/EnemyStates/ShootingLifeCore", order = 1)]
public class ShootingLifeCore : EnemyBaseState
{
    private double timer;
    private double shootCooldown = 1.0;
    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        
        timer = 0;
    }

    public override void OnFixedUpdateState()
    {
        base.OnFixedUpdateState();
        EnemyRigidBody.velocity = Vector2.zero;
        timer += Time.fixedDeltaTime;
        if (timer > shootCooldown)
        {
            Shoot(LifeCoreRef.gameObject);
            timer = 0;
        }
        if (!InsideDetectionRadius(RadiusLifeCore, LifeCoreRef.gameObject))
        {
            EnemyStateMachine.PopCurrentState();
        }
    }
}
