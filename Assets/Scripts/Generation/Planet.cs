using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet {

    System.Random random;
    public const int MAX_PLANET_SIZE = 100;
    int minSize;

    public int seed;

    //public Sprite planetSprite;
    public Color planetColor;

    public int size;        // size overlay for resources and buildings
    public float radius;      // radius of planet
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

        radius = size / 2.0f;

        resources = new Resource[Mathf.RoundToInt(radius / spacing), Mathf.RoundToInt(radius / spacing)];


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
        RandomColor();
        InstallResources();
    }

    void RandomColor()
    {
        double r = random.NextDouble();
        double g = random.NextDouble();
        double b = random.NextDouble();

        planetColor = new Color((float)r, (float)g, (float)b);
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
            int x = random.Next(resources.GetLength(0));
            int y = random.Next(resources.GetLength(1));

            float hyp = Mathf.Sqrt(Mathf.Pow((x * spacing) - radius / 2, 2) + Mathf.Pow((y * spacing) - radius / 2, 2));
            
            if (resources[x, y] == null && hyp < radius * .4)
            {

                pos = new Vector2(x, y);

                isDone = true;
            }
            
            /*
            if (resources[x, y] == null)
            {
                
                
                if (hyp < radius * .4)
                {
                    pos = new Vector2(x, y);
                    isDone = true;
                }
                else
                {
                    pos = new Vector2(0, 0);
                    if (random.NextDouble() < 0.1f)
                    {
                        isDone = true;
                    }
                }
                
                
            }
            */

        }
        

        return pos;
    }

    void SetResourceLocations()
    {
        for (int i = 0; i < resourcesList.Count; i++)
        {

            Vector2 pos = GetRandomSpot();

            resourcesList[i].position = pos;

            resources[(int)pos.x, (int)pos.y] = resourcesList[i];

        }
    }

    void CreateResources()
    {
        int rTotal = random.Next(5) + 5;
        //int rTotal = resources.GetLength(0) * resources.GetLength(1);

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
