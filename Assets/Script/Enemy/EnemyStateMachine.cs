using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyController))]
public abstract class EnemyStateMachine : StateMachine
{
    // SOMETHING COMMON TO ALL ENEMIES?
    public Vector2 Velocity;

    public float MaxSpeed;
    public float MaxAcceleration;
    public float MaxAirAcceleration;

    public float ShortJumpHeight;
    public float JumpHeight;
    public float Gravity;

    public float MaxFallSpeed;
    public float LongLandSpeedThreshold;
    public float AirDrag;

    public float JumpStartFriction;
    public float LandFriction;

    public Animator Animator { get; private set; }
    public EnemyController Controller { get; private set; }
    public EnemyAnimationEventListener AnimationListener { get; private set; }

    public PlayerController Player { get; private set; }

    public virtual void Start()
    {
        Animator = GetComponent<Animator>();
        Controller = GetComponent<EnemyController>();
        AnimationListener = GetComponent<EnemyAnimationEventListener>();
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
}
