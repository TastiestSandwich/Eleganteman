using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TieAttack : Attack
{
    public float pushBack = 5f;
    public int damage = 10;
    public override void OnAttackHit(Vector2 direction, GameObject hit)
    {
        base.OnAttackHit(direction, hit);
        Debug.Log("Tie Attack");

        EnemyStateMachine enemy = hit.GetComponent<EnemyStateMachine>();
        if (enemy == null)
        {
            Debug.Log("No enemy in hurtbox!");
            return;
        }

        SetPushVelocity(direction, enemy);
        // enemy.GainHealth(-1 * damage);
        enemy.SwitchToHurtState();
    }

    public void SetPushVelocity(Vector2 direction, EnemyStateMachine stateMachine)
    {
        float bounceSpeed = Mathf.Sqrt(-2f * stateMachine.Gravity * pushBack);
        Vector2 bounceVelocity = direction * bounceSpeed;

        stateMachine.Velocity = bounceVelocity;
    }
}
