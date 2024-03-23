using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieHoldGrabAnimation : TieAnimation
{
    public float duration;

    public void SetPoint(Vector3 point)
    {
        this.isLoop = true;

        TieHoldTipFrame holdFrame = new TieHoldTipFrame(duration, point);

        this.frames = new TieAnimationFrame[1];
        this.frames[0] = holdFrame;
    }
}
