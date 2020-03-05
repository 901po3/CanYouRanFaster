using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/Move")]
public class Move : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

        if (charControl.isJumping)
        {
            animator.SetBool("isJumping", true);
        }

        if (!charControl.isMoving)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        if(charControl.ledgeCheckers[0] != null)
        {
            charControl.ledgeCheckers[0].grabbedLedge = null;
            charControl.ledgeCheckers[0].isGrabbingLedge = false;
        }
        if (charControl.ledgeCheckers[1] != null)
        {
            charControl.ledgeCheckers[1].grabbedLedge = null;
            charControl.ledgeCheckers[1].isGrabbingLedge = false;
        }

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);
        charControl.velocity = Vector3.zero;

        if (charControl.isMovingForward && !CheckEdge(charControl, charControl.frontSpheres, charControl.transform.forward))
        {
            charControl.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
            charControl.velocity.z = curSpeed;
        }
        else if (charControl.isMovingBackward && !CheckEdge(charControl, charControl.backSpheres, -charControl.transform.forward))
        {
            charControl.transform.Translate(Vector3.back * curSpeed * Time.deltaTime);
            charControl.velocity.z = -curSpeed;
        }
        if (charControl.isMovingRight && !CheckEdge(charControl, charControl.rightSpheres, charControl.transform.right))
        {
            charControl.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
            charControl.velocity.x = curSpeed;
        }
        else if (charControl.isMovingLeft && !CheckEdge(charControl, charControl.leftSpheres, -charControl.transform.right))
        {
            charControl.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
            charControl.velocity.x = -curSpeed;
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.GetCharacterControl(animator).airMomentum = Vector3.zero;
    }
}
