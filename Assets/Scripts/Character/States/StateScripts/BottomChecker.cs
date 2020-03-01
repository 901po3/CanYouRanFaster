using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomChecker : MonoBehaviour
{
    public bool isGround;
    public Ledge ledge;
    private void OnTriggerStay(Collider other)
    {
        if(transform.GetComponentInParent<CharacterControl>().RIGIDBODY.velocity.y > 0 )
        {
            isGround = false;
            ledge = null;
            return;
        }
        if (other.transform.tag != "Player")
        {
            isGround = true;
            if(other.transform.GetComponent<Ledge>() != null)
            {
                ledge = other.transform.GetComponent<Ledge>();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player")
        {
            isGround = false;
            if (other.transform.GetComponent<Ledge>() != null)
            {
                ledge = null;
            }
        }
    }
}
