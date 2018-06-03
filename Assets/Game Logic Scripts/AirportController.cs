using System;
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

    // Flights Register
    private List<Flight> dailyFlights;
    private List<Flight> dailyArrivals;

    public List<Flight> DailyFlights
    {
        get
        {
            return dailyFlights;
        }
    }

    public List<Flight> DailyArrivals
    {
        get
        {
            return dailyArrivals;
        }
    }


    // Use this for initialization
    void Start () {
        // Initialize the Game Time to 8 AM, some day. This may be updated by the 
        // game level in the future.
        time = new System.DateTime(2020, 4, 12, 8, 0, 0, 0);

        // Initialize the daily flights list
        dailyFlights = new List<Flight>();
        dailyArrivals = new List<Flight>();

// Populate both daily flight lists through FlightManager.
        FlightManager.PopulateDailyDepartures(dailyFlights);
        FlightManager.PopulateDailyArrivals(dailyArrivals);

        AirportController.instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        // Update game time
        time = time.AddSeconds(Time.deltaTime * gameTimeScale);

        // Update Flight state machines.
        foreach (Flight f in dailyFlights) f.Update();
        foreach (Flight f in dailyArrivals) f.Update();
    }

    public static AirportController instance;

}