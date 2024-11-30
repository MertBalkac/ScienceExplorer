using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RigidbodyForceToggler : MonoBehaviour
{
    public Rigidbody rb; // Objeye eklenen Rigidbody
    public Slider forceSlider; // UI'deki kuvvet slider'�
    public TextMeshProUGUI forceText; // Kuvvet de�erini g�stermek i�in TextMeshPro
    public Slider massSlider;
    public TextMeshProUGUI massText;
    private float appliedForce; // Uygulanacak kuvvet
    private float mass;

    void Start()
    {
        Time.timeScale = 1.0f;
        // Rigidbody bile�enini kontrol et
        if (rb == null)
        {
            Debug.LogError("Rigidbody bile�eni bulunamad�!");
        }

        // Ba�lang�� kuvvetini slider'dan al
        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;
        }

        if(massSlider != null)
        {
            rb.mass = massSlider.value;
        }

        // Yer�ekimini aktif tutmak
        if (rb != null)
        {
            rb.useGravity = true; // Yer�ekimini aktif tut
        }

        // Drag ve Angular Drag'i s�f�rla
        if (rb != null)
        {
            rb.drag = 0f; // S�r�klenmeyi kald�r
            rb.angularDrag = 0f; // A��sal s�r�klenmeyi kald�r
            rb.useGravity = true; // Yer�ekimini aktif tut
        }
    }

    void Update()
    {
        // Slider'daki kuvveti s�rekli g�ncelle
        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;

            // TextMeshPro'da kuvvet de�erini g�ncelle
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

            // S�rekli kuvvet uygula (yava� h�zlanma)
            rb.AddForce(new Vector3(0,-appliedForce,-appliedForce), ForceMode.Force);
        }
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            // isKinematic durumunu de�i�tir
            rb.isKinematic = !rb.isKinematic;
            Debug.Log($"Rigidbody isKinematic durumu: {rb.isKinematic}");

            // Rigidbody'ye belirlenen kuvveti uygula
            if (!rb.isKinematic) // Sadece dinamik durumdaysa kuvvet uygula
            {
                // Kuvveti -Z eksenine do�ru uygula
                if (gameObject.name == "Ball2")
                {
                    rb.AddForce(Vector3.back * appliedForce, ForceMode.Impulse);
                } else
                {
                    rb.AddForce(Vector3.back * appliedForce, ForceMode.Force);
                }
                Debug.Log($"Kuvvet uyguland�: {appliedForce} y�n: -Z");
            }
        }
    }
}
