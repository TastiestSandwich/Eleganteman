using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Attack attack;

    private bool isFromPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        isFromPlayer = transform.root.gameObject.CompareTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHittable(collider)) return;

        Vector2 direction = (collider.transform.position - transform.root.position).normalized;
        Debug.Log(direction);
        attack.OnAttackHit(direction, collider.transform.root.gameObject);
    }

    private bool isHittable(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Hurtbox")) return false;

        return ( (isFromPlayer && collider.transform.root.gameObject.CompareTag("Enemy"))
            || (!isFromPlayer && collider.transform.root.gameObject.CompareTag("Player")) );
    }

}
