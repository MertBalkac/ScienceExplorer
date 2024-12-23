using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.5f; // Sallanma �iddeti
    public float shakeFrequency = 1.0f; // Sallanma frekans�
    private Vector3 originalPosition; // Kameran�n ba�lang�� pozisyonu
    public bool isShaking = false; // Kameran�n sallan�p sallanmad���n� kontrol eder

    void Start()
    {
        originalPosition = transform.localPosition; // Kameran�n ba�lang�� pozisyonunu sakla
    }

    void Update()
    {
        if (isShaking)
        {
            // Rastgele bir sallanma hareketi olu�tur
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
        Invoke("StopShake", duration); // Belirtilen s�re sonunda sallanmay� durdur
    }

    private void StopShake()
    {
        isShaking = false;
        transform.localPosition = originalPosition; // Kameray� eski konumuna geri d�nd�r
    }
}