using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireC : Empire {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetUp(Galaxy galaxy)
    {
        SetUp(Color.gray, "Gray Squad", galaxy);

        SetOwnedPlanets(new Vector2(0, galaxy.chunks.GetLength(1)), Planet.PlanetOwner.EmpireC);
    }
}
