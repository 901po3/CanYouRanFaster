using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Idle")]
public class Idle : StateData
{
    public override void UpdateAbility(CharacterState characterStateBase, Animator animator)
    {
        CharacterControl charControl = characterStateBase.GetCharacterControl(animator);

        if (charControl.isMoving)
        {
            charControl.GetComponent<Animator>().SetBool("isRunning", true);
            return;
        }
        else
        {
            charControl.GetComponent<Animator>().SetFloat("velX", 0);
            charControl.GetComponent<Animator>().SetFloat("velZ", 0);
        }
    }
}
