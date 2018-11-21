using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public Sprite volumeOn;
    public Sprite volumeOff;
    public Image currentSprite;

    public AudioListener audioListener;

    // Use this for initialization
    void Start()
    {
        currentSprite = GetComponent<Image>();
        audioListener.enabled = true;

        currentSprite.sprite = volumeOn;
    }

    public void SetMute()
    {
        if (!audioListener.isActiveAndEnabled)
        {
            audioListener.enabled = true;
            currentSprite.sprite = volumeOn;
        }
        else if (audioListener.isActiveAndEnabled)
        {
            audioListener.enabled = false;
            currentSprite.sprite = volumeOff;
        }
    }
}
