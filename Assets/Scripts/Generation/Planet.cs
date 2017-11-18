using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet {

    System.Random random;

    private static Planet instance;

    public int seed;

    public Sprite planetSprite;
    public Color planetColor;

    public int size;        // size overlay for resources and buildings
    public int radius;      // radius of planet
    public int centerX;     // x coordinate of planet center
    public int centerY;     // y coordinate of planet center

    public Resource[,] resources;
    public Building[,] buildings;

    private List<Resource> resourcesList;

    SpriteRenderer spr;

    ItemHolder itemHolder;

    


    public Planet(int seed, ItemHolder itemHolder)
    {
        this.seed = seed;
        this.itemHolder = itemHolder;

        Start();
    }

	// Use this for initialization
	void Start () {
        
        random = new System.Random(seed);

        int size = random.Next(50, 100);

        radius = size / 2;
        
        
        Generate();
	}
	
	// Update is called once per frame
	public void Update () {
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
        //resourcesList.Add(new Resource(5));


        // Add resourced to planet
        int rAmount = random.Next(10) + 5;


        for (int i = 0; i < rAmount; i++)
        {

        }
        
        
    }

    void updateResources() {

    }

    void updateBuilding() {

    }
}
