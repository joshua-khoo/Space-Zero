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
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }
}
