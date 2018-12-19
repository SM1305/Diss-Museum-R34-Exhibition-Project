using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public Color colour;
    public float fadeSpeed;

    public AudioSource wind, engine;

	void Start ()
    {
        colour = GetComponent<Renderer>().material.color;

        StartCoroutine("FadeTo (1.0f, 0.5f)");

        wind.Play();
        engine.Play();
    }
	
	void Update ()
    {
        
    }

    IEnumerator Fade(float aValue, float aTime)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            Color newColour = new Color(1, 1, 1, Mathf.Lerp(colour.a, aValue, t));
            colour = newColour;

            yield return null;
        }
    }
}
