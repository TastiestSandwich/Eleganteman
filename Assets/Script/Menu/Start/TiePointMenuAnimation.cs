using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TiePointMenuAnimation : TieAnimation
{
    public float duration;

    public float anchorPercent;
    public float wiggleSpeed;
    public float wiggleMagnitude;

    public void SetPoint(bool isLoop, Vector3 endPoint, Vector3 startingPoint)
    {
        this.isLoop = isLoop;

        Vector3 direction = (endPoint - startingPoint).normalized;
        float distance = Vector3.Distance(startingPoint, endPoint);

        TieTipAndWiggleFrame frame = new TieTipAndWiggleFrame
            (duration, distance, direction, anchorPercent, wiggleSpeed, wiggleMagnitude);

        this.frames = new TieAnimationFrame[1];
        this.frames[0] = frame;
    }
}
