using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireA : Empire {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void SetUp(Galaxy galaxy)
    {
        SetUp(Color.red, "red dead", galaxy);

        

        SetOwnedPlanets(new Vector2(0, 0), Planet.PlanetOwner.EmpireA);

    }
}
