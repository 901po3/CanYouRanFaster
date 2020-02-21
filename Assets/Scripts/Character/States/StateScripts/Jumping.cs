using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/Jumping")]
public class Jumping : StateData
{
    public float jumpForce;
    public AnimationCurve graviy;
    public AnimationCurve pull;
    CharacterControl charControl;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
        charControl.RIGIDBODY.AddForce(Vector3.up * jumpForce);
        animator.SetBool("grounded", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl.gravityMultiplier = graviy.Evaluate(stateInfo.normalizedTime);
        charControl.pullMultiplier = pull.Evaluate(stateInfo.normalizedTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
