using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter(State previousState);
    public abstract void Tick();
    public abstract void FixedTick();
    public abstract void Exit(State nextState);
}
