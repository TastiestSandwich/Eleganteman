using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TieState : State
{
    protected readonly TieStateMachine stateMachine;
    public bool isGrabModifierPressed;

    protected TieState(TieStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void SwitchToMoveState()
    {
        stateMachine.SwitchState(new TieMoveState(stateMachine));
    }

    public void SwitchToAttackState()
    {
        if (!stateMachine.PlayerAbilities.tieAttackAbility.unlocked) return;

        stateMachine.SwitchState(new TieAttackState(stateMachine));
    }

    public void SwitchToPrepareGrabState()
    {
        if (!stateMachine.PlayerAbilities.tieGrabAbility.unlocked) return;

        stateMachine.SwitchState(new TiePrepareGrabState(stateMachine));
    }

    public Vector2 GetAttackDirection()
    {
        Vector2 throwDirection = stateMachine.InputReader.GetClampedDirection();

        if (throwDirection.magnitude > 0)
            return throwDirection;
        else
            return Vector2.right * stateMachine.TieController.Facing;
    }

    public void SwitchToGrabState()
    {
        stateMachine.SwitchState(new TieGrabState(stateMachine));
    }
}
