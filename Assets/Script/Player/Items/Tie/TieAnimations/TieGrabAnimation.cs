using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieGrabAnimation : TieAnimation
{
    public float chargeDistance;
    public float chargeVerticalOffset;
    public float chargeDuration;

    public float grabDuration;

    public void SetPosition(Vector3 direction, Vector3 position)
    {
        this.isLoop = false;

        Vector3 chargeDirection = (-1 * direction + Vector3.up * chargeVerticalOffset).normalized;
        TieAnimationFrame chargeFrame = new TieSendTipFrame(chargeDuration, chargeDistance, chargeDirection);
        TieAnimationFrame grabFrame = new TieMoveTipToFrame(grabDuration, position);

        this.frames = new TieAnimationFrame[2];
        this.frames[0] = chargeFrame;
        this.frames[1] = grabFrame;
    }
}
