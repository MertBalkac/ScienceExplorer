using UnityEngine;

public class EarthquakeSimulation : MonoBehaviour
{
    public float intensity = 1.0f; // Deprem büyüklüðü
    public float frequency = 1.0f; // Sarsýntý frekansý
    public float duration = 5.0f; // Deprem süresi
    public CameraShake cameraShake; // Kamera shake scripti

    private float elapsedTime = 0.0f; // Geçen süre
    private bool isShaking = false; // Depremin aktif olup olmadýðýný kontrol eder
    private Vector3 originalPosition; // Plane objesinin baþlangýç pozisyonu

    void Start()
    {
        originalPosition = transform.position; // Plane objesinin baþlangýç pozisyonunu sakla
    }

    void Update()
    {
        if (isShaking)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime < duration)
            {
                ShakePlane(); // Deprem devam ederken sarsýntýyý uygula
            }
            else
            {
                StopEarthquake(); // Deprem süresi bitince durdur
            }
        }
    }

    public void StartEarthquake()
    {
        if (isShaking) return; // Deprem zaten çalýþýyorsa ikinci kez baþlama
        isShaking = true;
        elapsedTime = 0.0f;

        // Kamera shake baþlat
        if (cameraShake != null)
        {
            cameraShake.StartShake(duration);
        }
    }

    private void ShakePlane()
    {
        // Plane objesini rastgele bir þekilde salla
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
        transform.position = originalPosition; // Plane objesini baþlangýç pozisyonuna geri döndür
    }

    void OnCollisionStay(Collision collision)
    {
        // Plane üzerinde yer alan Rigidbody'lere kuvvet uygula
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