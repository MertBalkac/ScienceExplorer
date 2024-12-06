using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagneticControl : MonoBehaviour
{
    public MagneticForce magneticForceScript; // Manyetik kuvvet script'i referans�
    public Rigidbody magnet1; // �lk k�re (Rigidbody)
    public Rigidbody magnet2; // �kinci k�re (Rigidbody)

    public Slider massSlider1; // �lk k�re i�in k�tle slider'�
    public Slider massSlider2; // �kinci k�re i�in k�tle slider'�
    public Slider magneticForceSlider; // Manyetik kuvvet slider'�

    public TextMeshProUGUI massText1; // �lk k�re i�in k�tle de�erini g�sterecek metin
    public TextMeshProUGUI massText2; // �kinci k�re i�in k�tle de�erini g�sterecek metin
    public TextMeshProUGUI magneticForceText; // Manyetik kuvvet de�erini g�sterecek metin

    void Start()
    {
        // Ba�lang�� slider de�erlerini ayarla
        massSlider1.value = magnet1.mass;
        massSlider2.value = magnet2.mass;
        magneticForceSlider.value = magneticForceScript.magneticForce;

        // Slider olaylar�n� dinle
        massSlider1.onValueChanged.AddListener(OnMass1Changed);
        massSlider2.onValueChanged.AddListener(OnMass2Changed);
        magneticForceSlider.onValueChanged.AddListener(OnMagneticForceChanged);
    }

    void OnMass1Changed(float value)
    {
        magnet1.mass = value;
        massText1.text = $"Mass 1: {value:F2}"; // K�tle de�erini g�ncelle
    }

    void OnMass2Changed(float value)
    {
        magnet2.mass = value;
        massText2.text = $"Mass 2: {value:F2}"; // K�tle de�erini g�ncelle
    }

    void OnMagneticForceChanged(float value)
    {
        magneticForceScript.magneticForce = value;
        magneticForceText.text = $"Magnetic Force: {value:F2}"; // Manyetik kuvveti g�ncelle
    }
}