using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public Player playerPrefab;

    // Use this for initialization
    void Start() {
        // TODO: change location to not be hard coded in
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
