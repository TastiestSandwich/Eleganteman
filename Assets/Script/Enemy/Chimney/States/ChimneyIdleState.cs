using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyIdleState : ChimneyState
{
    private readonly int IdleHash = Animator.StringToHash("chimney_idle");

    public ChimneyIdleState(ChimneyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.Play(IdleHash);

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void Tick()
    {
        if (GetDistanceToPlayer() > chimney.detectionDistance) return;

        float desiredVelocity = SetDesiredVelocity(GetHorizontalInputTowardsPlayer());
        if (desiredVelocity != 0f)
        {
            stateMachine.SwitchState(new ChimneyMoveState(chimney));
        }
    }

    public override void FixedTick()
    {
        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new ChimneyFallState(chimney));
        }

        // check if close enough to player to switch to attack
        if (GetDistanceToPlayer() < chimney.attackDistance)
        {
            stateMachine.SwitchState(new ChimneyAttackState(chimney));
        }

        ApplyHorizontalSpeed();
        FlipIfNeeded();
        Move();
    }
}
