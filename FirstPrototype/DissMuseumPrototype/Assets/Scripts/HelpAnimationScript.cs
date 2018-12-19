using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpAnimationScript : MonoBehaviour {

    public GameObject speechBubbleCat;
    public Text helpText;

	public void SetText(string newText)
    {
        helpText.text = newText;
    }

    public void StartAnimation()
    {
        Debug.Log("Being Called");
        this.GetComponent<Animator>().SetTrigger("Start");
        speechBubbleCat.GetComponent<Animator>().SetTrigger("Open");
    }
}
