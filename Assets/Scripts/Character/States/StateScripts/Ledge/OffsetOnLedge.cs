using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/OffsetOnLedge")]
public class OffsetOnLedge : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        GameObject anim = charControl.gameObject;
        Transform originParent = anim.transform.parent;
        anim.transform.parent = charControl.ledgeChecker.grabbedLedge.transform;
        Debug.Log(charControl.ledgeChecker.grabbedLedge.offset);
        anim.transform.localPosition = charControl.ledgeChecker.grabbedLedge.offset;
        anim.transform.parent = originParent;
        anim.transform.localRotation = charControl.ledgeChecker.grabbedLedge.transform.rotation;
        charControl.RIGIDBODY.velocity = Vector3.zero;

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
