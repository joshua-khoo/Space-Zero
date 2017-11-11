using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {

    public string resourceType;
    public float frequency;
    public float amount;

    public Resource(string type, float frequency, float amount) {
        this.resourceType = resourceType;
        this.frequency = frequency;
        this.amount = amount;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
