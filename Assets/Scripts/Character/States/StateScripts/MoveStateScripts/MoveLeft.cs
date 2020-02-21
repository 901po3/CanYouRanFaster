using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/MoveLeft")]
public class MoveLeft : MovingStateData
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

        if (charControl.isMovingLeft && !CheckEdge(charControl.leftSpheres, -charControl.transform.right))
            charControl.transform.Translate(Vector3.left * curSpeed * Time.fixedDeltaTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
