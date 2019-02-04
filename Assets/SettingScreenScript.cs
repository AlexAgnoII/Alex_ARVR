using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SettingScreenScript : View {

    [SerializeField] private Slider exposureSlider;
    [SerializeField] private Text exposureValue;

    private string MAX_EXPOSURE_FIELD = "max-exposure-compensation";
    private string MIN_EXPOSURE_FIELD = "min-exposure-compensation";
    private string CUR_EXPOSURE_FIELD = "exposure-compensation";

    private void Start()
    {
        this.SetSliderValues();
    }

    private void SetSliderValues()
    {
        string maxExposure;
        string minExposure;
        string curExposure;
        CameraDevice.Instance.GetField(MAX_EXPOSURE_FIELD, out maxExposure);
        CameraDevice.Instance.GetField(MIN_EXPOSURE_FIELD, out minExposure);
        CameraDevice.Instance.GetField(CUR_EXPOSURE_FIELD, out curExposure);

        if(!string.IsNullOrEmpty(maxExposure))
        {
            exposureSlider.maxValue = float.Parse(maxExposure);
        }

        if(!string.IsNullOrEmpty(minExposure))
        {
            exposureSlider.minValue = float.Parse(minExposure);
        }

        if(!string.IsNullOrEmpty(curExposure))
        {
            exposureSlider.value = float.Parse(curExposure);
        }


    }

    public void onValueChanged()
    {
        CameraDevice.Instance.SetField(CUR_EXPOSURE_FIELD, this.exposureSlider.value.ToString());
        this.exposureValue.text = this.exposureSlider.value.ToString();
    }

    public void onApplyClicked()
    {
        ViewHandler.Instance.HideCurrentView();
    }
	
}
