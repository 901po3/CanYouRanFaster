﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/MoveFront")]
public class MoveFront : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (!charControl.isMoving)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        RoateToCamFacingDir();
        float curSpeed = CalculateSpeed(stateInfo);

        if (charControl.isMovingForward && !CheckEdge(charControl.frontSpheres, charControl.transform.forward))
            charControl.transform.Translate(Vector3.forward * curSpeed * Time.fixedDeltaTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = null;
    }
}