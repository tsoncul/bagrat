using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour {

    public float conveyorSpeed = 1.0f;
    public bool isEnabled = true;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (isEnabled)
        {
            Vector3 movement = rb.transform.forward * conveyorSpeed * Time.deltaTime;
            rb.position -= movement;
            rb.MovePosition(rb.position + movement);
        }
    }
}
