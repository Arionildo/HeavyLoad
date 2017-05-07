using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float deadZone = 0.1f;
    public float movespeed = 10f;
    public float turnspeed = 100f;

    // Use this for initialization
    private void Start () {
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogError("RIGIDBODY is missing.");
    }

    // Update is called once per frame
    private void Update () {

	}

    private void FixedUpdate() {
        Move();
        Turn();
    }

    private void Turn() {
        if (Mathf.Abs(rb.velocity.magnitude) > deadZone) {
            float turn = Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    private void Move() {
        rb.velocity = transform.right * -Input.GetAxis("Vertical") * movespeed;
    }
}
