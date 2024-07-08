using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieAttackAbility : AbilityScriptable
{
    public float airMoveFriction = 5;
    public float groundDrag = 0.1f;
    public float slideDistance = 10;
    public float slideChargeDistance = 5;

    public float tipPercentage = 0.5f;
    public float hitboxWidth = 2;
    public float hitboxLengthPercentage = 1f;

    public LayerMask attackableLayer;
    public Attack attack;
}
