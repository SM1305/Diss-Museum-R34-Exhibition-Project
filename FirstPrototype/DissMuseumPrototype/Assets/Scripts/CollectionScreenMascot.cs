using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScreenMascot : MonoBehaviour
{
    public SnapScrolling collectionMenu;
    public ScrollingButton[] scrollingButton;
    public SnapScrolling snapScrolling;
    Image image;
    public Text mascotText;
    public Image[] mascotSprites;
    public string[] mascotTexts;

    public Image thisPanel;

    int LastPanelInt;

    void Start()
    {
        image = GetComponent<Image>();

        //InvokeRepeating("MascotAnimation", 5.0f, 8f);
    }

    void Update()
    {
        // Only plays once collection menu first becomes available
        if (thisPanel.isActiveAndEnabled)
        {
            // Play Elliot's mascot annimation once available
        }

        // Checks which image should be shown at the top of the collection screen
        int i = snapScrolling.selectedPanelInt;
        if (scrollingButton[snapScrolling.selectedPanelInt].isPanelUnlocked )
        {
            if (LastPanelInt != i)
            {
                //mascotText.GetComponentInParent<Animator>().SetTrigger("Close");
                int j = 0;
                foreach (var item in mascotSprites)
                {
                    if (item.enabled && j != i)
                    {
                        item.enabled = false;
                    }
                    else
                    if(j == i)
                    {
                        item.enabled = true;
                    }

                    j++;
                }
                mascotText.text = mascotTexts[i];
                mascotText.GetComponentInParent<Animator>().SetTrigger("Open");
                LastPanelInt = i;
            }
            
        }
        else // If panel is still locked, defaults back to first one
        {
            if (LastPanelInt != 0)
            {
                foreach (var item in mascotSprites)
                {
                    int j = 0;
                    if (item.enabled && j != 0)
                    {
                        item.enabled = false;
                    }
                    else
                    if (j == 0)
                    {
                        item.enabled = true;
                    }

                    j++;
                }
                mascotText.text = "You have not found this event!  Keep looking!";
                //mascotText.GetComponentInParent<Animator>().SetTrigger("Close");
                LastPanelInt = i;
            }
        }
    
    }

    void MascotAnimation()
    {
        //animate mascot
    }
}