using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieAttackState : TieState
{
    private TieAttackAnimation animation;
    
    // direction, slideHeight
    public static event System.Action<Vector2, float> OnAttackSlide;
    public static event System.Action OnMomentumStop;
    Vector2 direction;
    public TieAttackState(TieStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(State previousState)
    {
        direction = GetAttackDirection();

        animation = stateMachine.TieController.TieAnimator.tieAttackAnimation;
        animation.SetDirection(direction);
        stateMachine.TieController.TieAnimator.SetAnimation(animation);

        animation.OnAnimationEnd += FinishAttack;
        stateMachine.InputReader.OnEleganceModHold += SwitchToGrabState;
    }

    public override void Exit(State nextState)
    {
        animation.OnAnimationEnd -= FinishAttack;
        stateMachine.InputReader.OnEleganceModHold -= SwitchToGrabState;
    }

    public override void FixedTick()
    {
        // todo
    }

    public override void Tick()
    {
        // todo
    }

    private void FinishAttack()
    {
        CheckAttackHitbox(stateMachine.PlayerAbilities.tieAttackAbility.attackableLayer);
        OnAttackSlide?.Invoke(direction, stateMachine.PlayerAbilities.tieAttackAbility.slideDistance);

        stateMachine.SwitchState(new TieIdleState(stateMachine));
    }

    private void CheckAttackHitbox(LayerMask layer)
    {
        Vector2 tipPosition = stateMachine.TieController.GetTipPosition();
        Vector2 basePositiion = stateMachine.TieController.ropeSegments[0].posNow;
        Vector2 tieVector = (tipPosition - basePositiion);

        Vector2 hitboxCenter = basePositiion + (tieVector * stateMachine.PlayerAbilities.tieAttackAbility.tipPercentage);
        Vector2 hitboxSize = new Vector2(stateMachine.PlayerAbilities.tieAttackAbility.hitboxLengthPercentage * tieVector.magnitude, 
            stateMachine.PlayerAbilities.tieAttackAbility.hitboxWidth);
        Collider2D[] colliders = Physics2D.OverlapCapsuleAll(hitboxCenter, hitboxSize, CapsuleDirection2D.Horizontal, Vector2.Angle(Vector2.right, tieVector), layer);

        stateMachine.SetGizmoBox(hitboxCenter, hitboxSize);
        HitAllTargets(colliders, tieVector.normalized);
    }

    private void HitAllTargets(Collider2D[] colliders, Vector2 direction)
    {
        foreach(Collider2D collider in colliders)
        {
            stateMachine.PlayerAbilities.tieAttackAbility.attack.OnAttackHit(direction, collider.gameObject);
        }
    }
}
