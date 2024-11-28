using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigestiveCameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] List<GameObject> organsInformations;
    [SerializeField] Transform mainCamera;
    [SerializeField] float transitionSpeed = 2f;
    [SerializeField] List<GameObject> skeletonButtons;
    [SerializeField] List<GameObject> digestiveButtons;

    private bool isTransitioning = false;
    private Transform targetCameraTransform;

    public void ActivateCamera()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if(buttonName == "Skeleton System")
        {
            foreach(GameObject button in skeletonButtons)
            {
                button.SetActive(true);
            }
            foreach(GameObject button in digestiveButtons)
            {
                button.SetActive(false);
            }
        }
        else if (buttonName == "System")
        {
            foreach (GameObject button in skeletonButtons)
            {
                button.SetActive(false);
            }
            foreach (GameObject button in digestiveButtons)
            {
                button.SetActive(true);
            }
        }

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
            StartCoroutine(organInformationsAndCanvas(organ,buttonName));
        }

        // Geçiþ baþlat
        if (targetCameraTransform != null)
        {
            isTransitioning = true;
        }
    }

    IEnumerator organInformationsAndCanvas(GameObject organ, string buttonName)
    {
        GameObject childObject = organ.transform.Find("Image").gameObject;
        yield return new WaitForSeconds(1.6f);
        childObject.SetActive(organ.name ==buttonName);
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
