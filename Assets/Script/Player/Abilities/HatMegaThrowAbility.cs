using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HatMegaThrowAbility : AbilityScriptable
{
    public float hatThrowRecoilSpeed = 100;

    public float maxThrowSpeed = 100;
    public float minThrowSpeed = 5;
    public float maxDistance = 30f;
}
