using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

    public Item item;
    public int amount;

    

    public Resource(int amount, Item item) {
        
        this.amount = amount;
        this.item = item;
    }

}
