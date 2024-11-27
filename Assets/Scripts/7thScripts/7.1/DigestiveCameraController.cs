using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigestiveCameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] List<GameObject> organsInformations;
    [SerializeField] Transform mainCamera; // Ana kamera transformu
    [SerializeField] float transitionSpeed = 2f; // Smooth ge�i� h�z�

    private bool isTransitioning = false;
    private Transform targetCameraTransform; // Ge�i� yap�lacak kamera

    public void ActivateCamera()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Hangi kamera hedeflenecek?
        foreach (GameObject cam in cameras)
        {
            if (cam.name == buttonName)
            {
                targetCameraTransform = cam.transform; // Hedef kameray� al
                break;
            }
        }

        // Hangi organ bilgileri aktif olacak?
        foreach (GameObject organ in organsInformations)
        {
            organ.SetActive(organ.name == buttonName);
        }

        // Ge�i� ba�lat
        if (targetCameraTransform != null)
        {
            isTransitioning = true;
        }
    }

    private void Update()
    {
        if (isTransitioning && targetCameraTransform != null)
        {
            // Pozisyonu ve rotasyonu smooth �ekilde de�i�tir
            mainCamera.position = Vector3.Lerp(mainCamera.position, targetCameraTransform.position, Time.deltaTime * transitionSpeed);
            mainCamera.rotation = Quaternion.Lerp(mainCamera.rotation, targetCameraTransform.rotation, Time.deltaTime * transitionSpeed);

            // Hedefe ula�t�ktan sonra ge�i�i durdur
            if (Vector3.Distance(mainCamera.position, targetCameraTransform.position) < 0.01f &&
                Quaternion.Angle(mainCamera.rotation, targetCameraTransform.rotation) < 0.1f)
            {
                isTransitioning = false;
            }
        }
    }
}
