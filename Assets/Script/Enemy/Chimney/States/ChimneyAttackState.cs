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

        stateMachine.AnimationListener.OnAttackEnd += SwitchToIdleState;
        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        stateMachine.AnimationListener.OnAttackEnd -= SwitchToIdleState;
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

        ApplyHorizontalSpeed();
        Move();
    }
}
