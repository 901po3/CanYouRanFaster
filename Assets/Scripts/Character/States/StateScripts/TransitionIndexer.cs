using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/TransitionIndexer")]
public class TransitionIndexer : StateData
{
    public enum TransitionConditionType
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        JUMP,
        GRABBING_LEDGE
    }

    public int index;
    public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        if(MakeTransition(charControl))
        {
            animator.SetInteger("transitionIndex", index);
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        if (MakeTransition(charControl))
        {
            animator.SetInteger("transitionIndex", index);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetInteger("transitionIndex", 0);
    }

    private bool MakeTransition(CharacterControl control)
    {
        foreach(TransitionConditionType tc in transitionConditions)
        {
            switch(tc)
            {
                case TransitionConditionType.UP:
                    if(!control.isMovingForward)
                    {
                        return false;
                    }
                    break;
                case TransitionConditionType.DOWN:
                    if (!control.isMovingBackward)
                    {
                        return false;
                    }
                    break;
                case TransitionConditionType.LEFT:
                    if (!control.isMovingLeft)
                    {
                        return false;
                    }
                    break;
                case TransitionConditionType.RIGHT:
                    if (!control.isMovingRight)
                    {
                        return false;
                    }
                    break;
                case TransitionConditionType.JUMP:
                    if (!control.isJumping)
                    {
                        return false;
                    }
                    break;
                case TransitionConditionType.GRABBING_LEDGE:
                    if(!control.ledgeCheckers[0].isGrabbingLedge || !control.ledgeCheckers[1].isGrabbingLedge ||
                        control.ledgeCheckers[0].grabbedLedge != control.ledgeCheckers[1].grabbedLedge)
                    {
                        return false;
                    }
                    break;
            }
        }
        return true;
    }
}
