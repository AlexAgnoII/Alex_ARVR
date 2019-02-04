using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AutoFocusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(this.onVuforiaStarted);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }
	}

    private void onVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
    }
}
