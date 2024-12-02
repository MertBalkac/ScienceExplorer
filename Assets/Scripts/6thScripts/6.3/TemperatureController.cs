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
        // Particle System'in MainModule'üne eriþim
        mainModule = liquidParticleSystem.main;

        // Slider ve text ayarlarý
        temperatureText.text = $"{temperatureSlider.value:F0}";
        exValue = temperatureSlider.value; // Baþlangýç deðeri atanýyor
        temperatureSlider.onValueChanged.AddListener(OnTemperatureChanged);
    }

    public void OnTemperatureChanged(float value)
    {
        // Slider deðerini yuvarla ve güncelle
        value = Mathf.Clamp(value, 25f, 80f); // Aralýðý sýnýrlýyoruz
        float delta = value - exValue; // Deðiþim miktarý

        // Start Speed'i güncelle
        mainModule.startSpeed = Mathf.Clamp(mainModule.startSpeed.constant + delta / 10f, 0.1f, 20f); // Hýz aralýðý

        // Eski deðeri güncelle
        exValue = value;

        // Slider deðerini text'e yazdýr
        temperatureText.text = $"{value:F0}";
    }
}
