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
	// Use this for initialization
	void Start () {
        if (chunkType == ChunkType.SolarSystem)
        {
            solarSystem = Instantiate(solarSystemPrefab);

            solarSystem.radius = Galaxy.chunkSize / 2;

            solarSystem.position = transform.position;
            solarSystem.transform.SetParent(transform);
            solarSystem.seed = seed;
        }
        

        chunkLoadType = ChunkLoadType.none;

        spr = GetComponent<SpriteRenderer>();
        if (chunkType == ChunkType.Empty)
        {
            spr.sprite = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FullLoad()
    {
        solarSystem.FullLoad();
    }
    public void SemiLoad()
    {

    }

    public void SemiUnload()
    {

    }

    public void Unload()
    {

    }
}
