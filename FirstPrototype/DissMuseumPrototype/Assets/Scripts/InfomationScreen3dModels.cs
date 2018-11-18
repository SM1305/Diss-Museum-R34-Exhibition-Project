using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationScreen3dModels : MonoBehaviour
{
    public SnapScrolling collectionMenu;
    public GameObject[] renderTextureObjects;
    public GameObject activeObject;

    public Image[] backgrounds;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        
        activeObject = renderTextureObjects[collectionMenu.selectedPanel-1];
        activeObject.SetActive(true);

        for (int i = 0; i < renderTextureObjects.Length; i++)
        {
            backgrounds[i].enabled = false;

            if (renderTextureObjects[i] != activeObject)
            {
                renderTextureObjects[i].SetActive(false);
            }
        }
	}
}
