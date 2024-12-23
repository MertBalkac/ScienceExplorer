using UnityEngine;

public class EarthquakeSimulation : MonoBehaviour
{
    public float intensity = 1.0f; // Deprem b�y�kl���
    public float frequency = 1.0f; // Sars�nt� frekans�
    public float duration = 5.0f; // Deprem s�resi
    public CameraShake cameraShake; // Kamera shake scripti

    private float elapsedTime = 0.0f; // Ge�en s�re
    private bool isShaking = false; // Depremin aktif olup olmad���n� kontrol eder
    private Vector3 originalPosition; // Plane objesinin ba�lang�� pozisyonu

    void Start()
    {
        originalPosition = transform.position; // Plane objesinin ba�lang�� pozisyonunu sakla
    }

    void Update()
    {
        if (isShaking)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime < duration)
            {
                ShakePlane(); // Deprem devam ederken sars�nt�y� uygula
            }
            else
            {
                StopEarthquake(); // Deprem s�resi bitince durdur
            }
        }
    }

    public void StartEarthquake()
    {
        if (isShaking) return; // Deprem zaten �al���yorsa ikinci kez ba�lama
        isShaking = true;
        elapsedTime = 0.0f;

        // Kamera shake ba�lat
        if (cameraShake != null)
        {
            cameraShake.StartShake(duration);
        }
    }

    private void ShakePlane()
    {
        // Plane objesini rastgele bir �ekilde salla
        Vector3 shakeOffset = new Vector3(
            Mathf.PerlinNoise(Time.time * frequency, 0.0f) * 2 - 1,
            Mathf.PerlinNoise(0.0f, Time.time * frequency) * 2 - 1,
            0
        ) * intensity;

        transform.position = originalPosition + shakeOffset;
    }

    private void StopEarthquake()
    {
        isShaking = false;
        transform.position = originalPosition; // Plane objesini ba�lang�� pozisyonuna geri d�nd�r
    }

    void OnCollisionStay(Collision collision)
    {
        // Plane �zerinde yer alan Rigidbody'lere kuvvet uygula
        if (isShaking)
        {
            Rigidbody rb = collision.rigidbody;
            if (rb != null)
            {
                Vector3 randomForce = new Vector3(
                    Random.Range(-intensity, intensity),
                    Random.Range(0, intensity),
                    Random.Range(-intensity, intensity)
                );

                rb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }
}