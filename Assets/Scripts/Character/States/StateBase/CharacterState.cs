using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : StateMachineBehaviour
{
    private CharacterControl characterMovement;
    public List<StateData> ListAbilityData = new List<StateData>();

    public void UpdateAll(CharacterState characterState, Animator animator)
    {
        foreach(StateData d in ListAbilityData)
        {
            d.UpdateAbility(characterState, animator);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateAll(this, animator);
    }

    public CharacterControl GetCharacterControl(Animator animator)
    {
        if(characterMovement == null) 
            characterMovement = animator.GetComponentInParent<CharacterControl>();
        return characterMovement;
    }
}
