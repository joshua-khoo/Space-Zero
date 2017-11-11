using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource {

    private static Wood instance;

    public static Wood Instance {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Wood>();
            return instance;
        }
    }

    public Wood(int amount, int frequency) : base(amount, frequency) {

    }
}
