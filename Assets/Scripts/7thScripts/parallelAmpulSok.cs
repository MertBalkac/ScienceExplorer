using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class parallelAmpulSok : MonoBehaviour
{
    [SerializeField] private Material alternateMaterial;
    [SerializeField] private Material originalMaterial;
    private Renderer objectRenderer;
    [SerializeField] GameObject bulb;
    [SerializeField] bool isInInitialPosition;

    [SerializeField] GameObject parallelElectricity2;
    [SerializeField] GameObject parallelElectricity1;
    [SerializeField] EmissionAndBloomControl emissionAndBloomControl;

    

    private void Start()
    {
        isInInitialPosition = true;
        objectRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týklama
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform) // Bu GameObject'e týklandý mý?
                {
                    switchBulb();
                }
            }
        }
    }

    void switchBulb()
    {
        if(isInInitialPosition) {
            bulb.transform.position = new Vector3(bulb.transform.position.x, bulb.transform.position.y + 0.12f, bulb.transform.position.z);
            parallelElectricity2.SetActive(false);
            emissionAndBloomControl.isParallelBulbInSocket = false;
            if (alternateMaterial != null)
            {
                objectRenderer.material = alternateMaterial;
            }
            isInInitialPosition =false;
        } else
        {
            bulb.transform.position = new Vector3(bulb.transform.position.x, bulb.transform.position.y - 0.12f, bulb.transform.position.z);
            parallelElectricity2.SetActive(true);
            parallelElectricity1.SetActive(false);
            parallelElectricity1.SetActive(true);
            emissionAndBloomControl.isParallelBulbInSocket = true;
            if (originalMaterial != null)
            {
                objectRenderer.material = originalMaterial;
            }
            isInInitialPosition = true;
        }
    }
}
