using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/LedgeMoveHorizontal")]
public class LedgeMoveHorizontal : MovingStateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

        if (!charControl.isMoving)
        {
            animator.SetBool("isLedgeHorizontalMove", false);
            return;
        }

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        LedgeMove(charControl, animator, curSpeed);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    private void LedgeMove(CharacterControl charControl, Animator animator, float curSpeed)
    {
        Transform ledgeTrans = charControl.ledgeCheckers[0].grabbedLedge.transform;
        if (charControl.isMovingLeft)
        {
            Vector3 leftHandEdge = (-charControl.ledgeCheckers[0].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[0].transform) / 2) + charControl.ledgeCheckers[0].transform.position;
            Vector3 ledgeLeftEdge = charControl.ledgeCheckers[0].grabbedLedge.ledgeLeftEdge;
            Debug.DrawRay(leftHandEdge, Vector3.up * 10, Color.yellow);
            Debug.DrawRay(ledgeLeftEdge, Vector3.up * 10, Color.yellow);
            if (Vector3.Distance(leftHandEdge, ledgeLeftEdge) > 0.25f)
            {
                charControl.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isLedgeHorizontalMove", false);
            }
        }
        else if(charControl.isMovingRight)
        {
            Vector3 rightHandEdge = (charControl.ledgeCheckers[1].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[1].transform) / 2) + charControl.ledgeCheckers[1].transform.position;
            Vector3 ledgeRightEdge = charControl.ledgeCheckers[0].grabbedLedge.ledgeRightEdge;
            Debug.DrawRay(rightHandEdge, Vector3.up * 10);
            Debug.DrawRay(ledgeRightEdge, Vector3.up * 10);
            rightHandEdge += charControl.transform.right * curSpeed * Time.deltaTime;
            if (Vector3.Distance(rightHandEdge, ledgeRightEdge) > 0.25f)
            {
                charControl.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isLedgeHorizontalMove", false);
            }
        }
    }

    private float getWorldScaleOfX(Transform trans)
    {
        float x = trans.localScale.x;
        Transform parentTrans = trans;
        while(true)
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