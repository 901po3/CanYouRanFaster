using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GameObject camera;

    [SerializeField] float rotSpeed;

    #region Input Actions
    private PlayerInputAction playerInputAction;
    private Vector2 playerAxis;
    #endregion

    #region Animation Related
    private Animator anim;
    private int IdleNum = 0;
    private bool isNewIdleOn = false;
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
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerAxis != Vector2.zero)
        {
            Vector3 dir = (transform.position - new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z)).normalized;
            Quaternion qut = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, qut, rotSpeed * Time.fixedDeltaTime);
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("velX", horizontal);
        anim.SetFloat("velZ", vertical);
        isRunning = (horizontal != 0 || vertical != 0) ? true : false;
        anim.SetBool("isRunning", isRunning);
        transform.Translate((Vector3.forward * playerAxis.y + Vector3.right * playerAxis.x) * runningSpeed * Time.fixedDeltaTime);
    }

}
