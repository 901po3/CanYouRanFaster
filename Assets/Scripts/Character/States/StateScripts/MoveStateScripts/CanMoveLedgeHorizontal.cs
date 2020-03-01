using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/CanMoveLedgeHorizontal")]
public class CanMoveLedgeHorizontal : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);
        if (charControl.ledgeCheckers[0].grabbedLedge == null || charControl.ledgeCheckers[1].grabbedLedge == null)
        {
            animator.SetTrigger("manualFall");
            return;
        }

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        animator.SetBool("isLedgeHorizontalMove",CanLedgeMove(charControl, curSpeed));
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    private bool CanLedgeMove(CharacterControl charControl, float curSpeed)
    {
        Transform ledgeTrans = charControl.ledgeCheckers[0].grabbedLedge.transform;
        if (charControl.isMovingLeft)
        {
            Vector3 leftHandEdge = (-charControl.ledgeCheckers[0].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[0].transform) / 2) + charControl.ledgeCheckers[0].transform.position;
            leftHandEdge += -charControl.transform.right * curSpeed * Time.deltaTime;
            if (Vector3.Distance(leftHandEdge, charControl.ledgeCheckers[0].grabbedLedge.ledgeLeftEdge) > 0.275f)
            {
                return true;
            }
        }
        else if (charControl.isMovingRight)
        {
            Vector3 rightHandEdge = (charControl.ledgeCheckers[1].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[1].transform) / 2) + charControl.ledgeCheckers[1].transform.position;
            rightHandEdge += charControl.transform.right * curSpeed * Time.deltaTime;
            if (Vector3.Distance(rightHandEdge, charControl.ledgeCheckers[0].grabbedLedge.ledgeRightEdge) > 0.275f)
            {
                return true;
            }
        }
        return false;
    }

    public float getWorldScaleOfX(Transform trans)
    {
        float x = trans.localScale.x;
        Transform parentTrans = trans;
        while (true)
        {
            if (parentTrans.parent != null)
            {
                x *= trans.parent.localScale.x;
                parentTrans = parentTrans.parent;
            }
            else
            {
                break;
            }
        }
        return x;
    }
}