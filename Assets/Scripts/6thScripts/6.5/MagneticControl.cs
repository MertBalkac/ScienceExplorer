using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagneticControl : MonoBehaviour
{
    public MagneticForce magneticForceScript; // Manyetik kuvvet script'i referansý
    public Rigidbody magnet1; // Ýlk küre (Rigidbody)
    public Rigidbody magnet2; // Ýkinci küre (Rigidbody)

    public Slider massSlider1; // Ýlk küre için kütle slider'ý
    public Slider massSlider2; // Ýkinci küre için kütle slider'ý
    public Slider magneticForceSlider; // Manyetik kuvvet slider'ý

    public TextMeshProUGUI massText1; // Ýlk küre için kütle deðerini gösterecek metin
    public TextMeshProUGUI massText2; // Ýkinci küre için kütle deðerini gösterecek metin
    public TextMeshProUGUI magneticForceText; // Manyetik kuvvet deðerini gösterecek metin

    void Start()
    {
        // Baþlangýç slider deðerlerini ayarla
        massSlider1.value = magnet1.mass;
        massSlider2.value = magnet2.mass;
        magneticForceSlider.value = magneticForceScript.magneticForce;

        // Slider olaylarýný dinle
        massSlider1.onValueChanged.AddListener(OnMass1Changed);
        massSlider2.onValueChanged.AddListener(OnMass2Changed);
        magneticForceSlider.onValueChanged.AddListener(OnMagneticForceChanged);
    }

    void OnMass1Changed(float value)
    {
        magnet1.mass = value;
        massText1.text = $"Mass 1: {value:F2}"; // Kütle deðerini güncelle
    }

    void OnMass2Changed(float value)
    {
        magnet2.mass = value;
        massText2.text = $"Mass 2: {value:F2}"; // Kütle deðerini güncelle
    }

    void OnMagneticForceChanged(float value)
    {
        magneticForceScript.magneticForce = value;
        magneticForceText.text = $"Magnetic Force: {value:F2}"; // Manyetik kuvveti güncelle
    }
}
