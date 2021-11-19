using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;


    private void Start() {
        
    }

    private void Update() {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bumps"){
            moveSpeed = slowSpeed;
        }
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
        }

        Invoke("ResetPlayerSpeed", 3f);
    }

    private void ResetPlayerSpeed() {
        moveSpeed = 20f;
    }
}
