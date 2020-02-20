using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HyukinState/AbilityData/Running")]
public class Running : StateData
{
    public float speed;

    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        CharacterControl playerCS = characterState.GetCharacterControl(animator);

        if (playerCS.playerAxis == Vector2.zero)
        {
            playerCS.anim.SetBool("isRunning", false);
            return;
        }

        Vector3 dir = (playerCS.transform.position -
           new Vector3(playerCS.camera.transform.position.x,
           playerCS.transform.position.y,
           playerCS.camera.transform.position.z)).normalized;
        Quaternion qut = Quaternion.LookRotation(dir);
        playerCS.transform.rotation
           = Quaternion.Slerp(playerCS.transform.rotation, qut, playerCS.rotSpeed * Time.fixedDeltaTime);

        playerCS.anim.SetFloat("velX", Input.GetAxis("Horizontal"));
        playerCS.anim.SetFloat("velZ", Input.GetAxis("Vertical"));
        playerCS.transform.Translate((Vector3.forward * playerCS.playerAxis.y
            + Vector3.right * playerCS.playerAxis.x) * speed * Time.fixedDeltaTime); 
    }
}
