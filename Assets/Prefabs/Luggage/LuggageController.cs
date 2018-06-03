using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageController : MonoBehaviour
{

    Renderer tagRenderer;
    UnityEngine.UI.Text tagText;

    public bool isStarted = false;

    private string destination;
    private LuggageType luggageType = LuggageType.DEPARTURE;

    private Baggage baggageData;

    public Baggage BaggageData
    {
        get
        {
            return baggageData;
        }

    }

    // Need data for:
    // Type: departure, arrival, transfer
    // Destination, Provenance...
    // Owner name, PNR
    // VIP, rush, manual, etc.

    private void Awake()
    {
        // Find the Tag object's Renderer.
        Renderer[] tagRenderers;
        tagRenderers = gameObject.GetComponentsInChildren<Renderer>();
        //Debug.Log(tagRenderers.Length);
        foreach (Renderer r in tagRenderers)
        {
            //Debug.Log(r.gameObject.name);
            if (r.gameObject.name == "Tag")
                tagRenderer = r;
        }
        //Debug.Log(tagRenderer.name);
        tagText = tagRenderer.GetComponentInChildren<UnityEngine.UI.Text>();

    }

    // Receive luggage data (from GameController, etc.)
    public void CreateLuggageData(Baggage baggage)
    {
        baggage.luggageController = this;

        baggageData = baggage;
    }

    // Use this to bake all values into the game, including
    // visuals (tags, writings on the bag, size&color etc.)
    // and game logic.
    // The luggage is invalid if not baked.
    public void BakeValues()
    {
        // Set appropriate color for tag.
        if (baggageData.Destination == "HOM")
        {
            // Arrival bag
            tagRenderer.material.color = Color.yellow;
            luggageType = LuggageType.ARRIVAL;
        }
        else if (baggageData.Provenance == "HOM")
        {
            // Departure Bag
            tagRenderer.material.color = Color.green;
            luggageType = LuggageType.DEPARTURE;
        } else
        {
            // Transfer bag
            tagRenderer.material.color = Color.blue;
            luggageType = LuggageType.TRANSFER;
        }


        // Set luggage color
        GetComponent<Renderer>().material.color = baggageData.Color;

        // Set luggage size
        
        transform.localScale = baggageData.BagSize;
        
        tagText.text = baggageData.Provenance + "\n" + baggageData.Destination;



    }


    public enum LuggageType
    {
        DEPARTURE,
        ARRIVAL,
        TRANSFER
    }


    // Disconnect physical object from persistent Baggage object.
    private void OnDestroy()
    {

    }
}
