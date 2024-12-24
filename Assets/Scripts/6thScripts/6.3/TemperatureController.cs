using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureController : MonoBehaviour
{
    public Slider temperatureSlider;
    public ParticleSystem liquidParticleSystem;
    public TMP_Text temperatureText;
    public float exValue = 0f;

    private ParticleSystem.MainModule mainModule;

    private void Start()
    {
        mainModule = liquidParticleSystem.main;
        temperatureText.text = $"{temperatureSlider.value:F0}";
        exValue = temperatureSlider.value;
        temperatureSlider.onValueChanged.AddListener(OnTemperatureChanged);
    }

    public void OnTemperatureChanged(float value)
    {
        value = Mathf.Clamp(value, 25f, 80f);
        float delta = value - exValue;
        mainModule.startSpeed = Mathf.Clamp(mainModule.startSpeed.constant + delta / 10f, 0.1f, 20f);
        exValue = value;
        temperatureText.text = $"{value:F0}";
    }
}
