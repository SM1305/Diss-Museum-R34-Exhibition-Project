using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySaver : MonoBehaviour {

    public Sprite saverOn;
    public Sprite saverOff;
    public Image currentSprite;

    InfomationScreen3dModels models;

    public bool batterySaver = false;

    // Use this for initialization
    void Start ()
    {
        currentSprite = GetComponent<Image>();
        currentSprite.sprite = saverOff;

        models = FindObjectOfType<InfomationScreen3dModels>();
    }

    public void Update()
    {
        if (batterySaver)
        {
            models.enabled = false;
        }
        else
        {
            models.enabled = true;
        }
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
