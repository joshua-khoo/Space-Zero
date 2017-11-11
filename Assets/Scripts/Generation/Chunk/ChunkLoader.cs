using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Must be put on the player as a child.
 * 
 * 
 */


public class ChunkLoader : MonoBehaviour {

    Galaxy galaxy;

    GameObject parent;

    List<Chunk> loadedChunks = new List<Chunk>();

    List<Chunk> chunksToUnload = new List<Chunk>();

    static Vector2[] positionsToLoad =
    {
        new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1)
    };

	// Use this for initialization
	void Start () {
        galaxy = FindObjectOfType<Galaxy>();
        parent = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        //Might need to change this to a different rounding type
        int xPos = Mathf.RoundToInt(parent.transform.position.x / Galaxy.chunkSize) + (Galaxy.size / 2);
        int yPos = Mathf.RoundToInt(parent.transform.position.y / Galaxy.chunkSize) + (Galaxy.size / 2);

        Chunk chunk = galaxy.chunks[xPos, yPos];

        chunk.chunkLoadType = Chunk.ChunkLoadType.full;
        chunk.FullLoad();
        loadedChunks.Add(chunk);

        
        for (int i = 0; i < positionsToLoad.Length; i++)
        {
            //handle check(might be wrong)
            if (xPos + (int)positionsToLoad[i].x > Galaxy.size - 1 ||
                xPos + (int)positionsToLoad[i].x < 0 ||
                yPos + (int)positionsToLoad[i].y > Galaxy.size - 1 ||
                yPos + (int)positionsToLoad[i].y < 0)
            {
                continue;
            }
            chunk = galaxy.chunks[xPos + (int)positionsToLoad[i].x, yPos + (int)positionsToLoad[i].y];
            
            chunk.chunkLoadType = Chunk.ChunkLoadType.semi;
            chunk.SemiLoad();
            loadedChunks.Add(chunk);
        }

    }
}
