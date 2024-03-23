using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieTipAndWiggleFrame : TieAnimationFrame
{
    private float distance;
    private Vector3 direction;
    private Vector3? startingPosition = null;

    private float anchorPercent;
    private float wiggleSpeed;
    private float wiggleMagnitude;

    public TieTipAndWiggleFrame(float duration, float distance, Vector3 direction, float anchorPercent, float wiggleSpeed, float wiggleMagnitude) : base(duration)
    {
        this.distance = distance;
        this.direction = direction;
        this.anchorPercent = anchorPercent;
        this.wiggleSpeed = wiggleSpeed;
        this.wiggleMagnitude = wiggleMagnitude;
    }

    public override void OnFrameEnd()
    {
        // todo
        this.startingPosition = null;
    }

    public override void OnFrameStart()
    {
        // todo
    }

    public override List<RopeSegment> SetConstraints(List<RopeSegment> segments, float animTime)
    {
        int tipIndex = segments.Count - 1;
        int wiggleIndex = (int)(segments.Count * anchorPercent);
        RopeSegment tipSegment = segments[tipIndex];
        RopeSegment wiggleSegment = segments[wiggleIndex];

        if (startingPosition == null)
            startingPosition = tipSegment.posNow;

        Vector3 targetPosition = segments[0].posNow + (direction * distance);
        tipSegment.posNow = Vector3.Lerp(startingPosition.GetValueOrDefault(), targetPosition, (animTime / duration));

        Vector3 wiggleDirection = Vector2.Perpendicular(segments[0].posNow - tipSegment.posNow).normalized;
        wiggleSegment.posNow += wiggleDirection * (Mathf.Sin(animTime * wiggleSpeed) * wiggleMagnitude);

        segments[tipIndex] = tipSegment;
        segments[wiggleIndex] = wiggleSegment;
        return segments;
    }
}
