using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private float inputMove;
    private float inputTurn;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool hasControl;
    public float deadZone = 0.1f;
    public float movespeed = 10f;
    public float turnspeed = 100f;

    // Use this for initialization
    private void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Invoke("EnableControls", 1);

        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogError("RIGIDBODY is missing.");
    }

    // Update is called once per frame
    private void Update () {

	}

    private void FixedUpdate() {
        if (hasControl) {
            Move();
            Turn();
        }
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

    private void OnTriggerEnter(Collider col) {
        if (col.tag.Equals("Goal"))
            Respawn();
    }

    private void Respawn() {
        hasControl = false;
        rb.velocity = Vector3.zero;
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        Invoke("EnableControls", 1);
    }

    private void EnableControls() {
        hasControl = true;
    }
}
