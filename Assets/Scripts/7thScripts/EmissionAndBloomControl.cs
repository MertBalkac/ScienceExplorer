using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class EmissionAndBloomControl : MonoBehaviour
{
    public Material material; // Emission i�in materyal
    public Color emissionColor = Color.white; // Emission rengi
    public Volume globalVolume; // Global Volume referans�
    public float bloomIntensityOn; // Bloom a��kken yo�unluk
    public float bloomIntensityOff = 0f; // Bloom kapal�yken yo�unluk

    public bool isEmissionOn = false; // Emission durumu
    private Bloom bloom; // Bloom bile�eni

    [SerializeField] bool ampulSokuluMu=true;
    [SerializeField] GameObject ampul;

    public bool isParallelBulbInSocket;
    [SerializeField] bool inSeriesCircuit = true;
    [SerializeField] GameObject electricity;
    [SerializeField] GameObject parallelElectricity2;
    [SerializeField] GameObject parallelElectricity1;


    private void Awake()
    {
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
    }

    void Start()
    {
        // Global Volume'dan Bloom bile�enini al
        if (globalVolume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("Bloom bile�eni bulundu.");
        }
        else
        {
            Debug.LogError("Global Volume i�inde Bloom bile�eni yok!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol t�klama
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform) // Bu GameObject'e t�kland� m�?
                {
                    ToggleEmission();

                }
            }
        }
    }

    public void ampulsok()
    {
        if (ampulSokuluMu)
        {
            if (isEmissionOn)
            {
                isEmissionOn = false;
                electricity.SetActive(false);
                material.DisableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", Color.black);

                if (bloom != null)
                {
                    bloom.intensity.value = bloomIntensityOff;
                }
            }
            ampul.transform.position = new Vector3(ampul.transform.position.x, ampul.transform.position.y + 0.12f, ampul.transform.position.z);
            ampulSokuluMu = false;
        }
        else 
        {
            ampul.transform.position = new Vector3(ampul.transform.position.x, ampul.transform.position.y - 0.12f, ampul.transform.position.z);
            ampulSokuluMu = true;
        }
    }


    void ToggleEmission()
    {
        if(ampulSokuluMu)
        {
            isEmissionOn = !isEmissionOn;

            // Emission kontrol�
            if (isEmissionOn)
            {
                electricity.SetActive(true);
                parallelElectricity1.SetActive(true);
                if(isParallelBulbInSocket)
                {
                    parallelElectricity2.SetActive(true);
                }
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", emissionColor);
            }
            else
            {
                electricity.SetActive(false);
                parallelElectricity1.SetActive(false);
                if (isParallelBulbInSocket)
                {
                    parallelElectricity2.SetActive(false);
                }
                material.DisableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", Color.black);
            }

            // Bloom yo�unlu�u kontrol�
            if (bloom != null)
            {
                bloom.intensity.value = isEmissionOn ? bloomIntensityOn : bloomIntensityOff;
            }
        }

        if(!isParallelBulbInSocket && isEmissionOn)
        {
            parallelElectricity1.SetActive(true);
        }

    }
}