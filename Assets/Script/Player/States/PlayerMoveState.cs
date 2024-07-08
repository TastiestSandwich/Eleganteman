using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private readonly int MoveStartHash = Animator.StringToHash("move_start");

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.Play(MoveStartHash);
            
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
        /*
        if (stateMachine.Abilities.tieAttackAbility.unlocked)
        {
            stateMachine.Controller.Tie.TieController.TieAnimator.SetAnimation(null);
        }
        */

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
        if (desiredVelocity == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
    }

    public override void FixedTick()
    {
        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        ApplyHorizontalSpeed();
        bool flipped = FlipIfNeeded();
        Move();

        //TODO if flipped, switch to flipping state? play flipping animation?
    }
}
