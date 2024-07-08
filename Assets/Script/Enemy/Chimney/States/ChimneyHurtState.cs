using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyHurtState : ChimneyState
{
    private int animTime;
    private readonly int FallStartHash = Animator.StringToHash("chimney_idle");

    public ChimneyHurtState(ChimneyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter(State previousState)
    {
        stateMachine.Animator.Play(FallStartHash);
        // stateMachine.Controller.SetHurtbox(false);
        animTime = 0;

        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        Bounce.OnHatBounce -= OnBounce;
        // stateMachine.Controller.SetHurtbox(true);
    }

    public override void Tick()
    {
        //TODO change to event on hurt animation end
        // Variable hurt duration depending on attack?
        animTime++;
        if (animTime > 60)
        {
            if (!stateMachine.Controller.Ground.OnGround)
            {
                stateMachine.SwitchState(new ChimneyFallState(chimney));
            }
            else
            {
                stateMachine.SwitchState(new ChimneyIdleState(chimney));
            }
        }
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.MaxFallSpeed);
        ApplyHorizontalSpeed();
        ApplyAirDrag(stateMachine.AirDrag);
        Move();

        if (stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new ChimneyIdleState(chimney));
        }
    }
}
