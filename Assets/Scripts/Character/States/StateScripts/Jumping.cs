using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/Jumping")]
public class Jumping : StateData
{
    public float jumpForce;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = characterState.GetCharacterControl(animator);
        charControl.RIGIDBODY.AddForce(Vector3.up * jumpForce);
        animator.SetBool("grounded", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        charControl = null;
    }
}
