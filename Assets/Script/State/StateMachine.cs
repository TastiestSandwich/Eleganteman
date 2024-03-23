using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }
    public string stateName;

    public void SwitchState(State state)
    {
        State previousState = currentState;
        currentState?.Exit(state);
        currentState = state;
        currentState.Enter(previousState);
        stateName = currentState.GetType().Name;
    }

    private void Update()
    {
        currentState?.Tick();
    }

    private void FixedUpdate()
    {
        currentState?.FixedTick();
    }
}
