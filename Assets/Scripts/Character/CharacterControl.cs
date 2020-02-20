using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject camera;
    [SerializeField] float height;

    public bool isMoving = false;
    public bool isMovingForward = false;
    public bool isMovingBackward = false;
    public bool isMovingRight = false;
    public bool isMovingLeft = false;
    public bool isCrawling = false;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 pos = transform.forward + transform.position;
        if (Physics.Raycast(pos, Vector3.up, out hit, height))
        {
            if(hit.transform.tag == "Turnel")
                Debug.DrawRay(pos, Vector3.up * hit.distance, Color.green);
            
        }
        else
        {
            Debug.DrawRay(pos, Vector3.up * height, Color.red);
        }
    }
}
