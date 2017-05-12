using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float inputMove;
    private float inputTurn;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool hasControl;
    public float movespeed = 10f;
    public float turnspeed = 100f;

    // Use this for initialization
    private void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Invoke("EnableControls", 1);
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

        float turn = inputTurn * turnspeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    }

    private void Move() {
        inputMove = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag.Equals("Goal"))
            Respawn();
    }

    private void Respawn() {
        hasControl = false;
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        Invoke("EnableControls", 1);
    }

    private void EnableControls() {
        hasControl = true;
    }
}
