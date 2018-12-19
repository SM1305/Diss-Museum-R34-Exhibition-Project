using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gondola_Audio : MonoBehaviour {

    public AudioSource wind, engine;

    // Use this for initialization
    void Start () {
        wind.Play();
        engine.Play();
        
    }
}
