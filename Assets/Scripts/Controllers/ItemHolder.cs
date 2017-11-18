using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour {

    public List<Item> items = new List<Item>();

    


	// Use this for initialization
    //create all items here unless another system is created.
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Item GetItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                return items[i];
            }
        }

        return null;
    }
}
