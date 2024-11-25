using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public Vector3 target; // Kamera hedef pozisyonu
    public float speed = 2.0f; // Kamera hareket hýzý

    private Vector3 initialPosition; // Kameranýn ilk pozisyonu

    [SerializeField] GameObject seriesButton;
    [SerializeField] GameObject parallelButton;
    [SerializeField] bool isInInitialPosition = true;
    public Material material; // Emission için materyal
    public Volume globalVolume; // Global Volume referansý
    private Bloom bloom; // Bloom bileþeni

    [SerializeField] EmissionAndBloomControl emissionAndBloomControl;
    [SerializeField] EmissionAndBloomControl emissionAndBloomControl1;
    [SerializeField] GameObject electricity;
    [SerializeField] GameObject parallelElectricity1;
    [SerializeField] GameObject parallelElectricity2;


    private void Start()
    {
        // Kameranýn baþlangýç pozisyonunu kaydediyoruz
        initialPosition = camera.transform.position;

        if (globalVolume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("Bloom bileþeni bulundu.");
        }
        else
        {
            Debug.LogError("Global Volume içinde Bloom bileþeni yok!");
        }
    }

    public void MoveToTarget()
    {

        // Hedef pozisyona hareketi baþlat
        electricity.SetActive(false);
        parallelElectricity1.SetActive(false);
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
        parallelButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, target));
    }

    public void ResetToInitialPosition()
    {
        // Baþlangýç pozisyonuna hareketi baþlat
        parallelElectricity1.SetActive(false);
        parallelElectricity2.SetActive(false);
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
        seriesButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, initialPosition));
    }

    IEnumerator CameraMove(Vector3 start, Vector3 end)
    {
        bloom.intensity.value = 0f;
        emissionAndBloomControl.isEmissionOn = false;
        emissionAndBloomControl1.isEmissionOn = false;
        // Kamera baþlangýçtan hedefe doðru hareket eder
        float journey = 0f;
        while (journey < 1f)
        {
            journey += Time.deltaTime * speed;
            camera.transform.position = Vector3.Lerp(start, end, journey);
            yield return null; // Bir sonraki frame'e kadar bekle
        }
        if(isInInitialPosition)
        {
            isInInitialPosition = false;
            seriesButton.SetActive(true);
        }
        else
        {
            isInInitialPosition = true;
            parallelButton.SetActive(true);
        }
        // Pozisyon tam olarak hedefe ayarlanýr
        camera.transform.position = end;
    }
}
