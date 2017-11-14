using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet : MonoBehaviour {

    System.Random random;

    private static Planet instance;

    public int seed;

    public int size;        // size overlay for resources and buildings
    public int radius;      // radius of planet
    public int centerX;     // x coordinate of planet center
    public int centerY;     // y coordinate of planet center

    public Resource[,] resources;
    public Building[,] buildings;

    private List<Resource> resourcesList;

    SpriteRenderer spr;

    public static Planet Instance {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Planet>();
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
        random = new System.Random(seed);

        int size = random.Next(50, 100);

        radius = size / 2;
        seed = 1;
        
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
        updateBuilding();
        updateResources();
	}

    void Generate() {
        InstallResources();
    }

    void InstallResources() {
        resourcesList = new List<Resource>();

        // @PARAM: RESOURCE TYPE
        // @PARAM: INT AMOUNT PER GENERATION
        // @PARAM: INT FREQUENCY FROM 0 TO 100

        // hard coded in, randomize later
        resourcesList.Add(gameObject.AddComponent<Resource>());

         
        // Add resourced to planet

        for (int x = 0; x < size; x++) {

            for (int y = 0; y < size; y++) {

                // if distance from point (x,y) to center is less than the radius
                if (Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2)) < radius) 

                    // traverse resources list
                    // and choose to add it to that block
                    // based on the frequency
                    for (int i = 0; i < resourcesList.Count; i++) {
                        Instantiate(resourcesList[i].resourceType, new Vector3(x, y, 0), Quaternion.identity);
                        
                    }

                
            }

        }
    }

    void updateResources() {

    }

    void updateBuilding() {

    }
}
