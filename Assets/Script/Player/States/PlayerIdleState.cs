using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private readonly int IdleHash = Animator.StringToHash("idle");
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter(State previousState)
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.Play(IdleHash);

        stateMachine.InputReader.OnJumpStarted += SwitchToJumpstartState;
        stateMachine.InputReader.OnHatThrowHold += SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted += SwitchToBowtieState;
        stateMachine.InputReader.OnBowtieShieldHold += SwitchToBowtieShieldState;
        stateMachine.InputReader.OnHatTeleportStarted += TeleportToHat;
        Bounce.OnHatBounce += OnBounce;
        // TieAttackState.OnAttackSlide += OnAttackSlide;
        TieAttackState.OnMomentumStop += OnMomentumStop;
    }

    public override void Exit(State nextState)
    {
        stateMachine.InputReader.OnJumpStarted -= SwitchToJumpstartState;
        stateMachine.InputReader.OnHatThrowHold -= SwitchToHatThrowState;
        stateMachine.InputReader.OnBowtieDashStarted -= SwitchToBowtieState;
        stateMachine.InputReader.OnBowtieShieldHold -= SwitchToBowtieShieldState;
        stateMachine.InputReader.OnHatTeleportStarted -= TeleportToHat;
        Bounce.OnHatBounce -= OnBounce;
        // TieAttackState.OnAttackSlide -= OnAttackSlide;
        TieAttackState.OnMomentumStop -= OnMomentumStop;
    }

    public override void Tick()
    {
        float desiredVelocity = SetDesiredVelocity();
        if (desiredVelocity != 0f)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }

    public override void FixedTick()
    {
        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        ApplyHorizontalSpeed();
        FlipIfNeeded();
        Move();
    }
}
