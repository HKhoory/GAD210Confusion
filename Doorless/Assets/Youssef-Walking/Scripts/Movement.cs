using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    private Transform mainCam;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        mainCam = Camera.main.transform;
    }

    private void Update()
    {
        DirectionMovement();
    }

    // calculates movemnt direction 
    public void DirectionMovement()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        direction = (mainCam.forward * vAxis) + (mainCam.right * hAxis);

        direction.Normalize();
        direction.y = 0;

        direction *= speed;

        rb.velocity = direction;
    }
}