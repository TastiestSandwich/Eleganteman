using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class TieAnimation
{
    public bool isLoop;
    public TieAnimationFrame[] frames;
    public Action OnAnimationEnd;

    public void RaiseAnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}

[System.Serializable]
public abstract class TieAnimationFrame
{
    public float duration;
    public Action OnStart;

    public TieAnimationFrame(float duration)
    {
        this.duration = duration;
    }

    public abstract List<RopeSegment> SetConstraints(List<RopeSegment> segments, float animTime);
    public abstract void OnFrameStart();
    public abstract void OnFrameEnd();
}
