using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverSimulation : MonoBehaviour
{
    public Slider forceSlider; // Kuvvet slider'�
    public Slider weightSlider; // Y�k slider'�
    public Slider pivotSlider; // Pivot pozisyon slider'�

    public Transform pivot; // Pivot (Destek) objesi
    public Transform forcePoint; // Kuvvetin uyguland��� nokta
    public Transform weightPoint; // Y�k�n oldu�u nokta
    public Transform lever; // Kald�ra� �ubu�u

    private float forceArm; // Kuvvet kolu uzunlu�u
    private float weightArm; // Y�k kolu uzunlu�u

    public TMP_Text forceText;
    public TMP_Text weightText;
    public GameObject panel;

    private void Start()
    {

        // Oyun ba�lang�� ayarlar�
        Time.timeScale = 1f;

        // Slider ba�lang�� de�erlerini ayarla
        pivotSlider.minValue = 0;
        pivotSlider.maxValue = 10;
        pivotSlider.value = 5; // Ortada ba�las�n

        // Slider de�erlerini ba�lat
        forceText.text = $"{forceSlider.value:F0}";
        weightText.text = $"{weightSlider.value:F0}";

        // Slider eventlerini tan�mla
        forceSlider.onValueChanged.AddListener(ChangeForce);
        weightSlider.onValueChanged.AddListener(ChangeWeight);
    }

    private void FixedUpdate()
    {
        // G�rsel g�ncellemeler
        forceText.text = $"{forceSlider.value:F0} N";
        weightText.text = $"{weightSlider.value:F0} N";
    }

    public void ChangeForce(float value)
    {
        // Kuvvet noktas�n�n k�tlesini de�i�tir
        var rb = forcePoint.GetComponent<Rigidbody>();
        rb.mass = value;
        rb.WakeUp(); // Fizik motorunu uyar
        Debug.Log($"Force mass changed to: {rb.mass}");
    }

    public void ChangeWeight(float value)
    {
        // Y�k noktas�n�n k�tlesini de�i�tir
        var rb = weightPoint.GetComponent<Rigidbody>();
        rb.mass = value;
        rb.WakeUp(); // Fizik motorunu uyar
        Debug.Log($"Weight mass changed to: {rb.mass}");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

}
