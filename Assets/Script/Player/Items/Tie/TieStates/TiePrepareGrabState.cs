using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiePrepareGrabState : TieState
{
    private TiePrepareGrabAnimation animation;
    private Vector2 direction;
    public TiePrepareGrabState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        direction = GetAttackDirection();

        animation = stateMachine.TieController.TieAnimator.tiePrepareGrabAnimation;
        animation.SetDirection(direction);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        stateMachine.InputReader.OnTieAttackStarted += SwitchToGrabState;
        stateMachine.InputReader.OnEleganceModRelease += ExitPrepareGrab;
    }

    public override void Exit(State nextState)
    {
        stateMachine.InputReader.OnTieAttackStarted -= SwitchToGrabState;
        stateMachine.InputReader.OnEleganceModRelease -= ExitPrepareGrab;
    }

    public override void FixedTick()
    {
        // nothing
    }

    public override void Tick()
    {
        Vector2 newDirection = GetAttackDirection();
        if (direction.x != newDirection.x || direction.y != newDirection.y)
        {
            direction = newDirection;
            animation.SetDirection(direction);
            stateMachine.TieController.TieAnimator.SetAnimation(animation);
        }
    }

    private void ExitPrepareGrab()
    {
        stateMachine.SwitchState(new TieIdleState(stateMachine));
    }
}
