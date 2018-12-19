using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Audio : MonoBehaviour {

    public AudioSource[] audioSources;

    public bool shouldPlay = false;

    // Use this for initialization
    void Awake()
    {
        audioSources = GetComponentsInChildren<AudioSource>();

        StopAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlay && VolumeController.volumeEnabled)
        {
            StartAudio();
        }
        else
        {
            StopAudio();
        }
    }

    void StartAudio()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].mute = false;
        }
    }

    void StopAudio()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].mute = true;
        }
    }
}
