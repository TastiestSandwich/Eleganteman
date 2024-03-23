using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieIdleState : TieState
{
    public TieIdleState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        TieAnimator tieAnimator = stateMachine.TieController.TieAnimator;
        tieAnimator.SetAnimation(null);

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
        if (stateMachine.InputReader.MoveAxis != 0)
            stateMachine.SwitchState(new TieMoveState(stateMachine));
    }
}
