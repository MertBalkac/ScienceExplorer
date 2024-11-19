using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public Vector3 target; // Kamera hedef pozisyonu
    public float speed = 2.0f; // Kamera hareket hýzý

    private Vector3 initialPosition; // Kameranýn ilk pozisyonu

    [SerializeField] GameObject seriesButton;
    [SerializeField] GameObject parallelButton;
    [SerializeField] bool isInInitialPosition = true;

    private void Start()
    {
        // Kameranýn baþlangýç pozisyonunu kaydediyoruz
        initialPosition = camera.transform.position;
    }

    public void MoveToTarget()
    {
        // Hedef pozisyona hareketi baþlat
        parallelButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, target));
    }

    public void ResetToInitialPosition()
    {
        // Baþlangýç pozisyonuna hareketi baþlat
        seriesButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, initialPosition));
    }

    IEnumerator CameraMove(Vector3 start, Vector3 end)
    {
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
