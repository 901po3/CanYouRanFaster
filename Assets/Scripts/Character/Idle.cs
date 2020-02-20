using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Idle")]
public class Idle : StateData
{
    public override void UpdateAbility(CharacterState characterStateBase, Animator animator)
    {
        CharacterControl playerCS = characterStateBase.GetCharacterControl(animator);

        if (playerCS.playerAxis != Vector2.zero)
        {
            playerCS.anim.SetBool("isRunning", true);
            return;
        }
        else
        {
            playerCS.anim.SetFloat("velX", 0);
            playerCS.anim.SetFloat("velZ", 0);
        }
    }
}
