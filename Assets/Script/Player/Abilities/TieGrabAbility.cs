using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class TieGrabAbility : AbilityScriptable
{
    public LayerMask grabbableObjectLayer;
    public LayerMask grabbableSurfaceLayer;

    public float grabLength;
    public float grabSurfaceAngle;
    public float grabObjectAngle;
    public int checkSubdivisions;

    public float maxDesiredLength;
    public float minDesiredLength;

    public float pullStrengthUp;
    public float pullStrengthDown;

    public float maxSwingSpeed;
    public float swingAcceleration;
}
