using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    public enum ChunkType { Empty, SolarSystem };

    public ChunkType chunkType;

    SpriteRenderer spr;

    public int seed;

    public enum ChunkLoadType { none, semi, full};
    public ChunkLoadType chunkLoadType;

    public SolarSystem solarSystemPrefab;
    SolarSystem solarSystem;

    GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();

        if (chunkType == ChunkType.SolarSystem)
        {
            solarSystem = Instantiate(solarSystemPrefab, transform.position, Quaternion.identity);

            solarSystem.radius = Galaxy.chunkSize / 2;

            solarSystem.position = transform.position;
            solarSystem.transform.SetParent(transform);
            solarSystem.seed = seed;
            solarSystem.chunk = this;

        }
        

        chunkLoadType = ChunkLoadType.none;

        spr = GetComponent<SpriteRenderer>();
        if (chunkType == ChunkType.Empty)
        {
            spr.sprite = null;
        }
	}
	
    public SolarSystem GetSolarSystem()
    {
        return solarSystem;
    }

    //sets the color of the chunk
    public void ChangeEmpireStatus()
    {
        Planet.PlanetOwner owner = solarSystem.planets[0].GetOwner();
        bool same = true;

        for (int i = 0; i < solarSystem.planets.Count; i++)
        {
            if (solarSystem.planets[i].GetOwner() != owner)
            {
                same = false;
            }
        }

        if (same)
        {
            if (owner == Planet.PlanetOwner.EmpireA)
            {
                spr.color = gameController.GetEmpire(0).empireColor;
            }
            else if (owner == Planet.PlanetOwner.EmpireB)
            {
                spr.color = gameController.GetEmpire(1).empireColor;
            }
            else if (owner == Planet.PlanetOwner.EmpireC)
            {
                spr.color = gameController.GetEmpire(2).empireColor;
            }
        }


    }
    
	// Update is called once per frame
	void Update () {
        if (chunkType == ChunkType.SolarSystem && chunkLoadType == ChunkLoadType.full && !solarSystem.loaded)
        {
            solarSystem.FullLoad();
        }
	}

    public void FullLoad()
    {
        
        if (chunkType == ChunkType.SolarSystem)
        {
            solarSystem.FullLoad();
        }
        
    }
    public void SemiLoad()
    {

    }

    public void SemiUnload()
    {

    }

    public void Unload()
    {

        chunkLoadType = ChunkLoadType.none;
        print("Unload");
        if (chunkType == ChunkType.SolarSystem)
        {
            
            solarSystem.Unload();
        }
    }
}
