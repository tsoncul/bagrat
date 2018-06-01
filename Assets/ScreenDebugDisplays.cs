using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDebugDisplays : MonoBehaviour
{

    public Text TopLeftL1;
    public Text TopLeftL2;

    AirportController aptController;
    // Use this for initialization
    void Start()
    {
        aptController = FindObjectOfType<AirportController>();
    }

    // Update is called once per frame
    void Update()
    {
        TopLeftL1.text = aptController.CurrentTime.ToShortTimeString();
        Flight f1;
        Flight f2;
        if (aptController.DailyFlights.Count > 0)
        {
            f1 = aptController.DailyFlights[0];
            TopLeftL2.text = f1.ToString();
        } else
        {
            TopLeftL2.text = "No flights";
        }
        if (aptController.DailyFlights.Count > 1)
        {
            f2 = aptController.DailyFlights[1];
            TopLeftL2.text += "\n";
            TopLeftL2.text += f2.ToString();
        }

    }
}
