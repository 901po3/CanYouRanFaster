using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float bottomBoundary;
    [SerializeField] GameObject respawnPos;
    private void Update()
    {
        if (transform.position.y < bottomBoundary)
        {
            transform.position = respawnPos.transform.position;
        }
    }
}
