using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMainCameraScript : MonoBehaviour {

    public GameObject mainCamera;

    private void Start()
    {

    }

    void LateUpdate()
    {
        if (this.GetComponent<Camera>().fieldOfView != mainCamera.GetComponent<Camera>().fieldOfView)
        {
            this.GetComponent<Camera>().fieldOfView = mainCamera.GetComponent<Camera>().fieldOfView;
        }

        this.transform.position = mainCamera.transform.position;
        this.transform.eulerAngles = mainCamera.transform.eulerAngles;
    }
}
