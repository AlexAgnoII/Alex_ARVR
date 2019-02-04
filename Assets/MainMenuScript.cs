using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MainMenuScript : View {

    [SerializeField] private Text texts;

    private void Start()
    {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(this.doThis);
    }

    public void onSettingsButtonClicked()
    {
        ViewHandler.Instance.Show(ViewNames.ExposureNames.SETTING_SCREEN);
    }

    private void doThis()
    {
        IEnumerable cameraFields = CameraDevice.Instance.GetCameraFields();// Print fields to device logs

        /*string fields = "";

        foreach (CameraDevice.CameraField field in cameraFields)
        {

            if (field.Key.Contains("exposure")) { 
                Debug.Log("Key: " + field.Key + "; Type: " + field.Type.ToString());
                fields += "Key: " + field.Key + "; Type: " + field.Type.ToString() + "\n";
            }

        }

        

        texts.text = fields;
        */
    }

}
