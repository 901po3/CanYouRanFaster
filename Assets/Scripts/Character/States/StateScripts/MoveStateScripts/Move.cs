using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/Move")]
public class Move : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if(charControl.isJumping)
        {
            animator.SetBool("isJumping", true);
            return;
        }

        if (!charControl.isMoving)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        RoateToCamFacingDir();
        float curSpeed = CalculateSpeed(stateInfo);

        if (charControl.isMovingForward && !CheckEdge(charControl.frontSpheres, charControl.transform.forward))
            charControl.transform.Translate(Vector3.forward * curSpeed * Time.fixedDeltaTime);           
        else if(charControl.isMovingBackward && !CheckEdge(charControl.backSpheres, -charControl.transform.forward))
            charControl.transform.Translate(Vector3.back * curSpeed * Time.fixedDeltaTime);
        if(charControl.isMovingRight && !CheckEdge(charControl.rightSpheres, charControl.transform.right))
            charControl.transform.Translate(Vector3.right * curSpeed * Time.fixedDeltaTime);
        else if(charControl.isMovingLeft && !CheckEdge(charControl.leftSpheres, -charControl.transform.right))
            charControl.transform.Translate(Vector3.left * curSpeed * Time.fixedDeltaTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = null;
    }
}
