using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RigidbodyForceToggler : MonoBehaviour
{
    public Rigidbody rb; // Objeye eklenen Rigidbody
    public Slider forceSlider; // UI'deki kuvvet slider'ý
    public TextMeshProUGUI forceText; // Kuvvet deðerini göstermek için TextMeshPro
    public Slider massSlider;
    public TextMeshProUGUI massText;
    private float appliedForce; // Uygulanacak kuvvet
    private float mass;

    void Start()
    {
        Time.timeScale = 1.0f;
        // Rigidbody bileþenini kontrol et
        if (rb == null)
        {
            Debug.LogError("Rigidbody bileþeni bulunamadý!");
        }

        // Baþlangýç kuvvetini slider'dan al
        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;
        }

        if(massSlider != null)
        {
            rb.mass = massSlider.value;
        }

        // Yerçekimini aktif tutmak
        if (rb != null)
        {
            rb.useGravity = true; // Yerçekimini aktif tut
        }

        // Drag ve Angular Drag'i sýfýrla
        if (rb != null)
        {
            rb.drag = 0f; // Sürüklenmeyi kaldýr
            rb.angularDrag = 0f; // Açýsal sürüklenmeyi kaldýr
            rb.useGravity = true; // Yerçekimini aktif tut
        }
    }

    void Update()
    {
        // Slider'daki kuvveti sürekli güncelle
        if (forceSlider != null)
        {
            appliedForce = forceSlider.value;

            // TextMeshPro'da kuvvet deðerini güncelle
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

            // Sürekli kuvvet uygula (yavaþ hýzlanma)
            rb.AddForce(new Vector3(0,-appliedForce,-appliedForce), ForceMode.Force);
        }
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            // isKinematic durumunu deðiþtir
            rb.isKinematic = !rb.isKinematic;
            Debug.Log($"Rigidbody isKinematic durumu: {rb.isKinematic}");

            // Rigidbody'ye belirlenen kuvveti uygula
            if (!rb.isKinematic) // Sadece dinamik durumdaysa kuvvet uygula
            {
                // Kuvveti -Z eksenine doðru uygula
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
