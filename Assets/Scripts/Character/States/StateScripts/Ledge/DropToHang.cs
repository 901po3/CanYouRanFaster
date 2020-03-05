using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/DropToHang")]
public class DropToHang : StateData
{
    public bool isPlayerOn;
    Ledge ledge;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        if (charControl.bottomLedge != null)
        {
            charControl.isDroppingToHang = true;
            ledge = charControl.bottomLedge;
            GameObject anim = charControl.gameObject;
            Transform originParent = anim.transform.parent;
            anim.transform.parent = charControl.bottomLedge.transform;
            anim.transform.localPosition = new Vector3(anim.transform.localPosition.x + charControl.bottomLedge.DropToHangOffset.x, charControl.bottomLedge.DropToHangOffset.y, charControl.bottomLedge.DropToHangOffset.z);
            anim.transform.localRotation = Quaternion.Euler(0, 180, 0);
            anim.transform.parent = originParent;
            charControl.transform.localScale = new Vector3(1, 1, 1);
            charControl.RIGIDBODY.velocity = Vector3.zero;
            charControl.RIGIDBODY.useGravity = false;
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        charControl.ledgeCheckers[0].grabbedLedge = ledge;
        charControl.ledgeCheckers[1].grabbedLedge = ledge;
        charControl.ledgeCheckers[0].isGrabbingLedge = true;
        charControl.ledgeCheckers[1].isGrabbingLedge = true;
        charControl.transform.localScale = new Vector3(1, 1, 1);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        charControl.isDroppingToHang = false;
    }
}
