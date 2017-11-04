using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {

    public Chunk[,] chunks;

    public Chunk chunkPrefab;

    const int size = 100;
    const int chunkSize = 5;

	// Use this for initialization
	void Start () {
        Generate();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate()
    {
        chunks = new Chunk[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                chunks[x, y] = Instantiate(chunkPrefab,
                    new Vector3((x * chunkSize) - (size * chunkSize / 2), y * chunkSize - (size * chunkSize / 2), 0),
                    Quaternion.identity);

                chunks[x, y].chunkType = Chunk.ChunkType.Empty;

                
            }
        }

        for (float offset = 0; offset < 2*Mathf.PI; offset += Mathf.PI / 2)
        {

            int rad = 0;

            bool end = false;

            for (float r = offset; !end; r += 0.2f)
            {


                int dx = Mathf.RoundToInt(rad * Mathf.Cos(r)) + (size / 2);
                int dy = Mathf.RoundToInt(rad * Mathf.Sin(r)) + (size / 2);

                if (dx < size && dx >= 0 && dy < size && dy >= 0)
                {
                    chunks[dx, dy].chunkType = Chunk.ChunkType.SolarSystem;
                }
                else
                {
                    end = true;
                }
                rad++;


            }
        }
        



    }
}
