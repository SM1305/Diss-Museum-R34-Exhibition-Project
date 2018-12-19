using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public static TargetManager instance;

    [HideInInspector]
    public int nextTarget = 1;

    public GameObject[] objects;
    public TargetScript[] targets;

    public GameObject contextualButton;
    public GameObject viewfinderSquare;

    // Use this for initialization
    void Start ()
    {
        nextTarget = 1;
        foreach (var target in targets)
        {
            Debug.Log("trying to find ");
            if (PlayerPrefs.GetInt(target.name) != 0)
            {
                Debug.Log("found int " + target.name + PlayerPrefs.GetInt(target.name));
                target.targetInt = PlayerPrefs.GetInt(target.name);
                nextTarget++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reset");
            nextTarget = 0;
            foreach (var target in targets)
            {
                PlayerPrefs.SetInt(target.name, 0);
            }
        }
	}
}
