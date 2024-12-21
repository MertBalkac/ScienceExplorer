using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverSimulation : MonoBehaviour
{
    public Slider forceSlider; // Kuvvet slider'ý
    public Slider weightSlider; // Yük slider'ý
    public Slider pivotSlider; // Pivot pozisyon slider'ý

    public Transform pivot; // Pivot (Destek) objesi
    public Transform forcePoint; // Kuvvetin uygulandýðý nokta
    public Transform weightPoint; // Yükün olduðu nokta
    public Transform lever; // Kaldýraç çubuðu

    private float forceArm; // Kuvvet kolu uzunluðu
    private float weightArm; // Yük kolu uzunluðu

    public TMP_Text forceText;
    public TMP_Text weightText;
    public GameObject panel;

    private void Start()
    {

        // Oyun baþlangýç ayarlarý
        Time.timeScale = 1f;

        // Slider baþlangýç deðerlerini ayarla
        pivotSlider.minValue = 0;
        pivotSlider.maxValue = 10;
        pivotSlider.value = 5; // Ortada baþlasýn

        // Slider deðerlerini baþlat
        forceText.text = $"{forceSlider.value:F0}";
        weightText.text = $"{weightSlider.value:F0}";

        // Slider eventlerini tanýmla
        forceSlider.onValueChanged.AddListener(ChangeForce);
        weightSlider.onValueChanged.AddListener(ChangeWeight);
    }

    private void FixedUpdate()
    {
        // Görsel güncellemeler
        forceText.text = $"{forceSlider.value:F0} N";
        weightText.text = $"{weightSlider.value:F0} N";
    }

    public void ChangeForce(float value)
    {
        // Kuvvet noktasýnýn kütlesini deðiþtir
        var rb = forcePoint.GetComponent<Rigidbody>();
        rb.mass = value;
        rb.WakeUp(); // Fizik motorunu uyar
        Debug.Log($"Force mass changed to: {rb.mass}");
    }

    public void ChangeWeight(float value)
    {
        // Yük noktasýnýn kütlesini deðiþtir
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
