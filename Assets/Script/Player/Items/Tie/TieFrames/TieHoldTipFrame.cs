using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieHoldTipFrame : TieAnimationFrame
{
    private Vector3 point;
    private Vector3? startingPosition = null;

    public TieHoldTipFrame(float duration, Vector3 point) : base(duration)
    {
        this.duration = duration;
        this.point = point;
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

        tipSegment.posNow = Vector3.Lerp(startingPosition.GetValueOrDefault(), point, (animTime / duration));
        segments[tipIndex] = tipSegment;

        return segments;
    }
}
