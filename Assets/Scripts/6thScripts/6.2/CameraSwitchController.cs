using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public Transform targetPosition1;  // Ýlk hedef konum
    public Transform targetPosition2;  // Ýkinci hedef konum
    public Transform targetPosition3;  // Üçüncü hedef konum
    public float moveSpeed = 2.0f;     // Hareket hýzý
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
        // Pozisyonlar arasýnda geçiþ yap
        currentTargetIndex++;

        if (currentTargetIndex > 3)
        {
            currentTargetIndex = 1; // Ýlk pozisyona dön
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

        isMoving = true;  // Hareketi baþlat
    }

    void Update()
    {
        if (isMoving)
        {
            // Kamerayý smooth bir þekilde yeni konuma taþý
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Kameranýn hedefe yaklaþmasý durumunda hareketi durdur
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
