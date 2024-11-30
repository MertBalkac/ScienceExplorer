using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public Transform targetPosition1;  // �lk hedef konum
    public Transform targetPosition2;  // �kinci hedef konum
    public float moveSpeed = 2.0f;     // Hareket h�z�
    private bool isMoving = false;     // Hareketin durumu
    private Vector3 targetPosition;    // Hedef konum
    public GameObject canvas1;
    public GameObject canvas2;

    private void Start()
    {
        targetPosition = transform.position;
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void OnButtonClick()
    {
        // Konumlar aras�nda ge�i� yap
        if (targetPosition == targetPosition1.position)
        {
            targetPosition = targetPosition2.position;
            canvas1.SetActive(false);
        }
        else
        {
            targetPosition = targetPosition1.position;
            canvas2.SetActive(false);
        }

        isMoving = true;  // Hareketi ba�lat
    }

    void Update()
    {
        if (isMoving)
        {
            // Kameray� smooth bir �ekilde yeni konuma ta��
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Kameran�n hedefe yakla�mas� durumunda hareketi durdur
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;

                if(targetPosition == targetPosition1.position)
                {
                    canvas1.SetActive(!canvas1.activeSelf);
                } else
                {
                    canvas2.SetActive(!canvas2.activeSelf);

                }
            }
        }
    }
}
