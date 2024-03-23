using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieHoldGrabState : TieState
{
    private TieHoldGrabAnimation animation;
    private Transform grabbed;
    private Vector3 offset;

    public TieHoldGrabState(TieStateMachine stateMachine, Transform grabbed, Vector3 offset) : base(stateMachine)
    {
        this.grabbed = grabbed;
        this.offset = offset;
    }

    public override void Enter(State previousState)
    {
        stateMachine.grabbed = new TieStateMachine.Grabbed(grabbed, offset);

        animation = stateMachine.TieController.TieAnimator.tieHoldGrabAnimation;
        animation.SetPoint(grabbed.position + offset);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        stateMachine.InputReader.OnTieAttackCanceled += ExitHoldGrab;
    }

    public override void Exit(State nextState)
    {
        stateMachine.grabbed = null;
        stateMachine.TieController.ropeSegLen = stateMachine.TieController.defaultRopeSegLen;

        stateMachine.InputReader.OnTieAttackCanceled -= ExitHoldGrab;
    }

    public override void FixedTick()
    {
        // apply forces to character i guess -> this is done in character instead
        stateMachine.TieController.ropeSegLen = stateMachine.desiredLength / stateMachine.TieController.ropeSegments.Count;
    }

    public override void Tick()
    {
        // check for trigger float and adjust desired tie length for forces in fixed tick -> this is done in input
        stateMachine.desiredLength = stateMachine.PlayerAbilities.tieGrabAbility.minDesiredLength +
            (stateMachine.PlayerAbilities.tieGrabAbility.maxDesiredLength * stateMachine.InputReader.EleganceValue);
    }

    private void ExitHoldGrab()
    {
        if (stateMachine.InputReader.isEleganceMod)
            stateMachine.SwitchState(new TiePrepareGrabState(stateMachine));
        else
            stateMachine.SwitchState(new TieIdleState(stateMachine));
    }
}
