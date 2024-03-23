using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyFallState : ChimneyState
{
    private readonly int FallStartHash = Animator.StringToHash("chimney_idle");

    public ChimneyFallState(ChimneyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Animator.Play(FallStartHash);

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void Tick()
    {
        SetDesiredVelocity(GetHorizontalInputTowardsPlayer());
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.MaxFallSpeed);
        ApplyHorizontalSpeed();
        ApplyAirDrag(stateMachine.AirDrag);
        Move();

        if (stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new ChimneyIdleState(chimney));
        }
    }
}
