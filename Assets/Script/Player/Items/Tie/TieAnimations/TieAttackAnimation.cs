using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieAttackAnimation : TieAnimation
{
    public float chargeDistance;
    public float chargeVerticalOffset;
    public float chargeDuration;

    public float attackDistance;
    public float attackDuration;

    public void SetDirection(Vector3 direction)
    {
        this.isLoop = false;

        Vector3 chargeDirection = (-1 * direction + Vector3.up * chargeVerticalOffset).normalized;
        TieAnimationFrame chargeFrame = new TieSendTipFrame(chargeDuration, chargeDistance, chargeDirection);
        TieAnimationFrame attackFrame = new TieSendTipFrame(attackDuration, attackDistance, direction);

        this.frames = new TieAnimationFrame[2];
        this.frames[0] = chargeFrame;
        this.frames[1] = attackFrame;
    }
}
