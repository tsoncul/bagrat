using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    public bool isCarryable = false;
    public string publicName;
    public bool straining = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.impulse.magnitude > 0.2f)
        {
            Debug.Log("Breakaway!");
            straining = true;
        } else
        {
            straining = false;
        }
        
        //Debug.Log(collision.impulse.magnitude);
    }

    public void OnInteract()
    {
        
    }

    public void OnPickup()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void OnDrop() {
        GetComponent<Rigidbody>().useGravity = true;
        straining = false;
    }
    
}
