using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb2d;
    private static Player instance;

    public int strength;

    void Start() {

    }

    public static Player Instance {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }



}
