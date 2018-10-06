using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {


	public void OpenMenu(GameObject MenuToOpen)
	{
		MenuToOpen.SetActive(true);
	}

	public void CloseMenu(GameObject MenuToClose)
	{
		MenuToClose.SetActive(false);
	}
}
