using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    #region Variables
    public GameObject camera;
    public GameObject colliderEdgePrefab;
    public List<GameObject> bottomSpheres = new List<GameObject>();

    public bool isMoving = false;
    public bool isMovingForward = false;
    public bool isMovingBackward = false;
    public bool isMovingRight = false;
    public bool isMovingLeft = false;
    public bool isJumping = false;

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
        BoxCollider box = GetComponent<BoxCollider>();
        float top = box.bounds.center.y + box.bounds.extents.y;
        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;

        GameObject bottomFront = CreateEdgeSphere(new Vector3(transform.position.x, bottom, front));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(transform.position.x, bottom, back));

        bottomSpheres.Add(bottomFront);
        bottomSpheres.Add(bottomBack);

        float sec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5.0f;
        for(int i = 0; i < 4; i++)
        {
            Vector3 pos = bottomBack.transform.position + (transform.forward * sec * (i + 1));
            Debug.Log(pos);
            GameObject obj = CreateEdgeSphere(pos);
            bottomSpheres.Add(obj);
        }
    }

    public GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(colliderEdgePrefab, pos, Quaternion.identity);
        obj.transform.SetParent(transform);
        return obj;
    }
}
