using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCheck : MonoBehaviour
{
    public Transform tieFocus;
    public Interaction interaction;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enter Interaction");
        if (!isPlayer(collider)) return;

        PlayerStateMachine player = collider.transform.root.gameObject.GetComponent<PlayerStateMachine>();
        TieStateMachine tie = player.Controller.Tie;
        if (shouldTieInteract(tie))
        {
            tie.SwitchState(new TieInteractState(tie, tieFocus));
        }

        //TODO do something with the specific interaction
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Exit Interaction");
        if (!isPlayer(collider)) return;

        PlayerStateMachine player = collider.transform.root.gameObject.GetComponent<PlayerStateMachine>();
        TieStateMachine tie = player.Controller.Tie;
        tie.SwitchState(new TieIdleState(tie));
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!isPlayer(collider)) return;

        PlayerStateMachine player = collider.transform.root.gameObject.GetComponent<PlayerStateMachine>();
        TieStateMachine tie = player.Controller.Tie;
        if(shouldTieInteract(tie))
        {
            tie.SwitchState(new TieInteractState(tie, tieFocus));
        }
    }

    private bool isPlayer(Collider2D collider)
    {
        return collider.transform.root.gameObject.CompareTag("Player");
    }

    private bool shouldTieInteract(TieStateMachine tie)
    {
        return (tie.currentState is TieIdleState || tie.currentState is TieMoveState);
    }
}
