using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpstartState : PlayerState
{
    private readonly int JumpStartHash = Animator.StringToHash("jump_start");
    public PlayerJumpstartState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Animator.Play(JumpStartHash);

        stateMachine.InputReader.OnJumpCanceled += SwitchToShortJumpState;
        stateMachine.AnimationListener.OnJumpstartEnd += SwitchToJumpState;
        stateMachine.InputReader.OnBowtieDashStarted += SwitchToBowtieState;
        stateMachine.InputReader.OnHatTeleportStarted += ExitAndTeleportToHat;
        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State previousState)
    {
        stateMachine.InputReader.OnJumpCanceled -= SwitchToShortJumpState;
        stateMachine.AnimationListener.OnJumpstartEnd -= SwitchToJumpState;
        stateMachine.InputReader.OnBowtieDashStarted -= SwitchToBowtieState;
        stateMachine.InputReader.OnHatTeleportStarted -= ExitAndTeleportToHat;
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void Tick()
    {
        SetDesiredVelocity(stateMachine.JumpStartFriction);
    }

    public override void FixedTick()
    {
        ApplyHorizontalSpeed();
        Move();
    }

    private void SwitchToShortJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine, true));
    }

    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine, false));
    }

    private void ExitAndTeleportToHat()
    {
        stateMachine.SwitchState(new PlayerFallState(stateMachine));
        TeleportToHat();
    }
}
