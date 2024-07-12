using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieWiggleFrame : TieAnimationFrame
{
    private float anchorPercent;
    private float wiggleSpeed;
    private float wiggleMagnitude;

    public TieWiggleFrame(float duration, float anchorPercent, float wiggleSpeed, float wiggleMagnitude) : base(duration)
    {
        this.anchorPercent = anchorPercent;
        this.wiggleSpeed = wiggleSpeed;
        this.wiggleMagnitude = wiggleMagnitude;
    }

    public override void OnFrameEnd()
    {
        // nothing
    }

    public override void OnFrameStart()
    {
        // nothing
    }

    public override List<RopeSegment> SetConstraints(List<RopeSegment> segments, float ropeSegLen, float animTime)
    {
        int wiggleIndex = (int)(segments.Count * anchorPercent);
        RopeSegment wiggleSegment = segments[wiggleIndex];
        wiggleSegment.posNow.y += Mathf.Sin(animTime * wiggleSpeed) * wiggleMagnitude;
        segments[wiggleIndex] = wiggleSegment;
        return segments;
    }
}
