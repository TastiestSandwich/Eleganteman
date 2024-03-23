using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventListener : MonoBehaviour
{
    public event Action OnJumpstartEnd;
    public event Action OnLandEnd;
    public event Action OnHatThrow;
    public event Action OnHatThrowEnd;
    public event Action OnHatHoldCharge;

    public void OnJumpstartAnimationEnd()
    {
        OnJumpstartEnd?.Invoke();
    }

    public void OnLandAnimationEnd()
    {
        OnLandEnd?.Invoke();
    }

    public void OnHatThrowAnimation()
    {
        OnHatThrow?.Invoke();
    }

    public void OnHatThrowAnimationEnd()
    {
        OnHatThrowEnd?.Invoke();
    }

    public void OnHatHoldChargeAnimation()
    {
        OnHatHoldCharge?.Invoke();
    }
}
