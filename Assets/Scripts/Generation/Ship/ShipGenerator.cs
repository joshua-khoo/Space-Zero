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

        seed = 2;
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

        

        int maxSpots = height / 10;

        int spacing = Mathf.RoundToInt(maxSpots * 1.5f);

        Vector2[] pos = new Vector2[maxSpots];

        pos[0] = new Vector2(width / 2, height);
        pos[maxSpots - 1] = pos[0];


        int posY = 0;
        for (int i = 1; i < (maxSpots / 2) - 1; i++)
        {
            int j = 0;
            

            j = random.Next(posY + 1, (spacing) + posY);

            posY = j;
            
            print(posY);
            Vector2 p = new Vector2(random.Next(1, (width / 2) - 5), height - posY);
            pos[i] = p;

            Vector2 p2 = new Vector2(width - p.x, height - posY);

            pos[maxSpots - i - 1] = p2;
            print(p + "   " + p2);
        }
        print(((maxSpots / 2) - 1) + "   " + (maxSpots/2));
        pos[(maxSpots / 2) - 1] = new Vector2(random.Next(1, (width / 2) - 5), 0);
        pos[maxSpots/2] = new Vector2(width - pos[(maxSpots / 2) - 1].x, 0);



        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (IsInside(pos, new Vector2(x, y)))
                {
                    tex.SetPixel(x, y, Color.white);
                }
                else
                {
                    tex.SetPixel(x, y, new Color(0, 0, 0, 0));
                }
                
            }
        }
        tex.Apply();
        ShipImage newShipImage = new ShipImage(tex, width, height);
        shipImages.Add(newShipImage);

    }

    bool IsInside(Vector2[] points, Vector2 pos)
    {

        int i;
        int j;

        bool isInside = false;

        for (i = 0, j = points.Length - 1; i < points.Length; j = i++)
        {
            if ((points[i].y > pos.y) != (points[j].y > pos.y) &&
                (pos.x < (points[j].x - points[i].x) * (pos.y - points[i].y) / (points[j].y - points[i].y) + points[i].x))
            {

                isInside = !isInside;
            }

        }

        return isInside;
    }

    
}
