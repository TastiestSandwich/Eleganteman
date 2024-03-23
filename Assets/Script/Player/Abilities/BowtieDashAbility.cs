using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BowtieDashAbility : AbilityScriptable
{
    public float BowtieDashSpeed = 100f;
    public float BowtieDashAcceleration = 5f;
    public float MinBowtieDashSpeed = 1f;
    public int maxBowtieJumps = 1;
    public int timesBowtieJumped = 0;
}
