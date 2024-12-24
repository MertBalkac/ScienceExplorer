using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverSimulation : MonoBehaviour
{
    public Slider forceSlider; 
    public Slider weightSlider; 
    public Slider pivotSlider; 

    public Transform pivot; 
    public Transform forcePoint; 
    public Transform weightPoint; 
    public Transform lever; 

    private float forceArm; 
    private float weightArm; 

    public TMP_Text forceText;
    public TMP_Text weightText;
    public GameObject panel;

    private void Start()
    {
        Time.timeScale = 1f;

        pivotSlider.minValue = 0;
        pivotSlider.maxValue = 10;
        pivotSlider.value = 5;

        forceText.text = $"{forceSlider.value:F0}";
        weightText.text = $"{weightSlider.value:F0}";

        forceSlider.onValueChanged.AddListener(ChangeForce);
        weightSlider.onValueChanged.AddListener(ChangeWeight);
    }

    private void FixedUpdate()
    {
        forceText.text = $"{forceSlider.value:F0} N";
        weightText.text = $"{weightSlider.value:F0} N";
    }

    public void ChangeForce(float value)
    {
        var rb = forcePoint.GetComponent<Rigidbody>();
        rb.mass = value;
        rb.WakeUp(); // Fizik motorunu uyar
        Debug.Log($"Force mass changed to: {rb.mass}");
    }

    public void ChangeWeight(float value)
    {
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
