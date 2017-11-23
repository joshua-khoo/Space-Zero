using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireB : Empire {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetUp(Galaxy galaxy)
    {
        SetUp(Color.green, "Green Lazers", galaxy);

        SetOwnedPlanets(new Vector2(galaxy.chunks.GetLength(0), galaxy.chunks.GetLength(1)), Planet.PlanetOwner.EmpireB);
    }

}
