using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpot : MonoBehaviour {

    public Resource resource;

    public Planet planet;

	// Use this for initialization
	void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.sprite = resource.item.sprite;
        spr.color = resource.item.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
