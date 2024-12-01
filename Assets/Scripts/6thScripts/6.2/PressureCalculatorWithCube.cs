using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PressureCalculatorWithCubeTMP : MonoBehaviour
{
    public Slider weightSlider; 
    public Slider surfaceAreaSlider; 
    public TMP_Text weightText; 
    public TMP_Text surfaceAreaText; 
    public TMP_Text pressureText; 
    public GameObject cube; 
    public float scaleFactor = 0.5f; 

    private float weight = 1f; 
    private float surfaceArea = 0.1f; 

    void Start()
    {
        weightSlider.value = weight;
        surfaceAreaSlider.value = surfaceArea;

        weightSlider.minValue = 0.1f;
        surfaceAreaSlider.minValue = 0.01f;

        weightText.text = $"{weight} kg";
        surfaceAreaText.text = $"{surfaceArea} m²";

        weightSlider.onValueChanged.AddListener(OnWeightChanged);
        surfaceAreaSlider.onValueChanged.AddListener(OnSurfaceAreaChanged);

        UpdateCubeSize(); 
        UpdatePressure(); 
    }

    void UpdatePressure()
    {
        double pressure = CalculatePressure(weight, surfaceArea);
        pressureText.text = pressure > 0 ? $"{pressure:F3} Pa" : "Unvalid";
    }

    public void OnWeightChanged(float newWeight)
    {
        weight = Mathf.Round(newWeight * 100) / 100;
        weightText.text = $"{weight} kg";
        UpdatePressure(); 
    }

    public void OnSurfaceAreaChanged(float newSurfaceArea)
    {
        surfaceArea = Mathf.Round(newSurfaceArea * 100) / 100;
        surfaceAreaText.text = $"{surfaceArea} m²";
        UpdateCubeSize(); 
        UpdatePressure(); 
    }

    private double CalculatePressure(float weight, float surfaceArea)
    {
        double dweight = Mathf.Floor(weight * 100) / 100;
        double dSurfaceArea = Mathf.Floor(surfaceArea * 100) / 100;
        if (surfaceArea <= 0.01f) return 0;
        double result = dweight / dSurfaceArea;
        return result;
    }

    private void UpdateCubeSize()
    {
        if (cube != null)
        {
            float sideLength = Mathf.Sqrt(surfaceArea) * scaleFactor;
            cube.transform.localScale = new Vector3(sideLength, cube.transform.localScale.y, sideLength);
        }
    }
}
