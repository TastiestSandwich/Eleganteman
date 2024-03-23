using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TiePrepareGrabAnimation : TieAnimation
{
    public float chargeDistance;
    public float chargeVerticalOffset;
    public float chargeDuration;

    public float anchorPercent;
    public float wiggleSpeed;
    public float wiggleMagnitude;
    public void SetDirection(Vector3 direction)
    {
        this.isLoop = true;

        Vector3 chargeDirection = (-1 * direction + Vector3.up * chargeVerticalOffset).normalized;
        TieAnimationFrame chargeFrame = new TieTipAndWiggleFrame(chargeDuration, chargeDistance, chargeDirection, anchorPercent, wiggleSpeed, wiggleMagnitude);

        this.frames = new TieAnimationFrame[1];
        this.frames[0] = chargeFrame;
    }
}
