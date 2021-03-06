﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetImage : MonoBehaviour {

    public Planet planet;

    public ResourceSpot resourceSpotPrefab;

    private List<ResourceSpot> rSpots = new List<ResourceSpot>();

    

    // Use this for initialization
    void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

        
        spr.color = planet.planetColor;

        transform.localScale = new Vector3(planet.radius, planet.radius, planet.radius);

        SpawnResourceSpots();


        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnResourceSpots()
    {
        
        for (int x = 0; x < planet.resources.GetLength(0); x++)
        {
            for (int y = 0; y < planet.resources.GetLength(1); y++)
            {
                if (planet.resources[x, y] != null)
                {

                    Vector2 pos = new Vector2((x * Planet.spacing) + planet.position.x - planet.radius,
                        (y * Planet.spacing) + planet.position.y - planet.radius);

                    ResourceSpot newRSpot = Instantiate(resourceSpotPrefab, pos, Quaternion.identity);

                    newRSpot.resource = planet.resources[x, y];

                    newRSpot.transform.SetParent(transform);

                    newRSpot.planet = planet;
                    rSpots.Add(newRSpot);
                }
            }
        }
    }

    public void Unload()
    {
        Destroy(gameObject);
    }
}
