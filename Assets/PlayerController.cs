using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 10.0f;
    public float interactDistance = 5.0f;

    private Transform cameraTransform;
    private Rigidbody rb;

    private bool m_MouseLookActive = true;
    private bool m_PlayerWalkActive = true;

    private InteractionController objectInHand;

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

    private void FixedUpdate()
    {
        HandleCarriedObject();
    }

    private void HandleCarriedObject()
    {
        if (objectInHand != null)
        {
            objectInHand.GetComponent<Rigidbody>().MovePosition(cameraTransform.position + cameraTransform.forward * 1f);
            if (objectInHand.straining)
            {
                objectInHand.OnDrop();
                objectInHand = null;
            }
        }
    }

    private void HandlePlayerInputs()
    {
        // Interact button press
        if (Input.GetButtonDown("Fire1"))
        {
            // Check for interactable object in center

            RaycastHit hit;

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance))
            {
                InteractionController inter = hit.collider.GetComponent<InteractionController>();
                if (inter != null)
                {
                    if (inter.isCarryable)
                    {
                        objectInHand = inter;
                        inter.OnPickup();
                    } else
                    {
                        inter.OnInteract();
                    }
                
                }
            }

            // Pick Up or Interact
        }

        // Interact button continued check
        if (Input.GetButton("Fire1"))
        {

        }

        // Interact button release
        if (Input.GetButtonUp("Fire1"))
        {
            // Release held object
            if (objectInHand)
            {
                objectInHand.OnDrop();
                objectInHand = null;
            }
        }

        // Hold "Rotate" button
        if (Input.GetButton("Fire2"))
        {
            if (objectInHand)
            {
                m_MouseLookActive = false;
                //objectInHand.GetComponent<Transform>().Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
                objectInHand.GetComponent<Transform>().Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f));
            }

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
