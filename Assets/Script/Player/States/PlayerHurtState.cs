using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    private int animTime;
    private readonly int FallStartHash = Animator.StringToHash("fall_start");

    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Animator.Play(FallStartHash);
        stateMachine.Controller.SetHurtbox(false);
        animTime = 0;

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
        stateMachine.Controller.SetHurtbox(true);
    }

    public override void Tick()
    {
        SetDesiredVelocity();
        animTime++;
        if(animTime > 60)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.MaxFallSpeed);
        ApplyAirDrag(stateMachine.AirDrag);
        Move();
    }
}