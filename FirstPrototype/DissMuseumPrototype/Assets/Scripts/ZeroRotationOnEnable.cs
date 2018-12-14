using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRotationOnEnable : MonoBehaviour
{


    private void OnEnable()
    {
        transform.localRotation = Quaternion.identity;

        Debug.Log("I LIVE AGAIN!");
    }
}
