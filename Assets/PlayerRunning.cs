using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : CharacterStateBase
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
        if (playerCS.playerAxis == Vector2.zero)
        {
            playerCS.anim.SetBool("isRunning", false);
            return;
        }

        Vector3 dir = (playerCS.transform.position - 
           new Vector3(playerCS.camera.transform.position.x, 
           playerCS.transform.position.y, 
           playerCS.camera.transform.position.z)).normalized;
        Quaternion qut = Quaternion.LookRotation(dir);
        playerCS.transform.rotation 
           = Quaternion.Slerp(playerCS.transform.rotation, qut, playerCS.rotSpeed * Time.fixedDeltaTime);

        playerCS.anim.SetFloat("velX", Input.GetAxis("Horizontal"));
        playerCS.anim.SetFloat("velZ", Input.GetAxis("Vertical"));
        playerCS.transform.Translate((Vector3.forward * playerCS.playerAxis.y
            + Vector3.right * playerCS.playerAxis.x) * playerCS.runningSpeed * Time.fixedDeltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCS = null;
    }
}
