using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] List<GameObject> planetInformations;

    public void ActivateCamera()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        foreach (GameObject cam in cameras)
        { 
            if(cam.name != buttonName)
            {
                cam.SetActive(false);
            } else
            {
                cam.SetActive(true);
            }
        }

        foreach (GameObject planet in planetInformations)
        {
            if (buttonName != planet.name)
            {
                planet.SetActive(false);
            }
            else
            {
                planet.SetActive(true);
            }
        }
    }

}