using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioSource[] audio;

	// Use this for initialization
	void Awake () {
        audio = GetComponents<AudioSource>();
	}

    void Start()
    {
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].Play();
        }
    }
}
