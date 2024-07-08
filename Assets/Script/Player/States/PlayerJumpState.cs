using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private readonly int JumpHash = Animator.StringToHash("jump");
    private bool isShort = false;

    public PlayerJumpState(PlayerStateMachine stateMachine, bool isShort) : base(stateMachine) 
    {
        this.isShort = isShort;
    }

    public override void Enter(State previousState)
    {
        float jumpHeight = isShort ? stateMachine.ShortJumpHeight : stateMachine.JumpHeight;
        float jumpSpeed = GetJumpSpeed(jumpHeight);
        stateMachine.Velocity.y = jumpSpeed;

        stateMachine.Animator.Play(JumpHash);

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

        if (stateMachine.Velocity.y <= 0f)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        ApplyHorizontalSpeed();
        ApplyAirDrag(stateMachine.AirDrag);
        Move();
    }
}
