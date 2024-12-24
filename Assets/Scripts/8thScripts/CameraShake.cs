using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.5f; 
    public float shakeFrequency = 1.0f; 
    private Vector3 originalPosition; 
    public bool isShaking = false; 

    void Start()
    {
        originalPosition = transform.localPosition; 
    }

    void Update()
    {
        if (isShaking)
        {
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
        Invoke("StopShake", duration);
    }

    private void StopShake()
    {
        isShaking = false;
        transform.localPosition = originalPosition;
    }
}