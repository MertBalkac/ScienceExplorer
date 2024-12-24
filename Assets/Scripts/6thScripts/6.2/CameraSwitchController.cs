using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public Transform targetPosition1;  
    public Transform targetPosition2;  
    public Transform targetPosition3;  
    public float moveSpeed = 2.0f;     
    private bool isMoving = false;     
    private Vector3 targetPosition;    
    private int currentTargetIndex = 1; 
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;

    private void Start()
    {
        targetPosition = transform.position;
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
    }

    public void OnButtonClick()
    {
        currentTargetIndex++;

        if (currentTargetIndex > 3)
        {
            currentTargetIndex = 1; 
        }

        switch (currentTargetIndex)
        {
            case 1:
                targetPosition = targetPosition1.position;
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                break;
            case 2:
                targetPosition = targetPosition2.position;
                canvas1.SetActive(false);
                canvas2.SetActive(true);
                canvas3.SetActive(false);
                break;
            case 3:
                targetPosition = targetPosition3.position;
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(true);
                break;
        }

        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
