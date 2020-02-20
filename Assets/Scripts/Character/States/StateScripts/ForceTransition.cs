using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/ForceTransition")]
public class ForceTransition : StateData
{
    [Range(0.01f, 1f)]
    public float transitionTiming;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
        anim = charControl.GetComponent<Animator>();
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if(stateInfo.normalizedTime >= transitionTiming)
        {
            anim.SetBool("forceTransition", true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        anim.SetBool("forceTransition", false);
        charControl = null;
        anim = null;
    }
}
