using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    float countdown = 1f;
    public GameObject luggage;

    Flight flt;

    // Use this for initialization
    void Start()
    {
        flt = new Flight("BJN", new System.DateTime(), Flight.FlightType.DEPARTURE);
        Debug.Log(flt.registeredBaggages);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            countdown = Random.Range(0.5f, 1.2f);
            if (flt.registeredBaggages.Count > 0)
            {
                Baggage bag = flt.registeredBaggages[0];
                flt.registeredBaggages.Remove(bag);

                GameObject bagObject = Instantiate(luggage, transform.position, transform.rotation);
                LuggageController lc = bagObject.GetComponent<LuggageController>();
                lc.CreateLuggageData(bag);
                lc.BakeValues();

            }

            //lc.enabled = false;
            //lc.CreateLuggageData(LuggageController.LuggageType.DEPARTURE, "TXL", "HOM", new Vector3(1f, 1f, 1f), Color.red, "Smith", "GFSAFW");
            //lc.CreateLuggageData(flt.baggages.)
            //lc.BakeValues();
            //lc.enabled = true;

        }
    }
}
