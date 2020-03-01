﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl charControl;
    private Animator animator;
    private Camera mainCamera;

    #region Input Actions
    private PlayerInputAction playerInputAction;
    private Vector2 playerAxis;
    public bool jumpInput;
    public bool dropToHangInput;
    #endregion

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        charControl = gameObject.GetComponent<CharacterControl>();
        animator = gameObject.GetComponent<Animator>();
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerContols.Move.performed += ctx => playerAxis = ctx.ReadValue<Vector2>();
        playerInputAction.PlayerContols.Jump.performed += ctx => jumpInput = true;
        playerInputAction.PlayerContols.Jump.canceled += ctx => jumpInput = false;
        playerInputAction.PlayerContols.DropToHang.performed += ctx => dropToHangInput = true;
        playerInputAction.PlayerContols.DropToHang.canceled += ctx => dropToHangInput = false;
    }

    private void Update()
    {
        Moving();
        charControl.isJumping = jumpInput;
    }

    private void Moving()
    {
        charControl.isMoving = (playerAxis != Vector2.zero) ? true : false;
        charControl.isMovingForward = (playerAxis.y > 0) ? true : false;
        charControl.isMovingBackward = (playerAxis.y < 0) ? true : false;
        if(charControl.ledgeCheckers[0].isGrabbingLedge || charControl.ledgeCheckers[1].isGrabbingLedge)
        {
            if(mainCamera.facingValue >= 0)
            {
                charControl.isMovingRight = (playerAxis.x > 0) ? true : false;
                charControl.isMovingLeft = (playerAxis.x < 0) ? true : false;
            }
            else
            {
                charControl.isMovingRight = (playerAxis.x > 0) ? false : true;
                charControl.isMovingLeft = (playerAxis.x < 0) ? false : true;
            }
        }
        else if(!charControl.ledgeCheckers[0].isGrabbingLedge && !charControl.ledgeCheckers[1].isGrabbingLedge)
        {
            charControl.isMovingRight = (playerAxis.x > 0) ? true : false;
            charControl.isMovingLeft = (playerAxis.x < 0) ? true : false;
        }
        charControl.isDropToHang = (charControl.bottomLedge != null && dropToHangInput) ? true : false;

        animator.SetFloat("velX", Input.GetAxis("Horizontal"));
        animator.SetFloat("velZ", Input.GetAxis("Vertical"));
    }

    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

}
