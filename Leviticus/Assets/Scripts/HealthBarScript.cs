using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider meterSlider;

    public void UpdateMeter(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        meterSlider.value = percentageResult;
    }
}

