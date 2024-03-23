using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowtieDashState : PlayerState
{
    private readonly int BowtieDashHash = Animator.StringToHash("idle");
    private float direction;
    public PlayerBowtieDashState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        // Play bowtie dash animation
        stateMachine.Animator.Play(BowtieDashHash);
        stateMachine.Velocity.x = 0;

        // maybe brief delay before dashing in direction? -> Do dash move on animation event
        // dash direction is opposite to facing
        direction = stateMachine.Controller.Facing * -1;

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void FixedTick()
    {
        stateMachine.Velocity.x = Mathf.MoveTowards(
            stateMachine.Velocity.x, 
            stateMachine.Abilities.bowtieDashAbility.BowtieDashSpeed * direction, 
            stateMachine.Abilities.bowtieDashAbility.BowtieDashAcceleration * Time.fixedDeltaTime);
        Move();

        float speed = Mathf.Abs(stateMachine.Controller.rb.velocity.x);
        if (speed >= stateMachine.Abilities.bowtieDashAbility.BowtieDashSpeed || speed <= stateMachine.Abilities.bowtieDashAbility.MinBowtieDashSpeed) {
            ExitDash();
        }
    }

    public override void Tick()
    {
        
    }

    private void ExitDash()
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
