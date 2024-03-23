using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HatThrowAbility : AbilityScriptable
{
    public UnityEngine.U2D.Animation.SpriteLibraryAsset hatLibrary;
    public UnityEngine.U2D.Animation.SpriteLibraryAsset hatlessLibrary;

    public float HatThrowFriction = 5;
    public float HatThrowDrag = 0.05f;
    public float maxFallSpeed = -30;

    public float maxThrowSpeed = 80;
    public float minThrowSpeed = 5;
    public float maxDistance = 12f;

    //TODO player uses hatlessLibrary if hat is not unlocked?
}