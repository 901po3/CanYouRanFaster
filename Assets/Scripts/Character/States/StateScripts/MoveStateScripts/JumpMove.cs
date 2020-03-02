using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/JumpMove")]
public class JumpMove : MovingStateData
{
    Vector3 momentum;
    public float momentumSpeed;
    public float momentumMaxPower;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        momentum = Vector3.zero;
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

        RoateToCamFacingDir(charControl);
        float curSpeed = CalculateSpeed(charControl, stateInfo);

        if (charControl.isMovingForward)
        {
            momentum.z += momentumSpeed * Time.deltaTime;
        }
        else if (charControl.isMovingBackward)
        {
            momentum.z -= momentumSpeed * Time.deltaTime;
        }
        if (charControl.isMovingRight)
        {
            momentum.x += momentumSpeed * Time.deltaTime;
        }
        else if (charControl.isMovingLeft)
        {
            momentum.x -= momentumSpeed * Time.deltaTime;
        }

        if(momentum.z != 0)
        {
            if (CheckEdge(charControl, charControl.frontSpheres, charControl.transform.forward) || CheckEdge(charControl, charControl.backSpheres, -charControl.transform.forward))
            {
                momentum.z = 0;
            }
            charControl.transform.Translate(Vector3.forward * momentum.z * Time.deltaTime);
        }
        if(momentum.x != 0)
        {
            if (CheckEdge(charControl, charControl.rightSpheres, charControl.transform.right) || CheckEdge(charControl, charControl.leftSpheres, -charControl.transform.right))
            {
                momentum.x = 0;
            }
            charControl.transform.Translate(Vector3.right * momentum.x * Time.deltaTime);
        }

        momentum.x = Mathf.Clamp(momentum.x, -momentumMaxPower, momentumMaxPower);
        momentum.z = Mathf.Clamp(momentum.z, -momentumMaxPower, momentumMaxPower);
        Debug.Log("momentum: " + momentum);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.GetCharacterControl(animator).airMomentum = Vector3.zero;
    }
}
