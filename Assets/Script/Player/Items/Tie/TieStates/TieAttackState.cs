using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieAttackState : TieState
{
    private TieAttackAnimation animation;
    public TieAttackState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        Vector2 direction = GetAttackDirection();

        animation = stateMachine.TieController.TieAnimator.tieAttackAnimation;
        animation.SetDirection(direction);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        animation.OnAnimationEnd += ExitAttack;
        stateMachine.InputReader.OnEleganceModHold += SwitchToGrabState;
    }

    public override void Exit(State nextState)
    {
        animation.OnAnimationEnd -= ExitAttack;
        stateMachine.InputReader.OnEleganceModHold -= SwitchToGrabState;
    }

    public override void FixedTick()
    {
        // todo
    }

    public override void Tick()
    {
        // todo
    }

    private void ExitAttack()
    {
        //TODO check if character is in moving state (???)
        stateMachine.SwitchState(new TieIdleState(stateMachine));
    }
}
