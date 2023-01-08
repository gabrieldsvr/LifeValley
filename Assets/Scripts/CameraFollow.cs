using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + camOffset;
    }
}
