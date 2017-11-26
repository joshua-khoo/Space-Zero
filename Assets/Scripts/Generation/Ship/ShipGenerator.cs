using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour {

    public List<ShipImage> shipImages = new List<ShipImage>();

    int seed = 0;

    Galaxy galaxy;

    System.Random random;

    public Ship shipPrefab;

	// Use this for initialization
	void Start () {
        galaxy = FindObjectOfType<Galaxy>();
        //seed = galaxy.seed;

        seed = 1;
        random = new System.Random(seed);
        GenerateShips();

        Ship newShip = Instantiate(shipPrefab, Vector2.zero, Quaternion.identity);
        newShip.shipImage = shipImages[0];

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateShips()
    {
        int width = 100;
        int height = 200;


        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tex.SetPixel(x, y, Color.white);
            }
        }
        tex.Apply();
        ShipImage newShipImage = new ShipImage(tex, width, height);
        shipImages.Add(newShipImage);

    }


    
}
