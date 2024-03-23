using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BowtieShieldAbility : AbilityScriptable
{
    public float maxShieldEnergy;
    public float energyPerSecond;

    public float maxAcceleration;
    public float maxFallSpeed;
    public float moveFriction;
    public float moveDrag;
}