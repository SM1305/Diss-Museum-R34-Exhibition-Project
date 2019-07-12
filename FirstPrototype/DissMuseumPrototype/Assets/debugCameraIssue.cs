using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugCameraIssue : MonoBehaviour
{
    public Transform arcamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = arcamera.position.ToString() + "+" + arcamera.eulerAngles.ToString();
    }
}
