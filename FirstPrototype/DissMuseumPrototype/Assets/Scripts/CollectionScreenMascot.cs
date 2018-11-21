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
    public Sprite[] mascotSprites;

    public Image thisPanel;

    void Start()
    {
        image = GetComponent<Image>();

        InvokeRepeating("MascotAnimation", 5.0f, 8f);
    }

    void Update()
    {
        // Only plays once collection menu first becomes available
        if (thisPanel.isActiveAndEnabled)
        {
            // Play Elliot's mascot annimation once available
        }

        //switch (collectionMenu.selectedPanel)
        //{
        //    case 0:
        //        mascotText.text = "Whopsie!";
        //        break;
        //    case 1:
        //        mascotText.text = "Take-off!";
        //        break;
        //    case 2:
        //        mascotText.text = "Gondola!";
        //        break;
        //    case 3:
        //        mascotText.text = "Crew";
        //        break;
        //    case 4:
        //        mascotText.text = "Stowaway";
        //        break;
        //    case 5:
        //        mascotText.text = "Weather";
        //        break;
        //    case 6:
        //        mascotText.text = "Major";
        //        break;
        //    case 7:
        //        mascotText.text = "NY Landing";
        //        break;
        //    case 8:
        //        mascotText.text = "Homecoming";
        //        break;
        //    default:
        //        mascotText.text = "Something went wrong!";
        //        break;
        //}

        // Checks which image should be shown at the top of the collection screen
        int i = snapScrolling.selectedPanel;
        if (scrollingButton[snapScrolling.selectedPanel].isPanelUnlocked)
        {
            image.sprite = mascotSprites[collectionMenu.selectedPanel];
        }
        else // If panel is still locked, defaults back to first one
        {
            image.sprite = mascotSprites[0];
            mascotText.text = "You have not found this event!  Keep looking!";
        }
    
    }

    void MascotAnimation()
    {
        //animate mascot
    }
}