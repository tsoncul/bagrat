﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageController : MonoBehaviour {

    private bool m_isBaked = false;
    Renderer tagRenderer;
    UnityEngine.UI.Text tagText;

    public bool isStarted = false;

    private string destination;
    private LuggageType luggageType = LuggageType.DEPARTURE;
    
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

        isStarted = true;
    }

    // Create random data
    public void RandomizeValues()
    {

    }

    // Receive luggage data (from GameController, etc.)
    public void CreateLuggageData(LuggageType type, string destination, string provenance, Vector3 size, Color color, string pax, string pnr)
    {
        luggageType = type;
        this.destination = destination;

    }

    // Use this to bake all values into the game, including
    // visuals (tags, writings on the bag, size&color etc.)
    // and game logic.
    // The luggage is invalid if not baked.
    public void BakeValues()
    {
        Debug.Log(isStarted);

        // Set appropriate color for tag.
        tagRenderer.material.color = Color.green;

        // Set luggage color
        GetComponent<Renderer>().material.color = Color.gray;

        // Set luggage size
        transform.localScale = new Vector3(Random.Range(0.8f, 1.2f), Random.Range(0.6f, 1.0f), Random.Range(0.8f, 1.5f));
        //tagRenderer.GetComponent<Transform>().localPosition = new Vector3(0.0f, transform.localScale.y / 2 + 0.1f, 0.0f);

        tagText.text = destination;



        m_isBaked = true;
    }


    public enum LuggageType
    {
        DEPARTURE,
        ARRIVAL,
        TRANSFER
    }
}