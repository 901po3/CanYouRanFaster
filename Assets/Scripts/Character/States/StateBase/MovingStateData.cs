using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStateData : StateData
{
    public AnimationCurve speedGraph;
    public float speed;
    public float rotSpeed;
    public float blockDistance;
    private bool self;

    [Header("Momentum")]
    public bool useMomentum = false;
    public float maxMometum = 0.0f;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) 
    {
       characterState.GetCharacterControl(animator).airMomentum = Vector3.zero;
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) { }
    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) 
    {
        characterState.GetCharacterControl(animator).airMomentum = Vector3.zero;
    }

    protected float CalculateSpeed(CharacterControl charControl, AnimatorStateInfo stateInfo)
    {

        float curSpeed = speed;
        bool movingV = false;
        bool movingH = false;
        if (charControl.isMovingForward || charControl.isMovingBackward)
            movingV = true;
        if (charControl.isMovingRight || charControl.isMovingLeft)
            movingH = true;
        if (movingV && movingH)
            curSpeed = curSpeed * Mathf.Sin(45) * speedGraph.Evaluate(stateInfo.normalizedTime);

        return curSpeed;
    }

    protected void RoateToCamFacingDir(CharacterControl charControl)
    {
        if (charControl.ledgeCheckers[0].isGrabbingLedge || charControl.ledgeCheckers[1].isGrabbingLedge) return;
        Vector3 dir = (charControl.transform.position -
            new Vector3(charControl.camera.transform.position.x, charControl.transform.position.y, charControl.camera.transform.position.z)).normalized;
        Quaternion qut = Quaternion.LookRotation(dir);
        charControl.transform.rotation = Quaternion.Slerp(charControl.transform.rotation, qut, rotSpeed * Time.fixedDeltaTime);
    }

    protected bool CheckEdge(CharacterControl charControl, List<GameObject> sphereList, Vector3 dir)
    {
        foreach (GameObject o in sphereList)
        {
            self = false;
            Debug.DrawRay(o.transform.position, dir * blockDistance, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, dir, out hit, blockDistance))
            {
                foreach(Collider c in charControl.ragdollParts)
                {
                    if(c.gameObject == hit.collider.gameObject && !Ledge.IsLedge(hit.collider.gameObject))
                    {
                        self = true;
                        break;
                    }
                }
                if(!self)
                    return true;
            }
        }
        return false;
    }

}
