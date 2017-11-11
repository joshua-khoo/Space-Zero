using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour {

    public Planet[] planets;

    public int step;

    public int radius;
    public int centerX;
    public int centerY;

	// Use this for initialization
	void Start () {

        centerX = 0;
        centerY = 0;

        for(int i = 0; i < planets.Length; i++)
            radius += planets[i].size + step;

        Generate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate() {

    }
}
