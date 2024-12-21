using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PulleyControl : MonoBehaviour
{
    public Slider forceSlider; // Force slider referansý
    public Slider massSlider; // Mass slider referansý
    public TMP_Text forceText; // Force deðerini göstermek için UI Text
    public TMP_Text massText; // Mass deðerini göstermek için UI Text
    public GameObject leftObject; // Sol grup (aþaðý hareket eden)
    public GameObject rightObject; // Sað grup (yukarý hareket eden)
    public float movementRange = 5f; // Maksimum hareket mesafesi

    private Vector3 leftInitialPosition;
    private Vector3 rightInitialPosition;
    private float rightObjectWeight;

    void Start()
    {
        // Objelerin baþlangýç pozisyonlarýný kaydet
        leftInitialPosition = leftObject.transform.position;
        rightInitialPosition = rightObject.transform.position;

        // Baþlangýçta deðerleri güncelle
        UpdateWeight();
        UpdateUI();
        UpdateMovement();

        // Slider'larýn deðer deðiþimlerini dinle
        forceSlider.onValueChanged.AddListener(UpdateMovement);
        massSlider.onValueChanged.AddListener(UpdateWeight);
        massSlider.onValueChanged.AddListener(UpdateMovement);
        forceSlider.onValueChanged.AddListener(UpdateUI);
        massSlider.onValueChanged.AddListener(UpdateUI);
    }

    void UpdateWeight(float value = 0)
    {
        // Saðdaki objenin aðýrlýðýný mass slider'dan al
        rightObjectWeight = massSlider.value;
    }

    void UpdateMovement(float value = 0)
    {
        // Slider deðerini aðýrlýk faktörüyle ayarla
        float effectiveForce = forceSlider.value / rightObjectWeight; // Kuvvet, aðýrlýk ile orantýlý azalýr
        float movement = effectiveForce * movementRange;

        // Sol obje aþaðý hareket eder
        leftObject.transform.position = leftInitialPosition - new Vector3(0, movement, 0);

        // Sað obje yukarý hareket eder
        rightObject.transform.position = rightInitialPosition + new Vector3(0, movement, 0);
    }

    void UpdateUI(float value = 0)
    {
        // UI Text deðerlerini güncelle
        forceText.text = "Force: " + forceSlider.value.ToString("F2") + " N";
        massText.text = "Mass: " + massSlider.value.ToString("F2") + " Kg";
    }

    void OnDestroy()
    {
        // Event dinleyicilerini kaldýr
        forceSlider.onValueChanged.RemoveListener(UpdateMovement);
        massSlider.onValueChanged.RemoveListener(UpdateWeight);
        massSlider.onValueChanged.RemoveListener(UpdateMovement);
        forceSlider.onValueChanged.RemoveListener(UpdateUI);
        massSlider.onValueChanged.RemoveListener(UpdateUI);
    }
}
