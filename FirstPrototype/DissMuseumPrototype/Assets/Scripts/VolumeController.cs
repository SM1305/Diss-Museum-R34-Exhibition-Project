using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public Sprite volumeOn;
    public Sprite volumeOff;
    public Image currentSprite;

    public static bool volumeEnabled = true;

    public AudioListener audioListener;

    public AudioSource[] audioSources;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        currentSprite = GetComponent<Image>();
        audioListener.enabled = true;

        

        currentSprite.sprite = volumeOn;
    }

    public void SetMute()
    {
        audioSources = FindObjectsOfType<AudioSource>();

        if (!audioListener.isActiveAndEnabled)
        {
            audioListener.enabled = true;

            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].mute = false;
            }

            currentSprite.sprite = volumeOn;
            volumeEnabled = true;
        }
        else if (audioListener.isActiveAndEnabled)
        {
            audioListener.enabled = false;

            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].mute = true;
            }

            currentSprite.sprite = volumeOff;
            volumeEnabled = false;
        }
    }
}
