using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject camera;

    public float rotSpeed;

    #region Input Actions
    private PlayerInputAction playerInputAction;
    public Vector2 playerAxis;
    #endregion

    #region Animation Related
    public Animator anim;
    #endregion

    public float runningSpeed;

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

    private void Rotate()
    {
        if (playerAxis != Vector2.zero)
        {
            Vector3 dir = (transform.position - new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z)).normalized;
            Quaternion qut = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, qut, rotSpeed * Time.fixedDeltaTime);
        }
    }
}
