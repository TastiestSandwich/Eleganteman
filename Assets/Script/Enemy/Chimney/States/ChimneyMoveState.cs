using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyMoveState : ChimneyState
{
    private readonly int MoveHash = Animator.StringToHash("chimney_idle");

    public ChimneyMoveState(ChimneyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.Play(MoveHash);

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void Tick()
    {
        if (GetDistanceToPlayer() > chimney.detectionDistance)
        {
            stateMachine.SwitchState(new ChimneyIdleState(chimney));
            return;
        }

        float desiredVelocity = SetDesiredVelocity(GetHorizontalInputTowardsPlayer());
        if (desiredVelocity == 0)
        {
            stateMachine.SwitchState(new ChimneyIdleState(chimney));
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
