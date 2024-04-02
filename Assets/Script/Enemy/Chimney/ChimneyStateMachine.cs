using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class ChimneyStateMachine : EnemyStateMachine
{
    public float attackDistance;
    public float detectionDistance;

    public PlayerAnimationEventListener AnimationListener { get; private set; }

    public override void Start()
    {
        base.Start();

        SwitchState(new ChimneyIdleState(this));
    }
}
