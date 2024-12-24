using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RigidbodyForceToggler : MonoBehaviour
{
    public Rigidbody rb; 
    public Slider forceSlider; 
    public TextMeshProUGUI forceText; 
    public Slider massSlider;
    public TextMeshProUGUI massText;
    private float appliedForce; 
    private float mass;

    void Start()
    {
        Time.timeScale = 1.0f;
        if (rb == null)
        {
            Debug.LogError("Rigidbody bileþeni bulunamadý!");
        }

        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;
        }

        if(massSlider != null)
        {
            rb.mass = massSlider.value;
        }

        if (rb != null)
        {
            rb.useGravity = true;
        }

        if (rb != null)
        {
            rb.drag = 0f; 
            rb.angularDrag = 0f; 
            rb.useGravity = true; 
        }
    }

    void Update()
    {
        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;
            if (forceText != null)
            {
                forceText.text = "Force: " + appliedForce.ToString("F1");
            }
        }

        if(massSlider != null)
        {
            rb.mass = massSlider.value;
            if (massText != null)
            {
                massText.text = "Mass: " + rb.mass.ToString() + "kg";
            }
        }


        if (!rb.isKinematic && gameObject.name != "Ball2")
        {
            appliedForce = forceSlider.value;
            rb.AddForce(new Vector3(0,-appliedForce,-appliedForce), ForceMode.Force);
        }
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            rb.isKinematic = !rb.isKinematic;
            Debug.Log($"Rigidbody isKinematic durumu: {rb.isKinematic}");

            if (!rb.isKinematic) 
            {
                if (gameObject.name == "Ball2")
                {
                    rb.AddForce(Vector3.back * appliedForce, ForceMode.Impulse);
                } else
                {
                    rb.AddForce(Vector3.back * appliedForce, ForceMode.Force);
                }
                Debug.Log($"Kuvvet uygulandý: {appliedForce} yön: -Z");
            }
        }
    }
}
