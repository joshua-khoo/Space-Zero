using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private static Player instance;
    public Player playerPrefab;

    public int strength;

    void Start() {
        // TODO: change location to not be hard coded in
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public static Player Instance {
        get {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }

}
