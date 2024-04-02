using UnityEngine;

public abstract class ChimneyState : EnemyState
{
    protected readonly ChimneyStateMachine chimney;

    protected ChimneyState(ChimneyStateMachine stateMachine) : base(stateMachine)
    {
        this.chimney = stateMachine;
    }

    public void SwitchToIdleState()
    {
        stateMachine.SwitchState(new ChimneyIdleState(chimney));
    }
}