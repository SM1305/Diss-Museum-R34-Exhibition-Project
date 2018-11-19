using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotate : MonoBehaviour
{
    public float rotateSpeed;

	void Update ()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
	}
}
