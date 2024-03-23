using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void OnAttackHit(Vector2 direction, GameObject hit)
    {
        Debug.Log("Hit");
    }
}
