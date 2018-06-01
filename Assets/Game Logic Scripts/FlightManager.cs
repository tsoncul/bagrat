using System.Collections.Generic;
using System;
using UnityEngine;

public static class FlightManager
{

    // List of airports. This will be replaced by a better solution.
    private static string[] airportList = { "ARN", "MEX", "CDG", "JFK", "DFW", "HKG", "MAD", "BCN", "FCO", "LHR", "IST", "LAX", "ICN", "SIN", "MUC", "FRA", "BRU", "LIS", "LUX" };

    // Populate flight lists
    public static void PopulateDailyDepartures(List<Flight> flights)
    {
        PopulateFlights(flights, Flight.FlightType.DEPARTURE);
    }

    public static void PopulateDailyArrivals(List<Flight> flights)
    {
        PopulateFlights(flights, Flight.FlightType.ARRIVAL);
    }

    static void PopulateFlights(List<Flight> flights, Flight.FlightType flightType)
    {
        for (int i = 0; i < UnityEngine.Random.Range(8,12); i++)
        {
            string randDest = airportList[UnityEngine.Random.Range(0, airportList.Length - 1)];
            DateTime randTime = new DateTime(2020, 4, 12, UnityEngine.Random.Range(8, 16), UnityEngine.Random.Range(0, 12) * 5, 0);

            flights.Add(new Flight(randDest, randTime, flightType));
        }

        flights.Sort(delegate (Flight x, Flight y)
        {
            if (x.Time == null && y.Time == null) return 0;
            else if (x.Time == null) return -1;
            else if (y.Time == null) return 1;
            else return x.Time.CompareTo(y.Time);
        });
    }

    
}

[Serializable]
public class Flight
{
    // Private members
    private string m_Airport;
    private DateTime m_Time;
    private FlightType m_flightType;
    private Status m_Status;

    // List of Expected Baggages
    // This list is ideally constructed at creation and is a list of
    // all baggages the Player should load into the flight.
    // This manifest will be checked against the "loaded baggage" at departure.
    public List<Baggage> baggages;

    public DateTime Time
    {
        get
        {
            return m_Time;
        }
    }

    public string Airport
    {
        get
        {
            return m_Airport;
        }
    }

    public FlightType Direction
    {
        get
        {
            return m_flightType;
        }

    }

    // Constructors
    public Flight(string airport, DateTime time, FlightType direction)
    {
        m_Time = time;
        m_Airport = airport;
        m_flightType = direction;

        if (direction == FlightType.ARRIVAL)
        {
            m_Status = Status.ENROUTE;
        }
        else
        {
            m_Status = Status.SCHEDULED;
        }

        InitializeBaggages();
    }

    void InitializeBaggages()
    {
        baggages = new List<Baggage>();
        if (m_flightType == FlightType.DEPARTURE)
        {
            BaggageManager.PopulateBaggages(baggages, m_Airport, "HOM");
        }
        else
        {
            BaggageManager.PopulateBaggages(baggages, "HOM", m_Airport);
        }
    }

    public void Update()
    {
        switch (m_Status)
        {
            case Status.CHECKIN:
                State_Checkin();
                break;
            case Status.CLOSED:
                State_Closed();
                break;
            case Status.DEPARTED:
                State_Departed();
                break;
            case Status.ENROUTE:
                State_Enroute();
                break;
            case Status.LANDED:
                State_Landed();
                break;
            case Status.READY:
                State_Ready();
                break;
            case Status.SCHEDULED:
                State_Scheduled();
                break;
        }
    }

    private void State_Scheduled()
    {
        if (AirportController.instance.CurrentTime.AddHours(3) > m_Time)
            m_Status = Status.CHECKIN;
    }

    private void State_Ready()
    {
        if (AirportController.instance.CurrentTime > m_Time)
            m_Status = Status.DEPARTED;
    }

    private void State_Landed()
    {

    }

    private void State_Enroute()
    {
        if (AirportController.instance.CurrentTime > m_Time)
            m_Status = Status.LANDED;
    }

    private void State_Departed()
    {
        
    }

    private void State_Closed()
    {
        if (AirportController.instance.CurrentTime.AddMinutes(15) > m_Time)
            m_Status = Status.READY;
    }

    private void State_Checkin()
    {
        if (AirportController.instance.CurrentTime.AddMinutes(60) > m_Time)
            m_Status = Status.CLOSED;
    }

    public override string ToString()
    {
        return m_Airport + "\t - \t" + m_Time.ToShortTimeString() + "\t - \t" + m_Status.ToString();
    }

    public enum FlightType { ARRIVAL, DEPARTURE };

    public enum Status { ENROUTE, LANDED, SCHEDULED, CHECKIN, CLOSED, READY, DEPARTED }

}
