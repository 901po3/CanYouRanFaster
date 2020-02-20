using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : CharacterStateBase
{
    CharacterMovement playerCS;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCS = GetCharacterMovement(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerCS.playerAxis != Vector2.zero)
        {
            playerCS.anim.SetBool("isRunning", true);
            return;
        }
        else
        {
            playerCS.anim.SetFloat("velX", 0);
            playerCS.anim.SetFloat("velZ", 0);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCS = null;
    }
}
