using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingButton : MonoBehaviour {

    public TargetManager TM;
    public int targetInt;
    public Image LockedImage;

    private void Update()
    {
        if(targetInt < TM.nextTarget-1 && this.GetComponent<Button>().interactable == false)
        {
            this.GetComponent<Button>().interactable = true;
            LockedImage.enabled = false;
        }
    }

    public void OpenInfoScreen(GameObject infoScreen)
    {
        GameObject collectionScreen = GameObject.FindGameObjectWithTag("CollectionScreen");
        collectionScreen.SetActive(false);
    }
}
