using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTextureSetup : MonoBehaviour
{

    public Camera targetCamera;
    public Material material;

    // Use this for initialization
    void Start()
    {
        if (targetCamera.targetTexture != null)
        {
            targetCamera.targetTexture.Release();
        }
        targetCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        material.mainTexture = targetCamera.targetTexture;
    }
}
