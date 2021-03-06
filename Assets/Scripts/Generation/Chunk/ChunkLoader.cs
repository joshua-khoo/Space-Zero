﻿using System.Collections;
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
        new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 1), new Vector2(-1, 1), new Vector2(1, -1), new Vector2(-1, -1)
    };

	// Use this for initialization
	void Start () {
        galaxy = FindObjectOfType<Galaxy>();
        parent = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        LoadChunks();


        UnloadChunks();
    }

    void LoadChunks()
    {
        //Might need to change this to a different rounding type
        int xPos = Mathf.RoundToInt(parent.transform.position.x / Galaxy.chunkSize) + (Galaxy.size / 2);
        int yPos = Mathf.RoundToInt(parent.transform.position.y / Galaxy.chunkSize) + (Galaxy.size / 2);

        Chunk chunk = galaxy.chunks[xPos, yPos];
        if (chunk.chunkLoadType == Chunk.ChunkLoadType.none)
        {
            chunk.chunkLoadType = Chunk.ChunkLoadType.full;
            chunk.FullLoad();
            loadedChunks.Add(chunk);
        }
        



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

            if (chunk.chunkLoadType == Chunk.ChunkLoadType.none)
            {
                chunk.chunkLoadType = Chunk.ChunkLoadType.full;
                chunk.FullLoad();
                loadedChunks.Add(chunk);
            }
            

        }
    }

    int timer = 0;
    void UnloadChunks()
    {
        if (timer == 10)
        {
            chunksToUnload.Clear();
            foreach (Chunk chunk in loadedChunks)
            {
                float distance = Vector3.Distance(
                    new Vector2(chunk.transform.position.x, chunk.transform.position.y),
                    new Vector2(transform.position.x, transform.position.y));
                if (distance > 4000)
                    chunksToUnload.Add(chunk);
            }
            foreach (Chunk chunk in chunksToUnload)
            {
                
                chunk.Unload();
                loadedChunks.Remove(chunk);
            }
                
            timer = 0;
        }
        timer++;
    }

}
