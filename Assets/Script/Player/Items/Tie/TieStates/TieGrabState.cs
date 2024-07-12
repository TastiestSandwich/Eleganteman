using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieGrabState : TieState
{
    private TieGrabAnimation animation;
    private Vector3 direction;

    private Transform grabbed = null;
    private Vector3 offset;
    public TieGrabState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        stateMachine.TieController.SetFixedTieLength(stateMachine.TieController.defaultRopeSegLen);
        this.direction = GetAttackDirection();
        float distance = stateMachine.PlayerAbilities.tieGrabAbility.grabLength * stateMachine.TieController.ropeSegLen;
        Vector3 position = stateMachine.TieController.ropeSegments[0].posNow
            + (direction * distance);

        ThrowGrabArea(distance);

        if (grabbed != null)
            position = grabbed.position + offset;

        animation = stateMachine.TieController.TieAnimator.tieGrabAnimation;
        animation.SetPosition(direction, position);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        animation.OnAnimationEnd += GrabOrExit;
        stateMachine.InputReader.OnTieAttackCanceled += ExitGrab;
    }

    public override void Exit(State nextState)
    {
        this.stateMachine.drawGrabRadius = false;

        animation.OnAnimationEnd -= GrabOrExit;
        stateMachine.InputReader.OnTieAttackCanceled -= ExitGrab;
    }

    public override void FixedTick()
    {
    }

    public override void Tick()
    {
    }

    private void ThrowGrabArea(float distance)
    {
        stateMachine.EnableGizmoCircles();

        float subdivisions = stateMachine.PlayerAbilities.tieGrabAbility.checkSubdivisions;
        float stepDistance = distance / subdivisions;

        for (float i = 1; i <= subdivisions; i++)
        {
            float dist = i * stepDistance;
            float objectGrabRadius = dist * Mathf.Tan(stateMachine.PlayerAbilities.tieGrabAbility.grabObjectAngle / 2);
            float surfaceGrabRadius = dist * Mathf.Tan(stateMachine.PlayerAbilities.tieGrabAbility.grabSurfaceAngle / 2);

            (grabbed, offset) = CheckAndGrab(dist, objectGrabRadius, stateMachine.PlayerAbilities.tieGrabAbility.grabbableObjectLayer);
            if (grabbed != null) return;

            (grabbed, offset) = CheckAndGrab(dist, surfaceGrabRadius, stateMachine.PlayerAbilities.tieGrabAbility.grabbableSurfaceLayer);
            if (grabbed != null) return;
        }
    }

    private void GrabOrExit()
    {
        if (grabbed != null)
            stateMachine.SwitchState(new TieHoldGrabState(stateMachine, grabbed, offset));
        else 
            ExitGrab();
    }

    private void ExitGrab()
    {
        stateMachine.TieController.DisableFixedLength();

        if (stateMachine.InputReader.isEleganceMod)
            stateMachine.SwitchState(new TiePrepareGrabState(stateMachine));
        else
            stateMachine.SwitchState(new TieIdleState(stateMachine));
    }

    private (Transform grabbed, Vector3 offset) CheckAndGrab(float distance, float radius, LayerMask layer)
    {
        Vector2 position = stateMachine.TieController.ropeSegments[0].posNow + distance * direction;
        stateMachine.AddGizmoCircle(position, radius, Color.blue);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layer);
        return GrabOntoClosest(colliders, position);
    }

    private (Transform transform, Vector3 offset) GrabOntoClosest(Collider2D[] colliders, Vector2 tipPosition)
    {
        if (colliders.Length <= 0) return (null, Vector3.zero);

        float closestDistance = float.PositiveInfinity;
        Transform closestTransform = null;
        Vector3 offset = Vector3.zero;

        foreach (Collider2D collider in colliders)
        {
            Vector3 point = collider.bounds.ClosestPoint(tipPosition);
            float distance = Vector3.Distance(point, tipPosition);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTransform = collider.transform;
                offset = point - collider.transform.position;
            }
        }

        Debug.Log("Grabbed something!");
        Debug.Log(closestTransform);
        Debug.Log(closestTransform.position + offset);
        return (closestTransform, offset);
    }
}
