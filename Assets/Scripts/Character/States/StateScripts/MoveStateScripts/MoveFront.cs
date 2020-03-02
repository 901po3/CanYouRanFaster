﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/MoveFront")]
public class MoveFront : MovingStateData
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
        charControl.velocity = Vector3.zero;

        if (charControl.isMovingForward && !CheckEdge(charControl, charControl.frontSpheres, charControl.transform.forward))
        {
            charControl.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
            charControl.velocity.z = curSpeed;
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
