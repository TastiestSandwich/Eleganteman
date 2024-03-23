using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowtieShieldState : PlayerState
{
    private readonly int BowtieShieldHash = Animator.StringToHash("idle");
    public PlayerBowtieShieldState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        //TODO play shield animation
        stateMachine.Animator.Play(BowtieShieldHash);

        stateMachine.Controller.BowtieShield.GetComponent<BowtieShieldController>()?.RaiseShield();

        stateMachine.InputReader.OnBowtieShieldRelease += ReleaseShield;
        stateMachine.InputReader.OnHatThrowHold += SwitchToHatThrowState;
        stateMachine.InputReader.OnHatTeleportStarted += TeleportToHat;
        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        stateMachine.Controller.BowtieShield.GetComponent<BowtieShieldController>()?.LowerShield();

        stateMachine.InputReader.OnBowtieShieldRelease -= ReleaseShield;
        stateMachine.InputReader.OnHatThrowHold -= SwitchToHatThrowState;
        stateMachine.InputReader.OnHatTeleportStarted -= TeleportToHat;
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.Abilities.bowtieShieldAbility.maxFallSpeed);
        float drag = stateMachine.AirDrag;

        if (!stateMachine.Controller.Ground.OnGround || desiredVelocity == 0)
            ApplyHorizontalSpeed(stateMachine.Abilities.bowtieShieldAbility.maxAcceleration);
        else
            drag += stateMachine.Abilities.bowtieShieldAbility.moveDrag;

        ApplyAirDrag(drag);
        Move();
    }

    public override void Tick()
    {
        SetDesiredVelocity(stateMachine.Abilities.bowtieShieldAbility.moveFriction);
    }

    private void ReleaseShield()
    {
        float desiredVelocity = SetDesiredVelocity();

        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        else if (desiredVelocity == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
        else
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }
}
