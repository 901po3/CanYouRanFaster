using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 endPosition;
    public bool canClimbUp;

    public Vector3 ledgeLeftEdge;
    public Vector3 ledgeRightEdge;
    public GameObject leftLedge;
    public GameObject righeLedge;
    private float sideCheckerDis = 0.1f;
    private void Start()
    {
        RaycastHit hit;
        ledgeLeftEdge = transform.position + (-transform.right * getWorldScaleOfX(transform) / 2);
        ledgeRightEdge = transform.position + (transform.right * getWorldScaleOfX(transform) / 2);

        if (Physics.Raycast(ledgeLeftEdge, -transform.right, out hit, sideCheckerDis))
        {
            if (hit.collider != gameObject && hit.transform.tag == "Ledge")
            {
                leftLedge = hit.transform.gameObject;
            }
            else
            {
                leftLedge = null;
            }
        }
        if (Physics.Raycast(ledgeRightEdge, transform.right, out hit, sideCheckerDis))
        {
            if (hit.collider != gameObject && hit.transform.tag == "Ledge")
            {
                righeLedge = hit.transform.gameObject;
            }
            else
            {
                righeLedge = null;
            }
        }
    }

    //private void Update()
    //{
    //    Debug.DrawRay(ledgeLeftEdge, -transform.right * sideCheckerDis);
    //    Debug.DrawRay(ledgeRightEdge, transform.right * sideCheckerDis);
    //}

    public static bool IsLedge(GameObject obj)
    {
        if(obj.GetComponent<Ledge>() == null)
        {
            return false;
        }
        return true;
    }

    public float getWorldScaleOfX(Transform trans)
    {
        float x = trans.localScale.x;
        Transform parentTrans = trans;
        while (true)
        {
            if (parentTrans.parent != null)
            {
                x *= trans.parent.localScale.x;
                parentTrans = parentTrans.parent;
            }
            else
            {
                break;
            }
        }
        return x;
    }
}
