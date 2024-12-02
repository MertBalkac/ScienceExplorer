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
        // Particle System'in MainModule'�ne eri�im
        mainModule = liquidParticleSystem.main;

        // Slider ve text ayarlar�
        temperatureText.text = $"{temperatureSlider.value:F0}";
        exValue = temperatureSlider.value; // Ba�lang�� de�eri atan�yor
        temperatureSlider.onValueChanged.AddListener(OnTemperatureChanged);
    }

    public void OnTemperatureChanged(float value)
    {
        // Slider de�erini yuvarla ve g�ncelle
        value = Mathf.Clamp(value, 25f, 80f); // Aral��� s�n�rl�yoruz
        float delta = value - exValue; // De�i�im miktar�

        // Start Speed'i g�ncelle
        mainModule.startSpeed = Mathf.Clamp(mainModule.startSpeed.constant + delta / 10f, 0.1f, 20f); // H�z aral���

        // Eski de�eri g�ncelle
        exValue = value;

        // Slider de�erini text'e yazd�r
        temperatureText.text = $"{value:F0}";
    }
}
