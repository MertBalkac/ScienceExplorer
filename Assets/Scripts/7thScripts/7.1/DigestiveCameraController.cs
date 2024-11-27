using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigestiveCameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] List<GameObject> organsInformations;
    [SerializeField] Transform mainCamera;
    [SerializeField] float transitionSpeed = 2f; 

    private bool isTransitioning = false;
    private Transform targetCameraTransform;

    public void ActivateCamera()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Hangi kamera hedeflenecek?
        foreach (GameObject cam in cameras)
        {
            if (cam.name == buttonName)
            {
                targetCameraTransform = cam.transform;
                break;
            }
        }

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
            mainCamera.position = Vector3.Lerp(mainCamera.position, targetCameraTransform.position, Time.deltaTime * transitionSpeed);
            mainCamera.rotation = Quaternion.Lerp(mainCamera.rotation, targetCameraTransform.rotation, Time.deltaTime * transitionSpeed);

            if (Vector3.Distance(mainCamera.position, targetCameraTransform.position) < 0.01f &&
                Quaternion.Angle(mainCamera.rotation, targetCameraTransform.rotation) < 0.1f)
            {
                isTransitioning = false;
            }
        }
    }
}
