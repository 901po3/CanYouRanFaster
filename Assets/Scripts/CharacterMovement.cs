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
    private bool isTurning = false;
    private bool isTurned = false;
    #endregion

    private GameObject player;
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
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerAxis.y < 0 && !isTurned)
        {
            isTurned = true;
            isTurning = true;
            StartCoroutine(Turn180());
            anim.SetTrigger("isTurning");
        }
        else if(playerAxis.y > 0 && isTurned)
        {
            isTurned = false;
            isTurning = true;
            StartCoroutine(Turn180());
            anim.SetTrigger("isTurning");
        }
        
        if(!isTurning)
        {
            anim.SetFloat("velX", playerAxis.x);
            anim.SetFloat("velZ", playerAxis.y);
            isRunning = (playerAxis != Vector2.zero) ? true : false;
            anim.SetBool("isRunning", isRunning);
            transform.Translate((Vector3.forward * playerAxis.y + Vector3.right * playerAxis.x) * runningSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator Turn180()
    {
        yield return new WaitForSeconds(0.19f);
        player.transform.localRotation = new Quaternion(player.transform.localRotation.x, player.transform.localRotation.y + 180, player.transform.localRotation.z, 1);
        isTurning = false;
    }

}
