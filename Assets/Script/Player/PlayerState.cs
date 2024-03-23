using UnityEngine;

public abstract class PlayerState : State
{
    protected readonly PlayerStateMachine stateMachine;
    protected float desiredVelocity;

    protected PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected float SetDesiredVelocity(float stateFriction = 0)
    {
        this.desiredVelocity = stateMachine.InputReader.MoveAxis * Mathf.Max(stateMachine.MaxSpeed - stateMachine.Controller.Ground.Friction - stateFriction, 0f);
        return desiredVelocity;
    }

    protected void ApplyGravity(float maxFallSpeed)
    {
        if (stateMachine.Velocity.y > maxFallSpeed)
            stateMachine.Velocity.y += stateMachine.Gravity * Time.fixedDeltaTime;

        else if (stateMachine.Velocity.y < maxFallSpeed)
            stateMachine.Velocity.y = maxFallSpeed;
    }

    protected void ApplyTiePull()
    {
        if (stateMachine.Controller.Tie.grabbed == null) return;

        TieStateMachine.Grabbed grabbed = stateMachine.Controller.Tie.grabbed.GetValueOrDefault();
        Vector2 grabPoint = grabbed.transform.position + grabbed.offset;
        Vector2 neckPoint = stateMachine.Controller.Tie.transform.position;
        float distance = Vector2.Distance(grabPoint, neckPoint);

        float excessDistance = distance - stateMachine.Controller.Tie.desiredLength;

        if (excessDistance == 0) return;

        float pullStrength = excessDistance > 0 ? stateMachine.Abilities.tieGrabAbility.pullStrengthUp : stateMachine.Abilities.tieGrabAbility.pullStrengthDown;
        Vector2 direction = (grabPoint - neckPoint).normalized;
        stateMachine.Velocity += (excessDistance * pullStrength * Time.fixedDeltaTime) * direction;
    }

    protected void ApplyAirDrag(float dragCoefficient)
    {
        stateMachine.Velocity -= stateMachine.Velocity * dragCoefficient;
    }

    protected void ApplyHorizontalSpeed(float accelerationOverride = 0)
    {
        if (!stateMachine.Controller.Ground.OnGround && stateMachine.Controller.Tie.grabbed != null)
        {
            float velocity = stateMachine.Velocity.x + stateMachine.InputReader.MoveAxis * stateMachine.Abilities.tieGrabAbility.swingAcceleration * Time.fixedDeltaTime;
            float maxVelocity = stateMachine.Abilities.tieGrabAbility.maxSwingSpeed;
            if (velocity > maxVelocity) return;
            if (velocity < -1 * maxVelocity) return;

            stateMachine.Velocity.x = velocity;
        }
        else
        {
            float acceleration = accelerationOverride > 0 ? accelerationOverride : 
                stateMachine.Controller.Ground.OnGround ? stateMachine.MaxAcceleration : stateMachine.MaxAirAcceleration;
            float maxSpeedChange = acceleration * Time.fixedDeltaTime;
            stateMachine.Velocity.x = Mathf.MoveTowards(stateMachine.Velocity.x, desiredVelocity, maxSpeedChange);
        }
            
    }

    protected bool FlipIfNeeded()
    {
        bool shouldFlip = (desiredVelocity * stateMachine.Controller.Facing) < 0;
        if (shouldFlip)
        {
            stateMachine.Controller.Flip();
            stateMachine.Controller.Tie.TieController.Flip();
        }
        return shouldFlip;
    }

    protected void Move()
    {
        ApplyTiePull();
        stateMachine.Controller.Move(stateMachine.Velocity);
    }

    protected float GetJumpSpeed(float JumpHeight)
    {
        float jumpSpeed = Mathf.Sqrt(-2f * stateMachine.Gravity * JumpHeight);
        return jumpSpeed;
    }

    public void OnBounce(Vector2 direction, float bounceHeight, GameObject gameObject)
    {
        if (stateMachine.gameObject != gameObject) return;

        float bounceSpeed = Mathf.Sqrt(-2f * stateMachine.Gravity * bounceHeight);
        Vector2 bounceVelocity = direction * bounceSpeed;

        stateMachine.Velocity = bounceVelocity;
    }

    public void SwitchToJumpstartState()
    {
        if (stateMachine.Controller.Ground.OnGround)
            stateMachine.SwitchState(new PlayerJumpstartState(stateMachine));
    }

    public void SwitchToHatThrowState()
    {
        if (stateMachine.Abilities.hatThrowAbility.unlocked && stateMachine.hasHat)
            stateMachine.SwitchState(new PlayerHatThrowState(stateMachine));
    }

    public void SwitchToBowtieState()
    {
        if (!stateMachine.Abilities.bowtieDashAbility.unlocked) return;

        if (stateMachine.Controller.Ground.OnGround)
            stateMachine.SwitchState(new PlayerBowtieJumpState(stateMachine));
            // stateMachine.SwitchState(new PlayerBowtieDashState(stateMachine));

        else if (stateMachine.Abilities.bowtieDashAbility.timesBowtieJumped < stateMachine.Abilities.bowtieDashAbility.maxBowtieJumps)
            stateMachine.SwitchState(new PlayerBowtieJumpState(stateMachine));
    }

    public void SwitchToBowtieShieldState()
    {
        if (!stateMachine.Abilities.bowtieShieldAbility.unlocked) return;

        stateMachine.SwitchState(new PlayerBowtieShieldState(stateMachine));
    }

    public void TeleportToHat()
    {
        if (!stateMachine.Abilities.hatTeleportAbility.unlocked) return;
        if (stateMachine.hasHat) return;

        GameObject hat = stateMachine.Controller.Hat;
        HatController hatController = hat.GetComponent<HatController>();

        Vector3 hatPosition = hat.transform.position;
        Vector3 hatVelocity = hatController.rb.velocity;
        Vector3 playerPosition = stateMachine.transform.position;

        hat.transform.position = playerPosition;
        stateMachine.transform.position = hatPosition;
        stateMachine.Velocity = hatVelocity;

        if (stateMachine.Abilities.tieAttackAbility.unlocked)
            stateMachine.Controller.Tie.TieController.ResetTieLocation();

        hat.GetComponent<HatController>().Return();
    }
}