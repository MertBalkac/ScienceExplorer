using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public Transform targetPosition1;  // Ýlk hedef konum
    public Transform targetPosition2;  // Ýkinci hedef konum
    public float moveSpeed = 2.0f;     // Hareket hýzý
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
        // Konumlar arasýnda geçiþ yap
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
