using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Planet {

    System.Random random;
    public const int MAX_PLANET_SIZE = 200;
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

    //for looks and maybe some generation
    public enum PlanetType { Desert, Forest, Plains, Iron, Sulfuric};
    public PlanetType planetType;

    //for player survival, but could have a machine that takes the atmosphere and uses it for creating items
    public enum AtmosphereType { Oxygen, Sulfuric, None };
    public AtmosphereType atmosphereType;

    //how many spots and how much
    public enum ResourceDensity { Rich, Medium, Low, None};
    public ResourceDensity resourceDensity;

    //Resource types
    public enum ResourceType { All, None};
    public ResourceType resourceType;

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
        GenerateBasicPlanet();
        RandomColor();
        InstallResources();
    }

    void GenerateBasicPlanet()
    {
        PlanetTypeGeneration();
        AtmosphereTypeGeneration();
        ResourceDensityGeneration();
        ResourceTypeGeneration();
    }

    void ResourceTypeGeneration()
    {
        if (resourceDensity == ResourceDensity.None)
        {
            resourceType = ResourceType.None;
        }
        else
        {
            resourceType = ResourceType.All;
        }
    }

    void ResourceDensityGeneration()
    {
        double rDensity = random.NextDouble();

        if (rDensity > .9)
        {
            resourceDensity = ResourceDensity.Rich;
        }
        else if (rDensity > .4)
        {
            resourceDensity = ResourceDensity.Medium;
        }
        else if (rDensity > .1)
        {
            resourceDensity = ResourceDensity.Low;
        }
        else
        {
            resourceDensity = ResourceDensity.None;
        }
    }

    void AtmosphereTypeGeneration()
    {
        if (planetType == PlanetType.Sulfuric)
        {
            atmosphereType = AtmosphereType.Sulfuric;
        }
        else if (planetType == PlanetType.Forest || planetType == PlanetType.Plains)
        {
            atmosphereType = AtmosphereType.Oxygen;
        }
        else
        {
            atmosphereType = AtmosphereType.None;
        }
    }

    void PlanetTypeGeneration()
    {
        double pType = random.NextDouble();

        if (pType > .8)
        {
            planetType = PlanetType.Desert;
        }
        else if (pType > .6)
        {
            planetType = PlanetType.Forest;
        }
        else if (pType > .4)
        {
            planetType = PlanetType.Iron;
        }
        else if (pType > .2)
        {
            planetType = PlanetType.Plains;
        }
        else
        {
            planetType = PlanetType.Sulfuric;
        }
    }

    void RandomColor()
    {
        double r = 1;
        double g = 1;
        double b = 1;

        if (planetType == PlanetType.Desert)
        {
            r = 1;
            g = GetRandomDouble(.78, .95);
            b = GetRandomDouble(.51, .95);
        }
        else if (planetType == PlanetType.Forest)
        {
            r = GetRandomDouble(0, .2);
            g = GetRandomDouble(.6, .8);
            b = GetRandomDouble(0, .2);
        }
        else if (planetType == PlanetType.Iron)
        {
            r = GetRandomDouble(.7, 1.0);
            g = GetRandomDouble(.0, .2);
            b = GetRandomDouble(0, .2);
        }
        else if (planetType == PlanetType.Plains)
        {
            r = GetRandomDouble(0, .2);
            g = GetRandomDouble(.8, 1.0);
            b = GetRandomDouble(0, .2);
        }
        else if (planetType == PlanetType.Sulfuric)
        {
            r = GetRandomDouble(.7, 1.0);
            g = r;
            b = GetRandomDouble(0, .2);
        }




        planetColor = new Color((float)r, (float)g, (float)b);
    }

    double GetRandomDouble(double min, double max)
    {
        return random.NextDouble() * (max - min) + min;
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
            
            //only if null
            if (resources[x, y] == null)
            {
                
                //has to be in the radius idk why .4 works but it does
                if (hyp < radius * .4)
                {
                    pos = new Vector2(x, y);
                    isDone = true;
                }
                else
                {
                    pos = Vector2.zero;
                    //give it another try maybe
                    if (random.NextDouble() < 0.1f)
                    {
                        isDone = true;
                    }
                }
                
                
            }
            

        }
        

        return pos;
    }

    void SetResourceLocations()
    {
        for (int i = resourcesList.Count - 1; i >= 0; i--)
        {

            Vector2 pos = GetRandomSpot();
            if (pos == Vector2.zero)
            {
                resourcesList.RemoveAt(i);
            }
            else
            {
                resourcesList[i].position = pos;

                resources[(int)pos.x, (int)pos.y] = resourcesList[i];
            }
            

            

        }
    }

    void CreateResources()
    {
        //needs to be based off of planet type.
        int rTotal = GetTotalResources();
        //int rTotal = resources.GetLength(0) * resources.GetLength(1);

        for (int i = 0; i < rTotal; i++)
        {
            Item item = itemHolder.GetItem("Iron Ore");

            resourcesList.Add(new Resource(GetAmountOfResource(), item));
        }
    }

    int GetAmountOfResource()
    {
        if (resourceDensity == ResourceDensity.Rich)
        {
            return random.Next(10) + 20;
        }
        else if (resourceDensity == ResourceDensity.Medium)
        {
            return random.Next(10) + 5;
        }
        else if (resourceDensity == ResourceDensity.Low)
        {
            return random.Next(5) + 1;
        }
        else
        {
            return 0;
        }
    }

    int GetTotalResources()
    {
        if (resourceDensity == ResourceDensity.Rich)
        {
            return random.Next(10) + 20;
        }
        else if (resourceDensity == ResourceDensity.Medium)
        {
            return random.Next(10) + 5;
        }
        else if (resourceDensity == ResourceDensity.Low)
        {
            return random.Next(5) + 1;
        }
        else
        {
            return 0;
        }
        
    }

    void updateResources() {

    }

    void updateBuilding() {

    }
}
