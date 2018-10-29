using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetScript : MonoBehaviour, ITrackableEventHandler
{
    [HideInInspector]
    public int targetInt = 0;
    public bool targetIntSet = false;
    public TargetManager TargetManager;

    GameObject targetObject;

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (mTrackableBehaviour.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("Did");
            if(targetInt == 0)
            {
                targetInt = TargetManager.nextTarget;
                TargetManager.nextTarget++;
                PlayerPrefs.SetInt(this.name, targetInt);
                targetIntSet = true;
            }

            Debug.Log("trying to use " + (targetInt - 1));
            targetObject = TargetManager.objects[targetInt-1];

            targetObject.SetActive(true);
            targetObject.transform.parent = this.transform;
            targetObject.transform.localPosition = Vector3.zero;
            targetObject.transform.localEulerAngles = Vector3.zero;

            TargetManager.contextualButton.SetActive(true);
            TargetManager.viewfinderSquare.SetActive(false);
        }
        else
        {
            if (targetObject != null)
            {
                TargetManager.contextualButton.SetActive(false);
                TargetManager.viewfinderSquare.SetActive(true);
                TargetManager.contextualButton.GetComponent<ContextualARButton>().MenuToOpen = targetObject.GetComponent<ObjectScript>().MenuToOpen;
            }
        }
    }
}
