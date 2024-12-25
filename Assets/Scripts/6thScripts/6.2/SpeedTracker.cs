using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedTracker : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public TextMeshProUGUI speedText;

    void Update()
    {
        float speed = ballRigidbody.velocity.magnitude;

        if (speedText != null)
        {
            speedText.text = speed.ToString("F3") + " m/s";
        }
    }
}