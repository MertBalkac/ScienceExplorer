using UnityEngine;

public class EarthquakeSimulation : MonoBehaviour
{
    public float intensity = 1.0f; 
    public float frequency = 1.0f; 
    public float duration = 5.0f; 
    public CameraShake cameraShake; 

    private float elapsedTime = 0.0f; 
    private bool isShaking = false; 
    private Vector3 originalPosition; 

    void Start()
    {
        originalPosition = transform.position; 
    }

    void Update()
    {
        if (isShaking)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime < duration)
            {
                ShakePlane();
            }
            else
            {
                StopEarthquake(); 
            }
        }
    }

    public void StartEarthquake()
    {
        if (isShaking) return; 
        isShaking = true;
        elapsedTime = 0.0f;

        if (cameraShake != null)
        {
            cameraShake.StartShake(duration);
        }
    }

    private void ShakePlane()
    {
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
        transform.position = originalPosition; 
    }

    void OnCollisionStay(Collision collision)
    {
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