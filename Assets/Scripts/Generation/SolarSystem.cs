﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolarSystem : MonoBehaviour {

    System.Random random;

    public List<Planet> planets = new List<Planet>();

    public int step;

    public int radius;
    public Vector2 position;

    public int seed;

    public ItemHolder itemHolder;

    public PlanetImage planetImagePrefab;


    public bool generated = false;
	// Use this for initialization
	void Start () {

        itemHolder = FindObjectOfType<ItemHolder>();

        random = new System.Random();
        
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate() {
        int totalPlanets = random.Next(9) + 2;
        
        for (int i = 0; i < totalPlanets; i++)
        {
            Planet newPlanet = new Planet(random.Next(int.MinValue, int.MaxValue), itemHolder, false);
            newPlanet.position = GetNewPlanetPosition(newPlanet);
            planets.Add(newPlanet);
        }
        generated = true;
    }

    

    //NOTE: Need to check if planets are intersecting
    Vector2 GetNewPlanetPosition(Planet planet)
    {
        Vector2 rPos = new Vector2(random.Next(-radius + planet.radius, radius - planet.radius),
            random.Next(-radius + planet.radius, radius - planet.radius));

        return rPos + position;
    }
    bool loaded = false;
    public void FullLoad()
    {
        if (!loaded && generated)
        {
            
            for (int i = 0; i < planets.Count; i++)
            {
                PlanetImage newPlanetImage = Instantiate(planetImagePrefab);
                newPlanetImage.planet = planets[i];
                planets[i].planetImage = newPlanetImage;
                
                newPlanetImage.transform.SetParent(transform);

            }
            loaded = true;
        }
        
    }
}
