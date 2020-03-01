using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/OffsetOnLedge")]
public class OffsetOnLedge : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        //CharacterControl charControl = characterState.GetCharacterControl(animator);
        //if (charControl.ledgeCheckers[0].grabbedLedge == charControl.ledgeCheckers[1].grabbedLedge && charControl.ledgeCheckers[0].grabbedLedge != null)
        //{
        //    GameObject anim = charControl.gameObject;
        //    Transform originParent = anim.transform.parent;
        //    anim.transform.parent = charControl.ledgeCheckers[0].grabbedLedge.transform;
        //    anim.transform.localPosition = new Vector3(anim.transform.localPosition.x, charControl.ledgeCheckers[0].grabbedLedge.offset.y, charControl.ledgeCheckers[0].grabbedLedge.offset.z);
        //    anim.transform.parent = originParent;
        //    anim.transform.localRotation = charControl.ledgeCheckers[0].grabbedLedge.transform.rotation;
        //    charControl.RIGIDBODY.velocity = Vector3.zero;
        //}
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        if (charControl.ledgeCheckers[0].grabbedLedge == charControl.ledgeCheckers[1].grabbedLedge && charControl.ledgeCheckers[0].grabbedLedge != null)
        {
            GameObject anim = charControl.gameObject;
            Transform originParent = anim.transform.parent;
            anim.transform.parent = charControl.ledgeCheckers[0].grabbedLedge.transform;
            anim.transform.localPosition = new Vector3(anim.transform.localPosition.x, charControl.ledgeCheckers[0].grabbedLedge.offset.y, charControl.ledgeCheckers[0].grabbedLedge.offset.z);
            anim.transform.parent = originParent;
            anim.transform.localRotation = charControl.ledgeCheckers[0].grabbedLedge.transform.rotation;
            charControl.RIGIDBODY.velocity = Vector3.zero;
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
