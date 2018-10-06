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
            GameObject targetGO = TargetManager.objects[targetInt-1];

            targetGO.SetActive(true);
            targetGO.transform.parent = this.transform;
            targetGO.transform.localPosition = Vector3.zero;
            targetGO.transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            //targetGO.SetActive(false);
        }
    }
}
