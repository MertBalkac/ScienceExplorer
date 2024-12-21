using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PulleyControl : MonoBehaviour
{
    public Slider forceSlider; // Force slider referans�
    public Slider massSlider; // Mass slider referans�
    public TMP_Text forceText; // Force de�erini g�stermek i�in UI Text
    public TMP_Text massText; // Mass de�erini g�stermek i�in UI Text
    public GameObject leftObject; // Sol grup (a�a�� hareket eden)
    public GameObject rightObject; // Sa� grup (yukar� hareket eden)
    public float movementRange = 5f; // Maksimum hareket mesafesi

    private Vector3 leftInitialPosition;
    private Vector3 rightInitialPosition;
    private float rightObjectWeight;

    void Start()
    {
        // Objelerin ba�lang�� pozisyonlar�n� kaydet
        leftInitialPosition = leftObject.transform.position;
        rightInitialPosition = rightObject.transform.position;

        // Ba�lang��ta de�erleri g�ncelle
        UpdateWeight();
        UpdateUI();
        UpdateMovement();

        // Slider'lar�n de�er de�i�imlerini dinle
        forceSlider.onValueChanged.AddListener(UpdateMovement);
        massSlider.onValueChanged.AddListener(UpdateWeight);
        massSlider.onValueChanged.AddListener(UpdateMovement);
        forceSlider.onValueChanged.AddListener(UpdateUI);
        massSlider.onValueChanged.AddListener(UpdateUI);
    }

    void UpdateWeight(float value = 0)
    {
        // Sa�daki objenin a��rl���n� mass slider'dan al
        rightObjectWeight = massSlider.value;
    }

    void UpdateMovement(float value = 0)
    {
        // Slider de�erini a��rl�k fakt�r�yle ayarla
        float effectiveForce = forceSlider.value / rightObjectWeight; // Kuvvet, a��rl�k ile orant�l� azal�r
        float movement = effectiveForce * movementRange;

        // Sol obje a�a�� hareket eder
        leftObject.transform.position = leftInitialPosition - new Vector3(0, movement, 0);

        // Sa� obje yukar� hareket eder
        rightObject.transform.position = rightInitialPosition + new Vector3(0, movement, 0);
    }

    void UpdateUI(float value = 0)
    {
        // UI Text de�erlerini g�ncelle
        forceText.text = "Force: " + forceSlider.value.ToString("F2") + " N";
        massText.text = "Mass: " + massSlider.value.ToString("F2") + " Kg";
    }

    void OnDestroy()
    {
        // Event dinleyicilerini kald�r
        forceSlider.onValueChanged.RemoveListener(UpdateMovement);
        massSlider.onValueChanged.RemoveListener(UpdateWeight);
        massSlider.onValueChanged.RemoveListener(UpdateMovement);
        forceSlider.onValueChanged.RemoveListener(UpdateUI);
        massSlider.onValueChanged.RemoveListener(UpdateUI);
    }
}
