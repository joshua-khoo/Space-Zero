using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetImage : MonoBehaviour {

    public Planet planet;

    public ResourceSpot resourceSpotPrefab;

    private List<ResourceSpot> rSpots = new List<ResourceSpot>();

    // Use this for initialization
    void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

        spr.sprite = planet.planetSprite;
        spr.color = planet.planetColor;

        for (int x = 0; x < planet.resources.GetLength(0); x++)
        {
            for (int y = 0; y < planet.resources.GetLength(1); y++)
            {
                if (planet.resources[x, y] != null)
                {
                    ResourceSpot newRSpot = Instantiate(resourceSpotPrefab);

                    newRSpot.resource = planet.resources[x, y];

                    newRSpot.planet = planet;

                }
            }
        }



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
