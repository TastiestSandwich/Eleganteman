using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieMoveTipToFrame : TieAnimationFrame
{
    private Vector3 position;
    private Vector3? startingPosition = null;

    public TieMoveTipToFrame(float duration, Vector3 position) : base(duration)
    {
        this.position = position;
    }

    public override void OnFrameEnd()
    {
        // cleanup maybe?
        this.startingPosition = null;
    }

    public override void OnFrameStart()
    {
        OnStart?.Invoke();
    }

    public override List<RopeSegment> SetConstraints(List<RopeSegment> segments, float animTime)
    {
        int tipIndex = segments.Count - 1;
        RopeSegment tipSegment = segments[tipIndex];

        if (startingPosition == null)
            startingPosition = tipSegment.posNow;

        tipSegment.posNow = Vector3.Lerp(startingPosition.GetValueOrDefault(), position, (animTime / duration));
        segments[tipIndex] = tipSegment;

        return segments;
    }
}
