using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

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
}
