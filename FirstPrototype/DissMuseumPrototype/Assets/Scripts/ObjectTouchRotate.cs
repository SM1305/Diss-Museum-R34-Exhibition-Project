using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTouchRotate : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject objectCamera;


    //uses Unity event component
    //during touch, rotates object based on touch input
    public void FingerRotate()
    {
        ///
        /// uncomment lines for full 3D rotation
        /// input currently restricted to only allow horizontal rotation (about Y axis)
        ///

        float Xrot = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        //float Yrot = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
        {
            transform.Rotate(Vector3.up, -Xrot, Space.World);
        }
        else
        {
            transform.Rotate(Vector3.up, -Xrot, Space.World);
        }

        //if (Vector3.Dot(-transform.right, Vector3.left) >= 0)
        //{
        //    transform.Rotate(Vector3.right, -Yrot, Space.World);
        //}
        //else
        //{
        //    transform.Rotate(Vector3.right, -Yrot, Space.World);
        //}
    }
}
