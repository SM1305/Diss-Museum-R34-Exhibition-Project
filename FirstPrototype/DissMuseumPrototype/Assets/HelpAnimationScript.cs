using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpAnimationScript : MonoBehaviour {

    public Text helpText;

	public void SetText(string newText)
    {
        helpText.text = newText;
    }

    public void StartAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("Start");
    }
}
