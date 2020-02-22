using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hyukin's_Game/AbilityData/GroundDetecter")]
public class GroundDetecter : StateData
{
    [Range(0.01f, 1.0f)]
    public float checkTime;
    public float distance;

    private float groundTimer = 0.0f;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl charControl = characterState.GetCharacterControl(animator);

        if (stateInfo.normalizedTime >= checkTime)
        {
            if (IsGrounded(charControl))
            {
                animator.SetBool("grounded", true);
            }
            else
            {
                animator.SetBool("grounded", false);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    private bool IsGrounded(CharacterControl charControl)
    {       
        if(charControl.RIGIDBODY.velocity.y <= 0.0f && charControl.RIGIDBODY.velocity.y > -0.01f)
        {
            groundTimer += Time.deltaTime;
            if(groundTimer > 0.15f)
            {
                return true;
            }
        }

        if(charControl.RIGIDBODY.velocity.y < 0.0f)
        {
            foreach (GameObject o in charControl.bottomSpheres)
            {
                Debug.DrawRay(o.transform.position, Vector3.down * distance, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, Vector3.down, out hit, distance))
                {
                    if(charControl.ragdollParts.Contains(hit.collider) && !Ledge.IsLedge(hit.collider.gameObject))
                        return true;
                }
            }
        }

        return false;
    }
}
