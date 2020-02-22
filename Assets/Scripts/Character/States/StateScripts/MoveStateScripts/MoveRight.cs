using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/MoveRight")]
public class MoveRight : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

        if (!charControl.isMoving)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        if (charControl.isMovingRight && !CheckEdge(charControl, charControl.rightSpheres, charControl.transform.right))
            charControl.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
