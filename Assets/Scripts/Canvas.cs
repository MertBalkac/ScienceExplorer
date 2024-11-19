using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public Vector3 target; // Kamera hedef pozisyonu
    public float speed = 2.0f; // Kamera hareket h�z�

    private Vector3 initialPosition; // Kameran�n ilk pozisyonu

    [SerializeField] GameObject seriesButton;
    [SerializeField] GameObject parallelButton;
    [SerializeField] bool isInInitialPosition = true;
    public Material material; // Emission i�in materyal
    public Volume globalVolume; // Global Volume referans�
    private Bloom bloom; // Bloom bile�eni

    [SerializeField] EmissionAndBloomControl emissionAndBloomControl;
    [SerializeField] EmissionAndBloomControl emissionAndBloomControl1;


    private void Start()
    {
        // Kameran�n ba�lang�� pozisyonunu kaydediyoruz
        initialPosition = camera.transform.position;

        if (globalVolume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("Bloom bile�eni bulundu.");
        }
        else
        {
            Debug.LogError("Global Volume i�inde Bloom bile�eni yok!");
        }
    }

    public void MoveToTarget()
    {

        // Hedef pozisyona hareketi ba�lat
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
        parallelButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, target));
    }

    public void ResetToInitialPosition()
    {
        // Ba�lang�� pozisyonuna hareketi ba�lat
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
        // Kamera ba�lang��tan hedefe do�ru hareket eder
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
        // Pozisyon tam olarak hedefe ayarlan�r
        camera.transform.position = end;
    }
}
