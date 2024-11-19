using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ampulSok : MonoBehaviour
{

    [SerializeField] EmissionAndBloomControl EmissionAndBloomControl;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol t�klama
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform) // Bu GameObject'e t�kland� m�?
                {
                    EmissionAndBloomControl.ampulsok();
                }
            }
        }
    }
}
