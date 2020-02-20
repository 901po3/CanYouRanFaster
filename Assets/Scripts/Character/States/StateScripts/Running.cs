using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Running")]
public class Running : StateData
{
    public float speed;
    public float rotSpeed;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (!charControl.isMoving)
        {
            charControl.GetComponent<Animator>().SetBool("isRunning", false);
            return;
        }

        Vector3 dir = (charControl.transform.position -
           new Vector3(charControl.camera.transform.position.x,
           charControl.transform.position.y,
           charControl.camera.transform.position.z)).normalized;
        Quaternion qut = Quaternion.LookRotation(dir);
        charControl.transform.rotation
           = Quaternion.Slerp(charControl.transform.rotation, qut, rotSpeed * Time.fixedDeltaTime);

        float curSpeed = speed;
        bool movingV = false;
        bool movingH = false;
        if (charControl.isMovingForward || charControl.isMovingBackward)
            movingV = true;
        if (charControl.isMovingRight || charControl.isMovingLeft)
            movingH = true;
        if (movingV && movingH)
            curSpeed = curSpeed * Mathf.Sin(45);

        if (charControl.isMovingForward)
            charControl.transform.Translate(Vector3.forward * curSpeed * Time.fixedDeltaTime);           
        else if(charControl.isMovingBackward)
            charControl.transform.Translate(Vector3.back * curSpeed * Time.fixedDeltaTime);
        if(charControl.isMovingRight)
            charControl.transform.Translate(Vector3.right * curSpeed * Time.fixedDeltaTime);
        else if(charControl.isMovingLeft)
            charControl.transform.Translate(Vector3.left * curSpeed * Time.fixedDeltaTime);

        Debug.Log(curSpeed);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = null;
    }
}
