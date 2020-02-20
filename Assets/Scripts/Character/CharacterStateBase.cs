using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : StateMachineBehaviour
{
    private CharacterMovement characterMovement;
    public CharacterMovement GetCharacterMovement(Animator animator)
    {
        if(characterMovement == null)
            characterMovement = animator.GetComponentInParent<CharacterMovement>();
        return characterMovement;
    }
}
