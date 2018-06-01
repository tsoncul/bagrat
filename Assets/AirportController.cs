﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AirportController : MonoBehaviour {

    // Timekeeping
    private System.DateTime time;
    private float gameTimeScale = 60f;

    public DateTime CurrentTime
    {
        get
        {
            return time;
        }

    }


    // Use this for initialization
    void Start () {
        // Initialize the Game Time to 8 AM, some day. This may be updated by the 
        // game level in the future.
        time = new System.DateTime(2020, 4, 12, 8, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        // Update game time
        time = time.AddSeconds(Time.deltaTime * gameTimeScale);
	}



}
