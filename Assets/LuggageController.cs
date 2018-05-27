using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageController : MonoBehaviour {

    private bool m_isBaked = false;
    Renderer tagRenderer;

    // Need data for:
    // Type: departure, arrival, transfer
    // Destination, Provenance...
    // Owner name, PNR
    // VIP, rush, manual, etc.

    private void Start()
    {
        // Find the Tag object and get its Renderer.
        Renderer[] tagRenderers;
        tagRenderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in tagRenderers)
        {
            if (r.gameObject.name == "Tag")
                tagRenderer = r;
        }

        BakeValues();
    }

    // Create random data
    public void RandomizeValues()
    {

    }

    // Use this to bake all values into the game, including
    // visuals (tags, writings on the bag, size&color etc.)
    // and game logic.
    // The luggage is invalid if not baked.
    public void BakeValues()
    {
        // Set appropriate color for tag.
        tagRenderer.material.color = Color.green;

        // Set luggage color
        GetComponent<Renderer>().material.color = Color.gray;

        // Set luggage size
        transform.localScale = new Vector3(Random.Range(0.8f, 1.2f), Random.Range(0.6f, 1.0f), Random.Range(0.8f, 1.5f));
        //tagRenderer.GetComponent<Transform>().localPosition = new Vector3(0.0f, transform.localScale.y / 2 + 0.1f, 0.0f);
        
        

        m_isBaked = true;
    }

}
