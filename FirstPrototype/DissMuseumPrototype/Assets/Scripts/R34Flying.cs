using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R34Flying : MonoBehaviour {

    public float MoveSpeed;
    public float RotSpeed;
    public Vector2 MinMaxHeight;
    public Vector2 minMaxRot;  

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float sinPosAmt = Mathf.Sin(Time.time * MoveSpeed);
        float sinRotAmt = Mathf.Sin(Time.time * RotSpeed);

        float newHeight = ((MinMaxHeight.y - MinMaxHeight.x) - MinMaxHeight.x) * sinPosAmt;
        float newRot = ((minMaxRot.y + minMaxRot.x) - minMaxRot.x) * sinRotAmt;

        this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newHeight);
        this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newRot, transform.localEulerAngles.z);
    }
}
