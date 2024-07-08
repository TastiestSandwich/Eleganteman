using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Attack : ScriptableObject
{
    public virtual void OnAttackHit(Vector2 direction, GameObject hit)
    {
        Debug.Log("Hit");
    }
}
