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

    public bool goDown = false;
    public bool goUp = false;

    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] float zoomSpeed;
    [SerializeField] float distance;

    float originYHeight;
    float fallingTimer = 0.0f;
    bool fallingCam = false;

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

        originYHeight = cameraMan.transform.eulerAngles.x;
    }

    private void Update()
    {
        Rotate();
        MoveToDistance();
    }

    private void MoveToDistance()
    {
        RaycastHit hit;
        Vector3 dir = transform.position - playerPivot.transform.position;
        if (Physics.Raycast(playerPivot.transform.position, dir, out hit, distance))
        {
            if(hit.transform.tag != "Player")
                camPivot.transform.localPosition = Vector3.Lerp(camPivot.transform.localPosition, new Vector3(0, 0, -hit.distance), 10);
        }
        else
        {
            camPivot.transform.localPosition = Vector3.Lerp(dir, new Vector3(0, 0, -distance), 10);
        }
        if(cameraAxis == Vector2.zero && (Input.GetAxis("Mouse Y") == 0 && Input.GetAxis("Mouse X") == 0))
        {
            transform.position = new Vector3(camPivot.transform.position.x, transform.position.y, camPivot.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, camPivot.transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            transform.position = camPivot.transform.position;
        }
    }

    private void Rotate()
    {
        cameraMan.transform.position = playerPivot.transform.position;
        Vector3 angle = cameraMan.transform.eulerAngles;

        if (Input.GetMouseButton(1))
        {
            angle.y += Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;
            angle.x += Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed;
            angle.x = Mathf.Clamp(angle.x, minHeight, maxHeight);
            originYHeight = angle.x;
            fallingCam = false;
        }
        else if(!Input.GetMouseButton(1) && cameraAxis != Vector2.zero)
        {
            angle.x += cameraAxis.y * Time.deltaTime * rotSpeed;
            angle.y += cameraAxis.x * Time.deltaTime * rotSpeed;
            angle.x = Mathf.Clamp(angle.x, minHeight, maxHeight);
            originYHeight = angle.x;
            fallingCam = false;
        }
        else if(cameraAxis.y == 0 && Input.GetAxis("Mouse Y") == 0 && !playerPivot.GetComponentInParent<ManualInput>().jumpInput)
        {
            if (playerPivot.GetComponentInParent<CharacterControl>().RIGIDBODY.velocity.y < -0.1f)
            {
                if(!fallingCam)
                    fallingTimer += Time.deltaTime;
                if(fallingTimer >= 0.5f)
                    fallingCam = true;        
                
                if(fallingCam)
                {
                    angle.x += Time.deltaTime * rotSpeed / 2;
                    angle.x = Mathf.Clamp(angle.x, minHeight, maxHeight);
                    fallingTimer = 0.0f;
                }
            }
            else if(playerPivot.GetComponentInParent<CharacterControl>().RIGIDBODY.velocity.y == 0)
            {
                angle.x -= Time.deltaTime * rotSpeed / 2;
                angle.x = Mathf.Clamp(angle.x, originYHeight, maxHeight);
                fallingCam = false;
            }
        }
        Quaternion rot = Quaternion.Euler(angle);
        cameraMan.transform.rotation = Quaternion.Slerp(cameraMan.transform.rotation, rot, rotSpeed * Time.deltaTime);
        transform.rotation = cameraMan.transform.rotation;


    }
}
