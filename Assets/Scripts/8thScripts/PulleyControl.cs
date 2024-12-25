using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PulleyControl : MonoBehaviour
{
    public Slider forceSlider; 
    public Slider massSlider; 
    public TMP_Text forceText; 
    public TMP_Text massText; 
    public GameObject leftObject; 
    public GameObject rightObject; 
    public float movementRange = 5f; 

    private Vector3 leftInitialPosition;
    private Vector3 rightInitialPosition;
    private float rightObjectWeight;

    void Start()
    {
        leftInitialPosition = leftObject.transform.position;
        rightInitialPosition = rightObject.transform.position;
        UpdateWeight();
        UpdateUI();
        UpdateMovement();
        forceSlider.onValueChanged.AddListener(UpdateMovement);
        massSlider.onValueChanged.AddListener(UpdateWeight);
        massSlider.onValueChanged.AddListener(UpdateMovement);
        forceSlider.onValueChanged.AddListener(UpdateUI);
        massSlider.onValueChanged.AddListener(UpdateUI);
    }

    void UpdateWeight(float value = 0)
    {
        rightObjectWeight = massSlider.value;
    }

    void UpdateMovement(float value = 0)
    {
        float effectiveForce = forceSlider.value / rightObjectWeight;
        float movement = effectiveForce * movementRange;

        leftObject.transform.position = leftInitialPosition - new Vector3(0, movement, 0);
        rightObject.transform.position = rightInitialPosition + new Vector3(0, movement, 0);
    }

    void UpdateUI(float value = 0)
    {
        forceText.text = forceSlider.value.ToString("F2") + " N";
        massText.text = massSlider.value.ToString("F2") + " Kg";
    }

    void OnDestroy()
    {
        forceSlider.onValueChanged.RemoveListener(UpdateMovement);
        massSlider.onValueChanged.RemoveListener(UpdateWeight);
        massSlider.onValueChanged.RemoveListener(UpdateMovement);
        forceSlider.onValueChanged.RemoveListener(UpdateUI);
        massSlider.onValueChanged.RemoveListener(UpdateUI);
    }
}
