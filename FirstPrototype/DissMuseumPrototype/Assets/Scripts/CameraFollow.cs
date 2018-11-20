using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject r34;

	// Use this for initialization
	void Start () {
        r34 = GameObject.FindGameObjectWithTag("R34");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = r34.transform.position;
	}
}
