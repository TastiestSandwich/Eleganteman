using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieMoveState : TieState
{
    public TieMoveState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        TieMoveAnimation animation = stateMachine.TieController.TieAnimator.tieMoveAnimation;
        animation.SetupAnimation();
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        stateMachine.InputReader.OnTieAttackStarted += SwitchToAttackState;
        stateMachine.InputReader.OnEleganceModHold += SwitchToPrepareGrabState;
    }

    public override void Exit(State nextState)
    {
        stateMachine.InputReader.OnTieAttackStarted -= SwitchToAttackState;
        stateMachine.InputReader.OnEleganceModHold -= SwitchToPrepareGrabState;
    }

    public override void FixedTick()
    {
        // do nothing
    }

    public override void Tick()
    {
        if (stateMachine.InputReader.MoveAxis == 0)
            stateMachine.SwitchState(new TieIdleState(stateMachine));
    }
}
