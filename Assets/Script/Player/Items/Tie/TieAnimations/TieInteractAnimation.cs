using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieInteractAnimation : TieAnimation
{
    public float moveDuration;

    public void SetPosition(Transform player, Transform interactable)
    {
        this.isLoop = true;

        TieAnimationFrame moveFrame = new TieMiddleHoldTipFrame(moveDuration, player, interactable);

        this.frames = new TieAnimationFrame[1];
        this.frames[0] = moveFrame;
    }
}
