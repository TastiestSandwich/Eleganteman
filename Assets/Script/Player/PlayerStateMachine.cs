using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerStateMachine : StateMachine
{
    public Vector2 Velocity;

    public float MaxSpeed = 25f;
    public float MaxAcceleration = 90f;
    public float MaxAirAcceleration = 70f;

    public float ShortJumpHeight = 10f;
    public float JumpHeight = 20f;
    public float Gravity = -100f;

    public float MaxFallSpeed = -40f;
    public float LongLandSpeedThreshold = -30f;
    public float AirDrag = 0.04f;

    public float JumpStartFriction = 10;
    public float LandFriction = 10;

    public float MomentumLossThreshold = 0.1f;

    public bool hasHat = true;

    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public SpriteLibrary SpriteLibrary { get; private set; }
    public PlayerController Controller { get; private set; }
    public PlayerAnimationEventListener AnimationListener { get; private set; }

    public PlayerAbilities Abilities;

    private void Start()
    {
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        SpriteLibrary = GetComponent<SpriteLibrary>();
        Controller = GetComponent<PlayerController>();
        AnimationListener = GetComponent<PlayerAnimationEventListener>();

        //TODO decide when health gets topped
        GainHealth(Abilities.maxHealth);
        SwitchState(new PlayerMoveState(this));
    }

    public void GainHealth(int gain)
    {
        Debug.Log("Gaining health " + gain);
        int currentHealth = Abilities.health;
        currentHealth += gain;

        if (currentHealth > Abilities.maxHealth)
        {
            currentHealth = Abilities.maxHealth;
        } 
        else if (currentHealth < 0)
        {
            currentHealth = 0;
            //TODO game over
        }

        Abilities.health = currentHealth;
        Controller.Tie.TieController.ChangeHealthIndicator(currentHealth, Abilities.maxHealth);
    }
}
