﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 10.0f;

    private Transform cameraTransform;
    private Rigidbody rb;

    private bool m_MouseLookActive = true;
    private bool m_PlayerWalkActive = true;

    private GameObject objectInHand;

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInputs();

    }


    private void HandlePlayerInputs()
    {
        // Interact button press
        if (Input.GetButtonDown("Fire1"))
        {
            // Pick Up or Interact
        }

        // Interact button release
        if (Input.GetButtonUp("Fire1"))
        {
            // Release held object
        }

        // Hold "Rotate" button
        if (Input.GetButton("Fire2"))
        {
            m_MouseLookActive = false;
        }
        else
        {
            m_MouseLookActive = true;
        }

        // Rotate player viewport
        if (m_MouseLookActive)
        {
            // Rotate entire player on mouse X
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * 2.0f, 0.0f);
            // Rotate camera vertical on mouse Y
            cameraTransform.Rotate(Input.GetAxis("Mouse Y") * -2.0f, 0.0f, 0.0f);

            cameraTransform.localRotation = ClampRotationAroundXAxis(cameraTransform.localRotation);
        }

        // Move and strafe
        if (m_PlayerWalkActive)
        {
            Vector3 moveDelta = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            rb.MovePosition(rb.position + moveDelta * walkSpeed * Time.deltaTime); 
        }

    }


    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -80f, 80f);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
