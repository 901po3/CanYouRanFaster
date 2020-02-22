using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    public bool isGrabbingLedge = false;
    public Ledge grabbedLedge;
    
    Ledge ledge = null;

    private void OnTriggerEnter(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if(ledge != null)
        {
            grabbedLedge = ledge;
            isGrabbingLedge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if (ledge != null)
        {
            grabbedLedge = null;
            isGrabbingLedge = false;
        }
    }

}
