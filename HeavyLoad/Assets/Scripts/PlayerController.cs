using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private float inputMove;
    private float inputTurn;
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
        inputTurn = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb.velocity.magnitude) > deadZone) {
            float turn = inputTurn * turnspeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    private void Move() {
        inputMove = Input.GetAxis("Vertical");

        if (Mathf.Abs(inputMove) > deadZone)
            rb.velocity = transform.forward * inputMove * movespeed;
    }
}
