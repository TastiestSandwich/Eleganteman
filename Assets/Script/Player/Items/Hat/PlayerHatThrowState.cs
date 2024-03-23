using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHatThrowState : PlayerState
{
    private readonly int HatThrowHash = Animator.StringToHash("hat_throw");
    private readonly int HatHoldHash = Animator.StringToHash("hat_hold");
    private readonly int HatReleaseHash = Animator.StringToHash("hat_release");

    private bool bufferedJump = false;
    private bool isShortJump = false;
    private bool isHolding = false;
    private bool isMegaThrow = false;
    private bool wasMoving = false;

    private Vector2 direction;
    private Vector2 defaultDirection;
    private float arrowAngleOffset;

    public PlayerHatThrowState(PlayerStateMachine stateMachine) : base(stateMachine) 
    {
    }

    public override void Enter(State previousState)
    {
        wasMoving = SetDesiredVelocity() != 0;

        stateMachine.Animator.Play(HatThrowHash);
        defaultDirection = Vector2.right * stateMachine.Controller.Facing;
        direction = defaultDirection;

        if (stateMachine.InputReader.isEleganceMod) 
            SetMegaThrow();

        if (stateMachine.Abilities.directionalHatThrowAbility.unlocked)
        {
            stateMachine.Controller.Arrow.SetActive(true);
            arrowAngleOffset = stateMachine.Controller.Arrow.transform.eulerAngles.z;
        }

        stateMachine.InputReader.OnHatThrowRelease += EndCharge;
        stateMachine.InputReader.OnEleganceModHold += SetMegaThrow;

        stateMachine.AnimationListener.OnHatHoldCharge += HoldHat;
        stateMachine.AnimationListener.OnHatThrow += ThrowHat;
        stateMachine.AnimationListener.OnHatThrowEnd += ExitThrowHat;

        stateMachine.InputReader.OnJumpStarted += BufferJump;
        Bounce.OnHatBounce += OnBounce;
    }

    public override void Exit(State nextState)
    {
        if (stateMachine.Abilities.directionalHatThrowAbility.unlocked)
        {
            stateMachine.Controller.Arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, arrowAngleOffset));
            stateMachine.Controller.Arrow.SetActive(false);
        }

        stateMachine.InputReader.OnHatThrowRelease -= EndCharge;
        stateMachine.InputReader.OnEleganceModHold -= SetMegaThrow;

        stateMachine.AnimationListener.OnHatHoldCharge -= HoldHat;
        stateMachine.AnimationListener.OnHatThrow -= ThrowHat;
        stateMachine.AnimationListener.OnHatThrowEnd -= ExitThrowHat;

        stateMachine.InputReader.OnJumpStarted -= BufferJump;
        stateMachine.InputReader.OnJumpCanceled -= SetShortJump;
        stateMachine.InputReader.OnJumpStarted -= SwitchToJumpstartState;
        Bounce.OnHatBounce -= OnBounce;
    }

    public override void FixedTick()
    {
        ApplyGravity(stateMachine.Abilities.hatThrowAbility.maxFallSpeed);
        float drag = stateMachine.AirDrag;

        if (!stateMachine.Controller.Ground.OnGround || !isHolding || desiredVelocity == 0)
            ApplyHorizontalSpeed();
        else
            drag += stateMachine.Abilities.hatThrowAbility.HatThrowDrag;

        ApplyAirDrag(drag);
        Move();
    }

    public override void Tick()
    {
        // this if is very jincho lmao
        if (!stateMachine.Controller.Ground.OnGround || (!isHolding && wasMoving))
            SetDesiredVelocity(stateMachine.Abilities.hatThrowAbility.HatThrowFriction);

        if (stateMachine.Abilities.directionalHatThrowAbility.unlocked)
        {
            SetThrowDirection();

            float angle = (arrowAngleOffset * stateMachine.Controller.Facing) + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = stateMachine.Controller.Arrow.transform.rotation;
            stateMachine.Controller.Arrow.transform.rotation = Quaternion.RotateTowards(
                rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.fixedDeltaTime * 1000);
        }
    }

    private void ThrowHat()
    {
        if (stateMachine.InputReader.isEleganceMod && stateMachine.Abilities.hatMegaThrowAbility.unlocked)
            isMegaThrow = true;

        //TODO add mega throw stuff to hat
        stateMachine.Controller.Hat.GetComponent<HatController>().Throw(stateMachine, direction, isMegaThrow);
        isHolding = false;

        // recoil in opposite direction if megathrow
        if (isMegaThrow)
            stateMachine.Velocity = -1 * stateMachine.Abilities.hatMegaThrowAbility.hatThrowRecoilSpeed * direction;
    }

    private void BufferJump()
    {
        this.bufferedJump = true;
        stateMachine.InputReader.OnJumpCanceled += SetShortJump;
    }

    private void SetShortJump()
    {
        this.isShortJump = true;
    }

    private void SetThrowDirection()
    {
        // update direction with clampDirection only if it is not center
        Vector2 throwDirection = stateMachine.InputReader.GetClampedFacingDirection(stateMachine.Controller.Facing);
        throwDirection.y *= stateMachine.Abilities.directionalHatThrowAbility.hatThrowVerticalPercentage;
        throwDirection.Normalize();

        if (throwDirection.magnitude > 0)
            this.direction = throwDirection;
    }

    private void ExitThrowHat()
    {
        float desiredVelocity = SetDesiredVelocity();

        if (!stateMachine.Controller.Ground.OnGround)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        else if (bufferedJump)
        {
            if (isShortJump)
                stateMachine.SwitchState(new PlayerJumpState(stateMachine, true));
            else
                stateMachine.SwitchState(new PlayerJumpstartState(stateMachine));
        }
        else if (desiredVelocity == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
        else
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }

    private void EndCharge()
    {
        stateMachine.Animator.Play(HatReleaseHash);
    }
    private void HoldHat()
    {
        stateMachine.Animator.Play(HatHoldHash);
        stateMachine.InputReader.OnJumpStarted -= BufferJump;
        stateMachine.InputReader.OnJumpStarted += SwitchToJumpstartState;

        isHolding = true;

        if (bufferedJump)
            ExitThrowHat();
    }

    private void SetMegaThrow()
    {
        if (!stateMachine.Abilities.hatMegaThrowAbility.unlocked) return;
        this.isMegaThrow = true;
    }
}
