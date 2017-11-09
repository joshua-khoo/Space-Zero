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

	// Use this for initialization
	void Start () {

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
