using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieMiddleHoldTipFrame : TieAnimationFrame
{
    private Vector3? startingPosition = null;
    private Transform pointA;
    private Transform pointB;

    public TieMiddleHoldTipFrame(float duration, Transform pointA, Transform pointB) : base(duration)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }

    public override void OnFrameEnd()
    {
        // cleanup maybe?
        this.startingPosition = null;
    }

    public override void OnFrameStart()
    {
    }

    public override List<RopeSegment> SetConstraints(List<RopeSegment> segments, float animTime)
    {
        int tipIndex = segments.Count - 1;
        RopeSegment tipSegment = segments[tipIndex];

        if (startingPosition == null)
            startingPosition = tipSegment.posNow;

        Vector3 point = (pointB.position + pointA.position) / 2;
        tipSegment.posNow = Vector3.Lerp(startingPosition.GetValueOrDefault(), point, (animTime / duration));
        segments[tipIndex] = tipSegment;

        return segments;
    }
}
