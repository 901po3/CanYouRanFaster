using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    #region Input Actions
    private CameraInputAction cameraInputAction;
    private Vector2 cameraAxis;
    #endregion

    private GameObject playerPivot;
    private GameObject cameraMan;
    private GameObject camPivot;

    [SerializeField] float rotSpeed;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] float zoomSpeed;
    [SerializeField] float distance;

    private void OnEnable()
    { 
        cameraInputAction.Enable();
    }

    private void OnDisable()
    {
        cameraInputAction.Disable();
    }

    private void Awake()
    {
        cameraInputAction = new CameraInputAction();
        cameraInputAction.CameraControls.Rotate.performed += ctx => cameraAxis = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        playerPivot = GameObject.Find("playerPivot");
        cameraMan = GameObject.Find("cameraMan");
        camPivot = GameObject.Find("camPivot");
    }

    private void FixedUpdate()
    {
        //cameraMan.transform.position = playerPivot.transform.position;
        //Rotate();
        //
        //camPivot.transform.localPosition = new Vector3(0, 0,  - distance);
        //transform.position = camPivot.transform.position;
    }

    private void Rotate()
    {
        Vector3 angle = cameraMan.transform.eulerAngles;
        angle.y += cameraAxis.x * Time.fixedDeltaTime * rotSpeed;
        angle.x += cameraAxis.y * Time.fixedDeltaTime * rotSpeed;
        angle.x = Mathf.Clamp(angle.x, minHeight, maxHeight);
        Quaternion rot = Quaternion.Euler(angle);
        cameraMan.transform.rotation = Quaternion.Slerp(cameraMan.transform.rotation, rot, rotSpeed * Time.fixedDeltaTime);
        transform.rotation = cameraMan.transform.rotation;
    }
}
