using System.Collections.Generic;
using System;
using UnityEngine;

public static class FlightManager {

    // List of airports. This will be replaced by a better solution.
    private static string[] airportList = {"ARN","MEX","CDG","JFK","DFW","HKG","MAD","BCN","FCO","LHR","IST","LAX","ICN","SIN","MUC","FRA","BRU","LIS","LUX" };
    public static void PopulateDailyFlights(List<Flight> flights)
    {
        for (int i = 0; i < 10;i++)
        {
            string randDest = airportList[UnityEngine.Random.Range(0,airportList.Length - 1)];
            DateTime randTime = new DateTime(2020, 4, 12, UnityEngine.Random.Range(8, 16), UnityEngine.Random.Range(0, 12) * 5, 0);

            flights.Add(new Flight(randDest, randTime));
        }
    }
    
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
