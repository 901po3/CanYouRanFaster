using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/ForceTransition")]
public class ForceTransition : StateData
{
    [Range(0.01f, 1.0f)]
    public float transitionTiming;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if(stateInfo.normalizedTime >= transitionTiming)
        {
            animator.SetBool("forceTransition", true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("forceTransition", false);

    }
}
