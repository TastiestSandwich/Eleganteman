using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventListener : MonoBehaviour
{
    public event Action OnAttackEnd;

    public void OnAttackAnimationEnd()
    {
        OnAttackEnd?.Invoke();
    }
}
