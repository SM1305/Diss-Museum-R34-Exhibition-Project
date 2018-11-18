using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTouchRotate : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject objectCamera;

    public bool isTouching;

    void Update()
    {
        if (Input.GetMouseButton(0))
            isTouching = true;
        else
            isTouching = false;

        if (isTouching)
        {
            FingerRotate();
        }
    }

    void FingerRotate()
    {
        float Xrot = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float Yrot = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        transform.Rotate(objectCamera.transform.up, -Xrot, Space.World);
        transform.Rotate(objectCamera.transform.right, Yrot, Space.World);
    }
}
