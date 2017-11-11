using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlanetGeneration : MonoBehaviour {

    public Planet planetPrefab;

    public int seed;

    private void Start() {
        Generate();
    }

    void Generate() {
        Instantiate(planetPrefab, new Vector3(Planet.Instance.centerX, Planet.Instance.centerY, 0), Quaternion.identity);
    }

}