using System.Collections.Generic;
using System;
using UnityEngine;

public static class FlightManager {


    
}

[Serializable]
public class Flight
{
    // Private members
    private string m_Destination;
    private DateTime m_DepartureTime;

    // List of Expected Baggages
    // This list is ideally constructed at creation and is a list of
    // all baggages the Player should load into the flight.
    // This manifest will be checked against the "loaded baggage" at departure.
    public List<Baggage> baggages;
        
    // Constructors
    public Flight(string destination, DateTime departure)
    {
        m_DepartureTime = departure;
        m_Destination = destination;

        InitializeBaggages();
    }

    void InitializeBaggages()
    {
        baggages = new List<Baggage>();
        for (int i=0;i<UnityEngine.Random.Range(10,15);i++)
        {
            this.baggages.Add(new Baggage(m_Destination, "HOM"));
        }
    }

}
