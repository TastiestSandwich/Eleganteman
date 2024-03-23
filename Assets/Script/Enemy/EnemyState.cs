using UnityEngine;

public abstract class EnemyState : State
{
    protected readonly EnemyStateMachine stateMachine;
    protected float desiredVelocity;

    protected EnemyState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected float SetDesiredVelocity(float moveAxis, float stateFriction = 0)
    {
        this.desiredVelocity = moveAxis * Mathf.Max(stateMachine.MaxSpeed - stateMachine.Controller.Ground.Friction - stateFriction, 0f);
        return desiredVelocity;
    }

    protected void ApplyGravity(float maxFallSpeed)
    {
        if (stateMachine.Velocity.y > maxFallSpeed)
            stateMachine.Velocity.y += stateMachine.Gravity * Time.fixedDeltaTime;

        else if (stateMachine.Velocity.y < maxFallSpeed)
            stateMachine.Velocity.y = maxFallSpeed;
    }

    protected void ApplyAirDrag(float dragCoefficient)
    {
        stateMachine.Velocity -= stateMachine.Velocity * dragCoefficient;
    }

    protected void ApplyHorizontalSpeed(float accelerationOverride = 0)
    {
        float acceleration = accelerationOverride > 0 ? accelerationOverride : 
            stateMachine.Controller.Ground.OnGround ? stateMachine.MaxAcceleration : stateMachine.MaxAirAcceleration;
        float maxSpeedChange = acceleration * Time.fixedDeltaTime;
        stateMachine.Velocity.x = Mathf.MoveTowards(stateMachine.Velocity.x, desiredVelocity, maxSpeedChange);
            
    }

    protected bool FlipIfNeeded()
    {
        bool shouldFlip = (desiredVelocity * stateMachine.Controller.Facing) < 0;
        if (shouldFlip)
        {
            stateMachine.Controller.Flip();
        }
        return shouldFlip;
    }

    protected void Move()
    {
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

    public Vector2 GetDirectionToPlayer()
    {
        return stateMachine.Player.transform.position - stateMachine.transform.position;
    }

    public float GetDistanceToPlayer()
    {
        return GetDirectionToPlayer().magnitude;
    }

    public float GetHorizontalInputTowardsPlayer()
    {
        float x = GetDirectionToPlayer().x;
        if (x > 0) return 1;
        else if (x < 0) return -1;
        else return 0;
    }
}