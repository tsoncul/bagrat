using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuteController : MonoBehaviour
{
    private List<Baggage> baggagesInChute;

    // Use this for initialization
    void Start()
    {
        baggagesInChute = new List<Baggage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(other.GetComponent<LuggageController>());
        if (other.GetComponent<LuggageController>() != null)
        {
            //Debug.Log("Received bag. Number in hold: " + baggagesInChute.Count.ToString());
            baggagesInChute.Add(other.GetComponent<LuggageController>().BaggageData);
            Destroy(other.gameObject);
        }
    }

    public void DeliverBaggages(Flight flight)
    {
        foreach (Baggage bag in baggagesInChute)
        {
            flight.LoadBaggage(bag);
            baggagesInChute.Remove(bag);
        }
    }
}
