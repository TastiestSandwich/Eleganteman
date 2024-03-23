using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowtieJumpState : PlayerState
{
    private readonly int BowtieJumpHash = Animator.StringToHash("idle");
    private Vector2 direction;

    private int frames = 0;
    private int accelFrames = 60;
    private int endFrames = 80;

    private bool isAccelerating = true;
    public PlayerBowtieJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        //TODO Play bowtie dash animation
        stateMachine.Animator.Play(BowtieJumpHash);

        SetBowtieDirection();
        Bounce.OnHatBounce += OnBounce;

        stateMachine.Abilities.bowtieDashAbility.timesBowtieJumped += 1;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void FixedTick()
    {
        ApplyHorizontalSpeed();

        if (isAccelerating)
        {
            stateMachine.Velocity += direction * stateMachine.Abilities.bowtieDashAbility.BowtieDashAcceleration * Time.fixedDeltaTime;
        }

        ApplyGravity(stateMachine.MaxFallSpeed);
        ApplyAirDrag(stateMachine.AirDrag);
        Move();

        if (stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerLandState(stateMachine));
        }
    }

    public override void Tick()
    {
        SetDesiredVelocity();
        SetBowtieDirection();

        //TODO Replace with animation stuff
        if (frames >= accelFrames)
        {
            isAccelerating = false;

            if (frames >= endFrames)
                stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        frames++;
    }

    private void SetBowtieDirection()
    {
        // dash direction is opposite to clamped (8-dir) joystick
        direction = stateMachine.InputReader.GetClampedDirection() * -1;

        // default direction is opposite to character facing
        if (direction.magnitude == 0)
            direction = Vector2.right * stateMachine.Controller.Facing * -1;
    }

}
