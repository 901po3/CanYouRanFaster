using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/ToggleBoxCollider")]
public class ToggleBoxCollider : StateData
{
    public bool on;
    public bool onStart;
    public bool onEnd;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (onStart)
        {
            CharacterControl charControl = characterState.GetCharacterControl(animator);
            ToggleBocCol(charControl);
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
            ToggleBocCol(charControl);
        }
    }

    private void ToggleBocCol(CharacterControl control)
    {
        control.GetComponent<BoxCollider>().enabled = on;
    }
}