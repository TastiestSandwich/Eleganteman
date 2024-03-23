using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieAnimator : MonoBehaviour
{
    public TieAttackAnimation tieAttackAnimation = new();
    public TieMoveAnimation tieMoveAnimation = new();
    public TiePrepareGrabAnimation tiePrepareGrabAnimation = new();
    public TieGrabAnimation tieGrabAnimation = new();
    public TieHoldGrabAnimation tieHoldGrabAnimation = new();
    public TiePointMenuAnimation tiePointMenuAnimation = new();

    public float animTime = 0;
    public TieAnimation currentAnimation = null;
    public int currentFrame = 0;

    public List<RopeSegment> SetAnimationConstraints(List<RopeSegment> segments)
    {
        if (currentAnimation == null) return segments;
        if (currentFrame >= currentAnimation.frames.Length) return segments;

        TieAnimationFrame frame = currentAnimation.frames[currentFrame];
        return frame.SetConstraints(segments, animTime);
    }

    public void AdvanceAnimTime(float deltaTime)
    {
        if (currentAnimation == null) return;
        
        animTime += deltaTime;

        // if animation is single frame loop, nothing to do
        if (currentAnimation.frames.Length <= 1 && currentAnimation.isLoop) return;

        TieAnimationFrame frame = currentAnimation.frames[currentFrame];

        // if frame still not finished, nothing to do
        if (animTime < frame.duration) return;

        EndFrame(frame);
        currentFrame++;

        // if more frames remaining, nothing to do
        if (currentFrame < currentAnimation.frames.Length)
            StartFrame(currentAnimation.frames[currentFrame]);
        else if (currentAnimation.isLoop)
            GoToAnimationStart();
        else
            SetAnimation(null);
    }

    public void SetAnimation(TieAnimation animation)
    {
        TieAnimation finishedAnimation = currentAnimation;
        currentAnimation = animation;
        
        finishedAnimation?.RaiseAnimationEnd();
        GoToAnimationStart();
    }

    public void GoToAnimationStart()
    {
        this.currentFrame = 0;
        if (currentAnimation != null)
            StartFrame(currentAnimation.frames[currentFrame]);
    }

    public void EndFrame(TieAnimationFrame frame)
    {
        frame.OnFrameEnd();
    }

    public void StartFrame(TieAnimationFrame frame)
    {
        frame.OnFrameStart();
        this.animTime = 0;
    }
}