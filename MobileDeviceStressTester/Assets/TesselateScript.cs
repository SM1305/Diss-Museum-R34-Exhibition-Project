using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesselateScript : MonoBehaviour
{
    public float speed;
    public int tesselateAmt;

    public Slider tessSlider;
    public Text displayText;
    public Text FPSText;

    public float deltaTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        this.transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);

        this.GetComponent<MeshRenderer>().material.SetInt("_Tess", tesselateAmt);

        tesselateAmt = (int)tessSlider.value;
        displayText.text = (400 * tesselateAmt).ToString();

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        FPSText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
