using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    public enum ChunkType { Empty, SolarSystem };

    public ChunkType chunkType;

    SpriteRenderer spr;

    public int seed;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        if (chunkType == ChunkType.Empty)
        {
            spr.sprite = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
