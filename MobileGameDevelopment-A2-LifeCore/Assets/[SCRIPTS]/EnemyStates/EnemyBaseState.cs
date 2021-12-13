using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : StateBase
{
    protected Enemy EnemyRef;
    protected Player PlayerRef;

    public override void OnEnterState(GameObject gameObjectRef)
    {
        base.OnEnterState(gameObjectRef);
        EnemyRef = gameObjectRef.GetComponent<Enemy>();
        PlayerRef = GameObject.Find("Player").GetComponent<Player>();
    }
    
    
}
