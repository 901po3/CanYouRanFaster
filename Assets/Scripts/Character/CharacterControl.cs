using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject SphereContainers;
    public GameObject camera;
    public GameObject colliderEdgePrefab;
    public List<GameObject> bottomSpheres = new List<GameObject>();
    public List<GameObject> frontSpheres = new List<GameObject>();
    public List<GameObject> backSpheres = new List<GameObject>();
    public List<GameObject> rightSpheres = new List<GameObject>();
    public List<GameObject> leftSpheres = new List<GameObject>();

    public LedgeChecker ledgeChecker;

    public bool isMoving = false;
    public bool isMovingForward = false;
    public bool isMovingBackward = false;
    public bool isMovingRight = false;
    public bool isMovingLeft = false;
    public bool isJumping = false;

    public float gravityMultiplier = 0.0f;
    public float pullMultiplier = 0.0f;

    private Rigidbody rigidbody;
    public Rigidbody RIGIDBODY
    {
        get
        {
            if (rigidbody == null)
                rigidbody = GetComponent<Rigidbody>();
            return rigidbody;
        }
    }
    #endregion

    private void Awake()
    {
        CreateAllSpheres();

        ledgeChecker = GetComponentInChildren<LedgeChecker>();
    }

    private void FixedUpdate()
    {
        if(RIGIDBODY.velocity.y < 0.0f)
        {
            RIGIDBODY.velocity += Vector3.down * gravityMultiplier;
        }
        if(RIGIDBODY.velocity.y > 0.0f && !isJumping)
        {
            RIGIDBODY.velocity += Vector3.down * pullMultiplier;
        }
    }

    public void MoveToFalse()
    {
        isMoving = false;
        isMovingForward = false;
        isMovingBackward = false;
        isMovingRight = false;
        isMovingLeft = false;
    }

    #region EdgeSpheres
    private void CreateAllSpheres()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        float top = box.bounds.center.y + box.bounds.extents.y;
        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;
        float right = box.bounds.center.x + box.bounds.extents.x;
        float left = box.bounds.center.x - box.bounds.extents.x;

        GameObject bottomFront = CreateEdgeSphere(new Vector3(transform.position.x, bottom, front));
        GameObject topFront = CreateEdgeSphere(new Vector3(transform.position.x, top, front));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(transform.position.x, bottom, back));
        GameObject topBack = CreateEdgeSphere(new Vector3(transform.position.x, top, back));
        GameObject bottomRight = CreateEdgeSphere(new Vector3(right, bottom, transform.position.z));
        GameObject topRight = CreateEdgeSphere(new Vector3(right, top, transform.position.z));
        GameObject bottomLeft = CreateEdgeSphere(new Vector3(left, bottom, transform.position.z));
        GameObject topLeft = CreateEdgeSphere(new Vector3(left, top, transform.position.z));

        float horSeg = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5.0f;
        CreateMiddleSpheres(bottomBack, transform.forward, horSeg, 5, bottomSpheres);

        float verSeg = (bottomFront.transform.position - topFront.transform.position).magnitude / 10.0f;
        CreateMiddleSpheres(bottomFront, transform.up, verSeg, 10, frontSpheres);
        CreateMiddleSpheres(bottomBack, transform.up, verSeg, 10, backSpheres);
        CreateMiddleSpheres(bottomRight, transform.up, verSeg, 10, rightSpheres);
        CreateMiddleSpheres(bottomLeft, transform.up, verSeg, 10, leftSpheres);
    }

    private void CreateMiddleSpheres(GameObject start, Vector3 dir, float seg, int iterations, List<GameObject> sphereList)
    {
        for (int i = 0; i < iterations; i++)
        {
            Vector3 pos = start.transform.position + (dir * seg * (i));
            GameObject obj = CreateEdgeSphere(pos);
            sphereList.Add(obj);
        }
    }

    private GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(colliderEdgePrefab, pos, Quaternion.identity);
        obj.transform.SetParent(SphereContainers.transform);
        return obj;
    }
    #endregion
}
