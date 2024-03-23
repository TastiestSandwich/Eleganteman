using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyAttackState : ChimneyState
{
    private readonly int attackHash = Animator.StringToHash("chimney_attack");

    public ChimneyAttackState(ChimneyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.Play(attackHash);

        SetDesiredVelocity(GetHorizontalInputTowardsPlayer());
        FlipIfNeeded();

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void Tick()
    {
        SetDesiredVelocity(0f);

    }

    public override void FixedTick()
    {
        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new ChimneyFallState(chimney));
        }

        // TODO attack state should end on animation end -> do animation trigger
        if (GetDistanceToPlayer() > chimney.attackDistance)
        {
            stateMachine.SwitchState(new ChimneyIdleState(chimney));
        }

        ApplyHorizontalSpeed();
        Move();
    }
}
