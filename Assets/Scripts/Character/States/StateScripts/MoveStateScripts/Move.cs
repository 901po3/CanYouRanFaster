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

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        if (useMomentum)
        {
            if (charControl.isMovingForward && !CheckEdge(charControl, charControl.frontSpheres, charControl.transform.forward))
            {
                charControl.airMomentum.z += speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
                charControl.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
            }
            else if (charControl.isMovingBackward && !CheckEdge(charControl, charControl.backSpheres, -charControl.transform.forward))
            {
                charControl.airMomentum.z -= speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
            }
            if (charControl.isMovingRight && !CheckEdge(charControl, charControl.rightSpheres, charControl.transform.right))
            {
                charControl.airMomentum.x += speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
            }
            else if (charControl.isMovingLeft && !CheckEdge(charControl, charControl.leftSpheres, -charControl.transform.right))
            {
                charControl.airMomentum.x -= speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime;
            }
            charControl.airMomentum.x = Mathf.Clamp(charControl.airMomentum.x, -maxMometum, maxMometum);
            charControl.airMomentum.z = Mathf.Clamp(charControl.airMomentum.z, -maxMometum, maxMometum);
            //apply speed
        }
        else
        {

            if (charControl.isMovingForward && !CheckEdge(charControl, charControl.frontSpheres, charControl.transform.forward))
                charControl.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
            else if (charControl.isMovingBackward && !CheckEdge(charControl, charControl.backSpheres, -charControl.transform.forward))
                charControl.transform.Translate(Vector3.back * curSpeed * Time.deltaTime);
            if (charControl.isMovingRight && !CheckEdge(charControl, charControl.rightSpheres, charControl.transform.right))
                charControl.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
            else if (charControl.isMovingLeft && !CheckEdge(charControl, charControl.leftSpheres, -charControl.transform.right))
                charControl.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
