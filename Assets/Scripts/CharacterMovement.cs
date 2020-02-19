using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Input Actions
    private PlayerInputAction playerInputAction;
    private Vector2 playerAxis;
    #endregion

    #region Animation Related
    private Animator anim;
    private bool isRunning = false;
    #endregion

    [SerializeField] float runningSpeed;

    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerContols.Move.performed += ctx => playerAxis = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log(playerAxis);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("velX", horizontal);
        anim.SetFloat("velZ", vertical);
        isRunning = (horizontal != 0 || vertical != 0) ? true : false;
        anim.SetBool("isRunning", isRunning);
        transform.Translate((Vector3.forward * playerAxis.y + Vector3.right * playerAxis.x) * runningSpeed * Time.fixedDeltaTime);
    }

}
