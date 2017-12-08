using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {


    Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
            player = Player.Instance;
        }
	}

    

}
