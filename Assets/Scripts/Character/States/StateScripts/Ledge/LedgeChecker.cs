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
