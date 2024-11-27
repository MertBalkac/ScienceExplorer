using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigestiveCameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] List<GameObject> organsInformations;
    [SerializeField] Transform mainCamera; // Ana kamera transformu
    [SerializeField] float transitionSpeed = 2f; // Smooth geçiþ hýzý

    private bool isTransitioning = false;
    private Transform targetCameraTransform; // Geçiþ yapýlacak kamera

    public void ActivateCamera()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Hangi kamera hedeflenecek?
        foreach (GameObject cam in cameras)
        {
            if (cam.name == buttonName)
            {
                targetCameraTransform = cam.transform; // Hedef kamerayý al
                break;
            }
        }

        // Hangi organ bilgileri aktif olacak?
        foreach (GameObject organ in organsInformations)
        {
            organ.SetActive(organ.name == buttonName);
        }

        // Geçiþ baþlat
        if (targetCameraTransform != null)
        {
            isTransitioning = true;
        }
    }

    private void Update()
    {
        if (isTransitioning && targetCameraTransform != null)
        {
            // Pozisyonu ve rotasyonu smooth þekilde deðiþtir
            mainCamera.position = Vector3.Lerp(mainCamera.position, targetCameraTransform.position, Time.deltaTime * transitionSpeed);
            mainCamera.rotation = Quaternion.Lerp(mainCamera.rotation, targetCameraTransform.rotation, Time.deltaTime * transitionSpeed);

            // Hedefe ulaþtýktan sonra geçiþi durdur
            if (Vector3.Distance(mainCamera.position, targetCameraTransform.position) < 0.01f &&
                Quaternion.Angle(mainCamera.rotation, targetCameraTransform.rotation) < 0.1f)
            {
                isTransitioning = false;
            }
        }
    }
}
