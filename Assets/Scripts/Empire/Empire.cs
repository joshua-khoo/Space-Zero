using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Empire : MonoBehaviour {


    List<Planet> ownedPlanets = new List<Planet>();

    public long money;

    public Color empireColor;
    public string empireName;

    Galaxy galaxy;

    public void SetUp(Color color, string name, Galaxy galaxy)
    {
        empireColor = color;
        empireName = name;
        money = 10000000000000000;

        this.galaxy = galaxy;

    }

    public virtual void SetUp(Galaxy galaxy)
    {
        SetUp(Color.black, "none", galaxy);
    }


    public void SetOwnedPlanets(Vector2 pos, Planet.PlanetOwner owner)
    {

        float radius = Galaxy.size / 2.5f;

        for (int x = 0; x < galaxy.chunks.GetLength(0); x++)
        {
            for (int y = 0; y < galaxy.chunks.GetLength(1); y++)
            {
                float dist = Mathf.Sqrt(Mathf.Pow(x - pos.x, 2) + Mathf.Pow(y - pos.y, 2));

                if (dist <= radius)
                {

                    SolarSystem sol = galaxy.chunks[x, y].GetSolarSystem();
                    if (sol != null)
                    {
                        for (int i = 0; i < sol.planets.Count; i++)
                        {
                            sol.planets[i].ChangeOwner(owner);
                        }
                    }
                    
                }

            }
        }
    }
	
}
