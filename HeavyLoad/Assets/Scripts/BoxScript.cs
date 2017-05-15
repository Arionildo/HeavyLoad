using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Use this for initialization
    void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col) {
        if (col.name.Contains("Blue") && gameObject.name.Contains("Blue")
            || col.name.Contains("Red") && gameObject.name.Contains("Red"))
            Destroy(gameObject, 2);
        else {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
        }
    }
}
