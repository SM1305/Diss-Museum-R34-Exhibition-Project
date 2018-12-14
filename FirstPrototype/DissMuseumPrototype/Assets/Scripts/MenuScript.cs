using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject WelcomeScreen;
    public GameObject CollectionScreen;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstOpen") == 0)
        {
            WelcomeScreen.SetActive(true);
            PlayerPrefs.SetInt("FirstOpen", 1);
        }
        else
        {
            CollectionScreen.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("FirstOpen", 0);
        }
    }

    public void OpenMenu(GameObject MenuToOpen)
	{
		MenuToOpen.SetActive(true);
	}

	public void CloseMenu(GameObject MenuToClose)
	{
		MenuToClose.SetActive(false);
	}

    public void OpenSideMenu(Animator sideMenu)
    {
        sideMenu.SetBool("openSideMenu", true);
    }

    public void CloseSideMenu(Animator sideMenu)
    {
        sideMenu.SetBool("openSideMenu", false);
    }

    public void OpenCogMenu(Animator cogMenu)
    {
        cogMenu.SetBool("openCogMenu", true);
    }

    public void CloseCogMenu(Animator cogMenu)
    {
        cogMenu.SetBool("openCogMenu", false);
    }


    // Close any active and open information screens
    public void CloseInfomationScreens()
    {
        // Store any open info screens in an array.  Use an array to pick up any information screens that might accidently be active
        GameObject[] infoScreens = GameObject.FindGameObjectsWithTag("InformationScreen");
        //GameObject infoScreen = GameObject.FindGameObjectWithTag("InformationScreen");

        //infoScreen.SetActive(false);

        foreach (GameObject info in infoScreens)
        {
            // Disable them
            info.SetActive(false);
        }
    }
}
