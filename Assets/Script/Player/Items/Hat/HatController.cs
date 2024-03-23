using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private int facing = 1;
    private Vector2 direction;
    private Vector3 startPosition;
    private Vector3 throwPosition;
    private Vector3 returnPosition;
    private float previousSqrSpeed = float.MaxValue;

    private float maxThrowSpeed;
    private float minThrowSpeed;
    private float maxDistance;

    public float returnSpeed = 40;
    public float regrabDistance = 1f;
    public float minScale = 0.1f;
    public float scaleStep = 0.01f;
    public float bounceDistance;

    public HatState state = HatState.WAITING;
    private PlayerStateMachine thrower;

    public Rigidbody2D rb;
    public Bounce bounce;
    private BoxCollider2D col;
    private BoxCollider2D topCol;

    public enum HatState
    {
        WAITING, THROWING, HOLDING, RETURNING
    }

    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.localPosition;
        gameObject.SetActive(false);
        this.rb = GetComponent<Rigidbody2D>();
        this.bounce = GetComponent<Bounce>();

        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        col = colliders[0];
        topCol = colliders[1];
    }

    void FixedUpdate()
    {
        if (state == HatState.THROWING)
        {
            float distanceTraveled = Vector2.Distance(transform.position, throwPosition);

            // only enable bounce after some distance travelled
            if (!bounce.bounceEnabled && distanceTraveled >= bounceDistance)
                bounce.bounceEnabled = true;

            // end throw at maxDistance or when slowing down
            if (distanceTraveled >= maxDistance ||
                (rb.velocity.sqrMagnitude < minThrowSpeed && previousSqrSpeed < minThrowSpeed))
            {
                state = HatState.HOLDING;
                rb.velocity = Vector2.zero;
                bounce.bounceEnabled = true;
                previousSqrSpeed = float.MaxValue;
            }
            else
            {
                previousSqrSpeed = rb.velocity.sqrMagnitude;
                // Hat decelerates as it comes closer to endpoint
                float throwSpeed = Mathf.Max(minThrowSpeed, maxThrowSpeed * ((maxDistance - distanceTraveled) / maxDistance));
                rb.velocity = direction * throwSpeed;
            }
        }
    }

    private void Update()
    {
        if (state == HatState.RETURNING)
        {
            float step = returnSpeed * Time.deltaTime;

            Vector3 returnPoint = thrower.transform.position + returnPosition;
            transform.position = Vector2.MoveTowards(transform.position, returnPoint, step);
            float distance = Vector2.Distance(transform.position, returnPoint);

            // when close to thrower, or animation ends, go back to waiting
            if (distance <= regrabDistance || transform.localScale.magnitude <= minScale)
            {
                Regrab();
            }
            else
            {
                float scaleX = Mathf.MoveTowards(transform.localScale.x, 0, scaleStep);
                float scaleY = Mathf.MoveTowards(transform.localScale.y, 0, scaleStep);
                transform.localScale = new Vector3(scaleX, scaleY);
            }
        }
    }

    public void Throw(PlayerStateMachine stateMachine, Vector2 direction, bool isMegaThrow)
    {
        if (state == HatState.WAITING)
        {
            thrower = stateMachine;
            gameObject.SetActive(true);
            transform.SetParent(null);
            state = HatState.THROWING;
            bounce.bounceEnabled = false;

            this.direction = direction;
            this.facing = thrower.Controller.Facing;
            this.returnPosition = new Vector3(startPosition.x * facing, startPosition.y, startPosition.z);
            this.throwPosition = thrower.transform.position + returnPosition;

            this.maxThrowSpeed = isMegaThrow ? stateMachine.Abilities.hatMegaThrowAbility.maxThrowSpeed : stateMachine.Abilities.hatThrowAbility.maxThrowSpeed;
            this.minThrowSpeed = isMegaThrow ? stateMachine.Abilities.hatMegaThrowAbility.minThrowSpeed : stateMachine.Abilities.hatThrowAbility.minThrowSpeed;
            this.maxDistance = isMegaThrow ? stateMachine.Abilities.hatMegaThrowAbility.maxDistance : stateMachine.Abilities.hatThrowAbility.maxDistance;
            // this.bounceDistance = maxDistance / 3;

            thrower.InputReader.OnHatThrowHold += Return;

            thrower.hasHat = false;
            thrower.SpriteLibrary.spriteLibraryAsset = thrower.Abilities.hatThrowAbility.hatlessLibrary;
        }
    }

    public void Return()
    {
        thrower.InputReader.OnHatThrowHold -= Return;
        SetCollidersEnabled(false);
        state = HatState.RETURNING;
    }

    public void Regrab()
    {
        // in case hat is regrabbed by other means, desubscribe from return
        thrower.InputReader.OnHatThrowHold -= Return;

        state = HatState.WAITING;
        transform.SetParent(thrower.transform);
        transform.localPosition = startPosition;
        transform.localScale = Vector3.one;
        gameObject.SetActive(false);
        SetCollidersEnabled(true);

        thrower.hasHat = true;
        thrower.SpriteLibrary.spriteLibraryAsset = thrower.Abilities.hatThrowAbility.hatLibrary;
    }

    public void SetCollidersEnabled(bool enabled)
    {
        this.col.enabled = enabled;
        this.topCol.enabled = enabled;
        bounce.bounceEnabled = enabled;
    }

}
