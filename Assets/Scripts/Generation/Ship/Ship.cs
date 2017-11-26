using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public ShipImage shipImage;

	// Use this for initialization
	void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.sprite = shipImage.shipImage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
