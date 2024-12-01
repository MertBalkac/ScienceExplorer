using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public Transform targetPosition1;  // �lk hedef konum
    public Transform targetPosition2;  // �kinci hedef konum
    public Transform targetPosition3;  // ���nc� hedef konum
    public float moveSpeed = 2.0f;     // Hareket h�z�
    private bool isMoving = false;     // Hareketin durumu
    private Vector3 targetPosition;    // Hedef konum
    private int currentTargetIndex = 1; // Mevcut hedef pozisyonun indeksi
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
        // Pozisyonlar aras�nda ge�i� yap
        currentTargetIndex++;

        if (currentTargetIndex > 3)
        {
            currentTargetIndex = 1; // �lk pozisyona d�n
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
            }
        }
    }
}
