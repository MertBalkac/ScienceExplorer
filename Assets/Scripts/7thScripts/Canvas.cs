using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public Vector3 target;
    public float speed = 2.0f; 

    private Vector3 initialPosition;

    [SerializeField] GameObject seriesButton;
    [SerializeField] GameObject parallelButton;
    [SerializeField] bool isInInitialPosition = true;
    public Material material;
    public Volume globalVolume;
    private Bloom bloom; 

    [SerializeField] EmissionAndBloomControl emissionAndBloomControl;
    [SerializeField] EmissionAndBloomControl emissionAndBloomControl1;
    [SerializeField] GameObject electricity;
    [SerializeField] GameObject parallelElectricity1;
    [SerializeField] GameObject parallelElectricity2;


    private void Start()
    {
        initialPosition = camera.transform.position;

        if (globalVolume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("Bloom bileþeni bulundu.");
        }
        else
        {
            Debug.LogError("Global Volume içinde Bloom bileþeni yok!");
        }
    }

    public void MoveToTarget()
    {
        electricity.SetActive(false);
        parallelElectricity1.SetActive(false);
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
        parallelButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, target));
    }

    public void ResetToInitialPosition()
    {
        parallelElectricity1.SetActive(false);
        parallelElectricity2.SetActive(false);
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.black);
        seriesButton.SetActive(false);
        StartCoroutine(CameraMove(camera.transform.position, initialPosition));
    }

    IEnumerator CameraMove(Vector3 start, Vector3 end)
    {
        bloom.intensity.value = 0f;
        emissionAndBloomControl.isEmissionOn = false;
        emissionAndBloomControl1.isEmissionOn = false;
        float journey = 0f;
        while (journey < 1f)
        {
            journey += Time.deltaTime * speed;
            camera.transform.position = Vector3.Lerp(start, end, journey);
            yield return null;
        }
        if(isInInitialPosition)
        {
            isInInitialPosition = false;
            seriesButton.SetActive(true);
        }
        else
        {
            isInInitialPosition = true;
            parallelButton.SetActive(true);
        }
        camera.transform.position = end;
    }
}
