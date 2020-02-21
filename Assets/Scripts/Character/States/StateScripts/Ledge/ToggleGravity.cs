using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/ToggleGravity")]
public class ToggleGravity : StateData
{
    public bool on;
    public bool onStart;
    public bool onEnd;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if(onStart)
        {
            CharacterControl charControl = characterState.GetCharacterControl(animator);
            ToggleGrav(charControl);
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (onEnd)
        {
            CharacterControl charControl = characterState.GetCharacterControl(animator);
            ToggleGrav(charControl);
        }
    }

    private void ToggleGrav(CharacterControl control)
    {
        control.RIGIDBODY.velocity = Vector3.zero;
        control.RIGIDBODY.useGravity = on;
    }
}