using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    public float moveSpeed;

	// Use this for initialization
	void Start() {
        moveSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update() {
        Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

    void Movement(float horizontal, float vertical) {
        Player.Instance.rb2d.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
