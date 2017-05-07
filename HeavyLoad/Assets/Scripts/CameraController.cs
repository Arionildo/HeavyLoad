using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    // Use this for initialization
    private void Start () {
        if (target == null)
            Debug.LogError("TARGET is missing.");
	}

    // Update is called once per frame
    private void Update () {
        transform.LookAt(target);
	}
}
