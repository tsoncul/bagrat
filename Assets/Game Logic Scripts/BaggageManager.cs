using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaggageManager
{

    public static void PopulateBaggages(List<Baggage> baggages, string destination, string provenance)
    {
        for (int i = 0; i < UnityEngine.Random.Range(12, 16); i++)
        {
            baggages.Add(new Baggage(destination, provenance));
        }
    }

    static void TransferBaggage(Flight arrivingFlight, List<Flight> departures)
    {
        List<Flight> legalConnections = new List<Flight>();

        foreach (Flight flt in departures)
        {
            if (flt.Time >= arrivingFlight.Time.AddMinutes(45))
            {
                legalConnections.Add(flt);
            }
        }
        if (legalConnections.Count > 0)
        {
            Flight departingFlight = legalConnections[UnityEngine.Random.Range(0, legalConnections.Count - 1)];
            arrivingFlight.registeredBaggages.Add(new Baggage(departingFlight.Airport, arrivingFlight.Airport));
        }
    }

}


/* The Baggage class holds all relevant information about a piece of
 * luggage. It is intended to keep all data in one place and be moved around 
 * Flight lists. 
 * 
 * The class Baggage can be passed to the LuggageController object in order to 
 * initialize GameObject attributes. (tags, displays, sizes, etc.)
 */
public class Baggage
{
    // Bag visual attributes
    private Vector3 m_bagSize;
    private Color m_Color;

    // Game attributes, destination etc.
    private string m_Destination;
    private string m_Provenance;
    private string m_PaxName;

    // Connected GameObject
    public LuggageController luggageController;

    // Attributes
    public Vector3 BagSize
    {
        get
        {
            return m_bagSize;
        }

    }

    public Color Color
    {
        get
        {
            return m_Color;
        }

    }

    public string Destination
    {
        get
        {
            return m_Destination;
        }
    }

    public string Provenance
    {
        get
        {
            return m_Provenance;
        }

    }

    // Constructor
    public Baggage(string destination, string provenance)
    {
        m_bagSize = new Vector3(Random.Range(0.8f, 1.2f), Random.Range(0.6f, 1.0f), Random.Range(0.8f, 1.5f));
        m_Color = Random.ColorHSV(0.2f, 0.6f, 0.6f, 0.7f);

        m_Destination = destination;
        m_Provenance = provenance;
        m_PaxName = "Smith";
    }


}
