using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerState
{
    private readonly int LandHash = Animator.StringToHash("land");
    private readonly int ShortLandHash = Animator.StringToHash("short_land");

    public PlayerLandState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        if(stateMachine.Velocity.y < stateMachine.LongLandSpeedThreshold)
            stateMachine.Animator.Play(LandHash);
        else
            stateMachine.Animator.Play(ShortLandHash);

        stateMachine.Velocity.y = 0;

        stateMachine.InputReader.OnJumpStarted += SwitchToJumpstartState;
        stateMachine.InputReader.OnHatThrowHold += SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted += SwitchToBowtieState;
        stateMachine.AnimationListener.OnLandEnd += ExitLand;
        stateMachine.InputReader.OnHatTeleportStarted += TeleportToHat;
        Bounce.OnHatBounce += OnBounce;
        // TieAttackState.OnAttackSlide += OnAttackSlide;
        TieAttackState.OnMomentumStop += OnMomentumStop;

        stateMachine.Abilities.bowtieDashAbility.timesBowtieJumped = 0;
    }

    public override void Exit(State nextState)
    {
        stateMachine.InputReader.OnJumpStarted -= SwitchToJumpstartState;
        stateMachine.InputReader.OnHatThrowHold -= SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted -= SwitchToBowtieState;
        stateMachine.AnimationListener.OnLandEnd -= ExitLand;
        stateMachine.InputReader.OnHatTeleportStarted -= TeleportToHat;
        Bounce.OnHatBounce -= OnBounce;
        // TieAttackState.OnAttackSlide -= OnAttackSlide;
        TieAttackState.OnMomentumStop -= OnMomentumStop;
    }

    public override void Tick()
    {
        SetDesiredVelocity(stateMachine.LandFriction);
    }

    public override void FixedTick()
    {
        if (!stateMachine.Controller.Ground.OnGround)
            stateMachine.SwitchState(new PlayerFallState(stateMachine));

        ApplyHorizontalSpeed();
        Move();
    }

    private void ExitLand()
    {
        float desiredVelocity = SetDesiredVelocity();

        if (desiredVelocity == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
        else
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }
}
