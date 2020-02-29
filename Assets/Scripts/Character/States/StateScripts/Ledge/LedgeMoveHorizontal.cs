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
            animator.SetTrigger("LedgeMoveRestriced");
            return;
        }

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        LedgeMove(charControl, curSpeed);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    private void LedgeMove(CharacterControl charControl, float curSpeed)
    {
        Transform ledgeTrans = charControl.ledgeCheckers[0].grabbedLedge.transform;
        if (charControl.isMovingLeft)
        {
            Vector3 leftHandEdge = (-charControl.ledgeCheckers[0].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[0].transform) / 2) + charControl.ledgeCheckers[0].transform.position;
            Vector3 ledgeLeftEdge = ledgeTrans.position + (-ledgeTrans.right * getWorldScaleOfX(ledgeTrans) / 2);
            Debug.DrawRay(leftHandEdge, Vector3.up * 10, Color.yellow);
            Debug.DrawRay(ledgeLeftEdge, Vector3.up * 10, Color.yellow);
            if (Vector3.Distance(leftHandEdge, ledgeLeftEdge) > 0.2f)
            {
                charControl.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
            }
            else
            {
                charControl.GetComponent<Animator>().SetTrigger("LedgeMoveRestriced");
            }
        }
        else if(charControl.isMovingRight)
        {
            Vector3 rightHandEdge = (charControl.ledgeCheckers[1].transform.right * getWorldScaleOfX(charControl.ledgeCheckers[1].transform) / 2) + charControl.ledgeCheckers[1].transform.position;
            Vector3 ledgeRightEdge = ledgeTrans.position + (ledgeTrans.right * getWorldScaleOfX(ledgeTrans) / 2);
            Debug.DrawRay(rightHandEdge, Vector3.up * 10);
            Debug.DrawRay(ledgeRightEdge, Vector3.up * 10);
            if (Vector3.Distance(rightHandEdge, ledgeRightEdge) > 0.2f)
            {
                charControl.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
            }
            else
            {
                charControl.GetComponent<Animator>().SetTrigger("LedgeMoveRestriced");
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