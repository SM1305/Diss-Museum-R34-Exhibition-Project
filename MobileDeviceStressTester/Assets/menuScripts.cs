using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScripts : MonoBehaviour {

	public void EnableModel(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }

    public void DisableModel(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }
}
