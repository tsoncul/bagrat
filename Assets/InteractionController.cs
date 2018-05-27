using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    public bool isCarryable = false;
    public string publicName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
    }
    
}
