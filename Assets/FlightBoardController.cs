using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightBoardController : MonoBehaviour
{

    private Text displayText;
    private string boardString = "xx";

    private AirportController airportController;
    public Flight.FlightType boardType;

    // Use this for initialization
    void Start()
    {
        displayText = GetComponentInChildren<Text>();
        airportController = GameObject.Find("GameController").GetComponent<AirportController>();

        StartCoroutine(UpdateBoardInfo());

    }

    // Update is called once per frame
    void Update()
    {

        displayText.text = boardString;
    }

    IEnumerator UpdateBoardInfo()
    {
        yield return new WaitWhile(delegate() { return airportController.DailyArrivals == null; });

        List<Flight> flightList;
        if (boardType == Flight.FlightType.DEPARTURE)
        {
            flightList = airportController.DailyFlights;
        }
        else
        {
            flightList = airportController.DailyArrivals;
        }
        while (true)
        {
            //if (airportController.DailyFlights == null) 
            //    yield return new WaitForSeconds(0.1f);
            //Debug.Log("Board Update");
            boardString = "Today's Flights: " + flightList.Count.ToString();
            boardString += "\t\t" + airportController.CurrentTime.ToShortTimeString();
            foreach (Flight flight in flightList)
            {
                boardString += "\n";
                boardString += flight.ToString();
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
