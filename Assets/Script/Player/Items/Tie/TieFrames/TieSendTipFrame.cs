using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieSendTipFrame : TieAnimationFrame
{
    private float distance;
    private Vector3 direction;
    private Vector3? startingPosition = null;

    public TieSendTipFrame(float duration, float distance, Vector3 direction) : base(duration)
    {
        this.distance = distance;
        this.direction = direction;
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

    public override List<RopeSegment> SetConstraints(List<RopeSegment> segments, float ropeSegLen, float animTime)
    {
        int tipIndex = segments.Count - 1;
        RopeSegment tipSegment = segments[tipIndex];

        if (startingPosition == null)
            startingPosition = tipSegment.posNow;

        Vector3 targetPosition = segments[0].posNow + (direction * distance * ropeSegLen);
        tipSegment.posNow = Vector3.Lerp(startingPosition.GetValueOrDefault(), targetPosition, (animTime / duration));
        segments[tipIndex] = tipSegment;

        return segments;
    }
}
