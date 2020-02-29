using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/TeleportOnLedge")]
public class TeleportOnLedge : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        Vector3 endPosition = (charControl.ledgeCheckers[0].transform.position + charControl.ledgeCheckers[1].transform.position)/2 
            + charControl.ledgeCheckers[0].grabbedLedge.endPosition;
        charControl.transform.position = endPosition;
        charControl.transform.position += charControl.transform.forward * 0.3f;
    }
}
