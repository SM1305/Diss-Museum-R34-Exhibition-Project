using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScreenMascot : MonoBehaviour
{
    public SnapScrolling collectionMenu;
    Image image;
    public Text text;
    public Sprite[] mascotSprites;

    private bool isFirstUse = true;


	void Start ()
    {
        image = GetComponent<Image>();

        InvokeRepeating("MascotAnimation", 5.0f, 8f);

        //if PlayerPrefs.usedbefore == false
            //isFirstUse = true;
        //else
            //isFirstUse = false;
    }

    void Update ()
    {
        //if first time using app 
            //default cat, 
            //panel over app, 
            //click through voice lines, 
            //button to help screen
    

        //if panel unlocked
            image.sprite = mascotSprites[collectionMenu.selectedPanel];
            //say an associated voice line
            //if idle
                //prompt to look for poster

        //if panel not unlocked
            //show default cat,
            //prompt user to look for posterprompt user to look for poster


    }

    void MascotAnimation()
    {
        //animate mascot
    }
}
