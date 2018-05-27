using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    float countdown = 1f;
    public GameObject luggage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            countdown = Random.Range(6f, 12f);

            GameObject bag = Instantiate(luggage, transform.position, transform.rotation);

            LuggageController lc = bag.GetComponent<LuggageController>();
            //lc.enabled = false;
            lc.CreateLuggageData(LuggageController.LuggageType.DEPARTURE, "TXL", "HOM", new Vector3(1f, 1f, 1f), Color.red, "Smith", "GFSAFW");
            lc.BakeValues();
            //lc.enabled = true;
            
        }
	}
}
