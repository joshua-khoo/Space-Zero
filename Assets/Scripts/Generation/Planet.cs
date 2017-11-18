using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet {

    System.Random random;
    public const int MAX_PLANET_SIZE = 100;
    int minSize;

    public int seed;

    public Sprite planetSprite;
    public Color planetColor;

    public int size;        // size overlay for resources and buildings
    public int radius;      // radius of planet
    public Vector2 position;

    public const int spacing = 5;
    public Resource[,] resources;
    public Building[,] buildings;

    private List<Resource> resourcesList;

    

    ItemHolder itemHolder;

    public PlanetImage planetImage;


    public Planet(int seed, ItemHolder itemHolder, bool isMoon)
    {
        this.seed = seed;
        this.itemHolder = itemHolder;
        if (isMoon)
        {
            minSize = 25;
        }
        else
        {
            minSize = 50;
        }
        Start();
    }

	// Use this for initialization
	void Start () {
        
        random = new System.Random(seed);

        int size = random.Next(minSize, MAX_PLANET_SIZE);

        radius = size / 2;

        resources = new Resource[size, size];


        Generate();
	}
	
	// Update is called once per frame
	public void Update () {
        updateBuilding();
        updateResources();
	}

    public void Load()
    {

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
        CreateResources();
        SetResourceLocations();


    }

    //for resources
    Vector2 GetRandomSpot()
    {
        bool isDone = false;

        Vector2 pos = new Vector2(-1, -1);

        while (!isDone)
        {
            int x = random.Next(size);
            int y = random.Next(size);
            if (resources[x, y] == null)
            {
                pos = new Vector2(x, y);
                isDone = true;
            }


        }
        

        return pos;
    }

    void SetResourceLocations()
    {
        for (int i = 0; i < resourcesList.Count; i++)
        {
            Vector2 pos = GetRandomSpot();

            resourcesList[i].position = pos;
        }
    }

    void CreateResources()
    {
        int rTotal = random.Next(10) + 5;


        for (int i = 0; i < rTotal; i++)
        {
            Item item = itemHolder.GetItem("Iron Ore");

            resourcesList.Add(new Resource(5, item));
        }
    }

    void updateResources() {

    }

    void updateBuilding() {

    }
}
