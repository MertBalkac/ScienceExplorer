using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelBulbScript : MonoBehaviour
{
    [SerializeField] GameObject emptyBulb;
    [SerializeField] GameObject originalBulb;
    private bool isOriginalActive;
    private void Awake()
    {
        isOriginalActive = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    SwitchBulb();
                }
            }
        }
    }

    private void SwitchBulb()
    {
        if (isOriginalActive)
        {
            emptyBulb.SetActive(true);
            originalBulb.SetActive(false);
            isOriginalActive = false;
        } 
        else
        {
            originalBulb.SetActive(true);
            emptyBulb.SetActive(false);
            isOriginalActive = true;
        }
    }
}
