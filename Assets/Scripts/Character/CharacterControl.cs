using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject camera;

    public bool isMoving = false;
    public bool isMovingForward = false;
    public bool isMovingBackward = false;
    public bool isMovingRight = false;
    public bool isMovingLeft = false;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
}
