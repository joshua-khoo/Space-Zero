using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Item[,] inventory;
    public int capacity;
    public long money;

	// Use this for initialization
	void Start () {
        money = 0;
        capacity = Player.strength * 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
