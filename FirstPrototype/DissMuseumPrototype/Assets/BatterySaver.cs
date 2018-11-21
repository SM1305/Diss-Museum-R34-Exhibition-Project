using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySaver : MonoBehaviour {

    public Sprite saverOn;
    public Sprite saverOff;
    public Image currentSprite;

    public bool batterySaver = false;

    // Use this for initialization
    void Start ()
    {
        currentSprite = GetComponent<Image>();
        currentSprite.sprite = saverOff;
    }

    public void SetBatterySaver()
    {
        if (!batterySaver)
        {
            batterySaver = true;
            currentSprite.sprite = saverOn;
        }
        else if (batterySaver)
        {
            batterySaver = false;
            currentSprite.sprite = saverOff;
        }
    }
}
