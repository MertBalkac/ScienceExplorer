using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.5f; // Sallanma þiddeti
    public float shakeFrequency = 1.0f; // Sallanma frekansý
    private Vector3 originalPosition; // Kameranýn baþlangýç pozisyonu
    public bool isShaking = false; // Kameranýn sallanýp sallanmadýðýný kontrol eder

    void Start()
    {
        originalPosition = transform.localPosition; // Kameranýn baþlangýç pozisyonunu sakla
    }

    void Update()
    {
        if (isShaking)
        {
            // Rastgele bir sallanma hareketi oluþtur
            Vector3 shakeOffset = new Vector3(
                Random.Range(-shakeIntensity, shakeIntensity),
                Random.Range(-shakeIntensity, shakeIntensity),
                0
            );

            transform.localPosition = originalPosition + shakeOffset;
        }
    }

    public void StartShake(float duration)
    {
        isShaking = true;
        Invoke("StopShake", duration); // Belirtilen süre sonunda sallanmayý durdur
    }

    private void StopShake()
    {
        isShaking = false;
        transform.localPosition = originalPosition; // Kamerayý eski konumuna geri döndür
    }
}