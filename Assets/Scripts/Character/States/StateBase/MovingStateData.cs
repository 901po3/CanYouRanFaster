using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStateData : StateData
{
    public AnimationCurve speedGraph;
    public float speed;
    public float rotSpeed;
    public float blockDistance;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) { }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) { }
    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) { }

    protected float CalculateSpeed(AnimatorStateInfo stateInfo)
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

    protected void RoateToCamFacingDir()
    {
        Vector3 dir = (charControl.transform.position -
            new Vector3(charControl.camera.transform.position.x, charControl.transform.position.y, charControl.camera.transform.position.z)).normalized;
        Quaternion qut = Quaternion.LookRotation(dir);
        charControl.transform.rotation = Quaternion.Slerp(charControl.transform.rotation, qut, rotSpeed * Time.fixedDeltaTime);
    }

    protected bool CheckEdge(List<GameObject> sphereList, Vector3 dir)
    {
        foreach (GameObject o in sphereList)
        {
            Debug.DrawRay(o.transform.position, dir * blockDistance, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, dir, out hit, blockDistance))
            {
                return true;
            }
        }
        return false;
    }

}
