using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieInteractState : TieState
{
    private TieInteractAnimation animation;
    private Transform interactable;

    private AnimationCurve originalTieCurve;
    private AnimationCurve originalOutlineCurve;

    private float tieLengthExtension = 3f;
    private float tieHeadWidthMultiplier = 4f;
    private float outlineWidthMultiplier = 3.5f;
    private float tieHeadOffset = -0.1f;
    public TieInteractState(TieStateMachine stateMachine, Transform interactable) : base(stateMachine)
    {
        this.interactable = interactable;
    }

    public override void Enter(State previousState)
    {
        stateMachine.TieController.FaceController.toggle(true);

        animation = stateMachine.TieController.TieAnimator.tieInteractAnimation;
        animation.SetPosition(stateMachine.transform, interactable);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        stateMachine.TieController.SetFixedTieLength(stateMachine.TieController.defaultRopeSegLen * tieLengthExtension);

        originalTieCurve = stateMachine.TieController.lineRenderer.widthCurve;
        stateMachine.TieController.lineRenderer.widthCurve = createTieInteractionCurve(originalTieCurve, tieHeadWidthMultiplier);

        originalOutlineCurve = stateMachine.TieController.outlineRend.widthCurve;
        stateMachine.TieController.outlineRend.widthCurve = createTieInteractionCurve(originalOutlineCurve, outlineWidthMultiplier);

        stateMachine.InputReader.OnTieAttackStarted += SwitchToAttackState;
        stateMachine.InputReader.OnEleganceModHold += SwitchToPrepareGrabState;
    }

    public override void Exit(State nextState)
    {
        stateMachine.TieController.FaceController.toggle(false);

        stateMachine.TieController.ropeSegLen /= tieLengthExtension;

        stateMachine.TieController.lineRenderer.widthCurve = originalTieCurve;
        stateMachine.TieController.outlineRend.widthCurve = originalOutlineCurve;

        stateMachine.TieController.DisableFixedLength();

        stateMachine.InputReader.OnTieAttackStarted -= SwitchToAttackState;
        stateMachine.InputReader.OnEleganceModHold -= SwitchToPrepareGrabState;
    }

    public override void FixedTick()
    {
        // todo
    }

    public override void Tick()
    {
        // todo
    }

    public AnimationCurve createTieInteractionCurve(AnimationCurve originalCurve, float widthMultiplier)
    {
        AnimationCurve newCurve = new AnimationCurve();
        foreach(Keyframe key in originalCurve.keys)
        {
            newCurve.AddKey(key);
        }

        int penultimate = newCurve.length - 2;
        float newWidth = newCurve.keys[penultimate].value * widthMultiplier;
        float newTime = newCurve.keys[penultimate].time + tieHeadOffset;
        newCurve.MoveKey(penultimate, new Keyframe(newTime, newWidth));

        return newCurve;
    }
}
