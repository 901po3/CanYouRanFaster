using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Running")]
public class Running : StateData
{
    public float speed;
    public float rotSpeed;

    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

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

        if (charControl.isMovingForward)
            charControl.transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        else if(charControl.isMovingBackward)
            charControl.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        if(charControl.isMovingRight)
            charControl.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        else if(charControl.isMovingLeft)
            charControl.transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
