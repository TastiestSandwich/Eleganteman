using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    private readonly int FallStartHash = Animator.StringToHash("fall_start");

    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Animator.Play(FallStartHash);

        Bounce.OnHatBounce += OnBounce;
        TieAttackState.OnAttackSlide += OnAttackSlide;
        TieAttackState.OnMomentumStop += OnMomentumStop;
        stateMachine.InputReader.OnHatThrowHold += SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted += SwitchToBowtieState;
        stateMachine.InputReader.OnBowtieShieldHold += SwitchToBowtieShieldState;
        stateMachine.InputReader.OnHatTeleportStarted += TeleportToHat;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
        TieAttackState.OnAttackSlide -= OnAttackSlide;
        TieAttackState.OnMomentumStop -= OnMomentumStop;
        stateMachine.InputReader.OnHatThrowHold -= SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted -= SwitchToBowtieState;
        stateMachine.InputReader.OnBowtieShieldHold -= SwitchToBowtieShieldState;
        stateMachine.InputReader.OnHatTeleportStarted -= TeleportToHat;
    }

    public override void Tick()
    {
        SetDesiredVelocity();
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.MaxFallSpeed);
        ApplyHorizontalSpeed();
        ApplyAirDrag(stateMachine.AirDrag);
        Move();

        if (stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerLandState(stateMachine));
        }
    }
}
