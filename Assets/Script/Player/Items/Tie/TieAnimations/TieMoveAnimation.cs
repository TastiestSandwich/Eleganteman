using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieMoveAnimation : TieAnimation
{
    public float anchorPercent;
    public float wiggleSpeed;
    public float wiggleMagnitude;

    public void SetupAnimation()
    {
        this.isLoop = true;

        TieAnimationFrame moveFrame = new TieWiggleFrame(0, anchorPercent, wiggleSpeed, wiggleMagnitude);

        this.frames = new TieAnimationFrame[1];
        this.frames[0] = moveFrame;
    }
}
