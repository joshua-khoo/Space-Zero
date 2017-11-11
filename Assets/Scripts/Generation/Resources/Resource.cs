using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public Resource resourceType;
    public int frequency;
    public int amount;

    public Resource(int amount, int frequency) {
        this.frequency = frequency;
        this.amount = amount;
    }

}
