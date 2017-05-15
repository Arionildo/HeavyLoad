using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float z = 1000;
	public float maxSpeed = 10 ;
	public float turnSpeed = 100;
	public float gravity = 0;
	private float forca_cima, forca_lado;
	Vector3 forca_movimento, forca_convertida;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private bool hasControl;
	float maxDistanceToGround;
	private CharacterController cc;

	void Start () {

		cc = GetComponent<CharacterController>();
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		Invoke("EnableControls", 1);

	}

	void Update () {
		cc.Move(new Vector3(0, gravity* Time.deltaTime, 0));

		if (hasControl) {
			Movement ();
		}
	}

	void Movement()
	{  
		z = Input.GetAxis("Vertical")*maxSpeed* Time.deltaTime;
		transform.Rotate (new Vector3 (0, Input.GetAxis("Horizontal")*turnSpeed* Time.deltaTime, 0));

		forca_movimento = new Vector3(0, gravity, z);
		forca_convertida = transform.TransformDirection(forca_movimento);
		cc.Move(forca_convertida);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body != null && !body.isKinematic) {
			body.AddForceAtPosition (new Vector3 (hit.point.x, 0, hit.point.z), hit.point);
		}
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
