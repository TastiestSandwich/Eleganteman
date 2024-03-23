using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceHeight = 50;
    public float scaleStep = 0.1f;
    public float scaleTime = 0.5f;
    public float cooldownTime = 3;

    public BoxCollider2D topCollider;
    public HatController hatController = null;

    private Collider2D[] colliders;

    // direction, bounceHeight, object collided
    public static event Action<Vector2, float, GameObject> OnHatBounce;

    public bool bounceEnabled = true;

    private void Awake()
    {
        colliders = GetComponents<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isBounceable(collider)) return;

        topCollider.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!isBounceable(collider)) return;

        topCollider.enabled = true;
    }

    private void TriggerBounce(Vector2 direction, GameObject gameObject)
    {
        direction.Normalize();

        //TODO find a better way to only trigger bounce on whatever collided
        OnHatBounce?.Invoke(direction, bounceHeight, gameObject);

        if (hatController != null)
            hatController.Return();
        else
            StartCoroutine(DisappearAndReappear());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBounceable(collision.collider) || !bounceEnabled) return;

        Vector2 direction = collision.GetContact(0).normal * -1;
        TriggerBounce(direction, collision.collider.gameObject);
    }

    IEnumerator DisappearAndReappear()
    {
        // First disappear
        SetEnabledColliders(false);

        float startingScale = this.transform.localScale.x;
        float stepTime = scaleTime / (startingScale / scaleStep);

        while (transform.localScale.x > 0)
        {
            ScaleHat(0, scaleStep);
            yield return new WaitForSeconds(stepTime);
        }

        // wait the cooldown
        yield return new WaitForSeconds(cooldownTime);

        // reappear
        while (transform.localScale.x < startingScale)
        {
            ScaleHat(startingScale, scaleStep);
            yield return new WaitForSeconds(stepTime);
        }

        SetEnabledColliders(true);
    }

    private void ScaleHat(float to, float step)
    {
        float scaleX = Mathf.MoveTowards(transform.localScale.x, to, step);
        float scaleY = Mathf.MoveTowards(transform.localScale.y, to, step);
        transform.localScale = new Vector3(scaleX, scaleY);
    }

    private void SetEnabledColliders(bool enabled)
    {
        foreach (Collider2D col in colliders)
            col.enabled = enabled;
    }

    private bool isBounceable(Collider2D collider)
    {
        return (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"));
    }
}
