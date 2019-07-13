using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingButton : MonoBehaviour {

    public TargetManager TM;
    public int targetInt;
    public Image LockedImage;

    public GameObject infoScreen;

    public Animator anim;
    public Button button;

    public bool isPanelUnlocked = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        button = this.GetComponent<Button>();
    }

    private void Update()
    {
        if(targetInt < TM.nextTarget)
        {
            isPanelUnlocked = true;

            button.interactable = true;
            LockedImage.enabled = false;
        }
    }

    public void OpenInfoScreen()
    {
        GameObject collectionScreen = GameObject.FindGameObjectWithTag("CollectionScreen");
        collectionScreen.SetActive(false);

        //.SetBool("Clicked", false);
        infoScreen.SetActive(true);
    }

    public void OnClick()
    {
        //anim.SetBool("Clicked", true);
        OpenInfoScreen();
    }
}
