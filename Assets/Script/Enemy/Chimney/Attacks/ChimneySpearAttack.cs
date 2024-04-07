using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneySpearAttack : Attack
{
    public float pushBack = 5f;
    public int damage = 10;
    public override void OnAttackHit(Vector2 direction, GameObject hit)
    {
        base.OnAttackHit(direction, hit);
        Debug.Log("Spear Attack");

        PlayerStateMachine player = hit.GetComponent<PlayerStateMachine>();
        if (player == null)
        {
            Debug.Log("No player in hurtbox!");
            return;
        }

        SetPushVelocity(direction, player);
        player.GainHealth(-1 * damage);
        player.SwitchState(new PlayerHurtState(player));
    }

    public void SetPushVelocity(Vector2 direction, PlayerStateMachine stateMachine)
    {
        float bounceSpeed = Mathf.Sqrt(-2f * stateMachine.Gravity * pushBack);
        Vector2 bounceVelocity = direction * bounceSpeed;

        stateMachine.Velocity = bounceVelocity;
    }
}
