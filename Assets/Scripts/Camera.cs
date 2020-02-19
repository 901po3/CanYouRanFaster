using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    #region Input Actions
    private CameraInputAction cameraInputAction;
    private Vector2 cameraAxis;
    #endregion

    [SerializeField] GameObject playerPivot;
    [SerializeField] GameObject camPivot;
    [SerializeField] float rotSpeed;
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

    private void Update()
    {      
        transform.position = playerPivot.transform.position;
        transform.rotation = playerPivot.transform.localRotation;
        if(cameraAxis.x > 0)
        {
            playerPivot.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        else if(cameraAxis.x < 0)
        {
            playerPivot.transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }
        playerPivot.transform.Rotate((Vector3.up * cameraAxis.x) * rotSpeed * Time.deltaTime);
        camPivot.transform.localPosition = new Vector3(0, 0,  - distance);
        transform.position = camPivot.transform.position;
    }
}
