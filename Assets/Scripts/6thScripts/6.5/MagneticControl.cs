using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagneticControl : MonoBehaviour
{
    public MagneticForceValue magneticForceValueScript;
    public Rigidbody magnet1;
    public Rigidbody magnet2; 

    public Slider massSlider1; 
    public Slider massSlider2; 
    public Slider magneticForceSlider; 

    public TextMeshProUGUI massText1; 
    public TextMeshProUGUI massText2; 
    public TextMeshProUGUI magneticForceText; 

    public GameObject infoPanel;

    void Start()
    {
        massSlider1.value = magnet1.mass;
        massSlider2.value = magnet2.mass;
        magneticForceSlider.value = magneticForceValueScript.magneticForce;

        massSlider1.onValueChanged.AddListener(OnMass1Changed);
        massSlider2.onValueChanged.AddListener(OnMass2Changed);
        magneticForceSlider.onValueChanged.AddListener(OnMagneticForceChanged);
    }

    void OnMass1Changed(float value)
    {
        magnet1.mass = value;
        massText1.text = $"Mass of Left Ball: {value:F2} kg"; 
    }

    void OnMass2Changed(float value)
    {
        magnet2.mass = value;
        massText2.text = $"Mass of Right Ball: {value:F2} kg"; 
    }

    void OnMagneticForceChanged(float value)
    {
        magneticForceValueScript.magneticForce = value;
        magneticForceText.text = $"Magnetic Force: {value:F2}";
    }
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}
