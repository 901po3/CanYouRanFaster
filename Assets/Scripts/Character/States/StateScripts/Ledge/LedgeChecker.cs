using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    public bool isGrabbingLedge = false;
    
    Ledge ledge = null;

    private void OnTriggerEnter(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if(ledge != null)
        {
            isGrabbingLedge = true;
            Vector3 eular = other.transform.rotation.eulerAngles;
            GetComponentInParent<CharacterControl>().transform.localRotation = Quaternion.Euler(eular);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if (ledge != null)
        {
            isGrabbingLedge = false;
        }
    }

}
