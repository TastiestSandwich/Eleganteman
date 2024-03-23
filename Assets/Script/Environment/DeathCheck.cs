using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStateMachine player = collision.gameObject.GetComponent<PlayerStateMachine>();
        if (player == null) return;

        // Switch to DeathState or something, it will know how to revive
        player.transform.position = Vector3.zero;

        if (player.Abilities.tieAttackAbility.unlocked)
            player.Controller.Tie.TieController.ResetTieLocation();
    }
}
