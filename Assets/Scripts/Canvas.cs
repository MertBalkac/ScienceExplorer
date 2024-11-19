using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public Vector3 target; // Kamera hedef pozisyonu
    public float speed = 2.0f; // Kamera hareket h�z�

    private Vector3 initialPosition; // Kameran�n ilk pozisyonu

    [SerializeField] GameObject seriesButton;
    [SerializeField] GameObject parallelButton;
    [SerializeField] bool isInInitialPosition = true;

    private void Start()
    {
        // Kameran�n ba�lang�� pozisyonunu kaydediyoruz
        initialPosition = camera.transform.position;
    }

    public void MoveToTarget()
    {
        // Hedef pozisyona hareketi ba�lat
        parallelButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, target));
    }

    public void ResetToInitialPosition()
    {
        // Ba�lang�� pozisyonuna hareketi ba�lat
        seriesButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, initialPosition));
    }

    IEnumerator CameraMove(Vector3 start, Vector3 end)
    {
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
