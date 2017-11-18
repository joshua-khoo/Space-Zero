using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemImage : MonoBehaviour {


    public Item item;

	// Use this for initialization
	void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

        spr.sprite = item.sprite;
        spr.color = item.color;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
