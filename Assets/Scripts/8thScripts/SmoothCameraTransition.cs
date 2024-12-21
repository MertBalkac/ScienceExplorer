using UnityEngine;

public class SmoothCameraTransition : MonoBehaviour
{
    public Transform positionA; // �lk pozisyon
    public Transform positionB; // �kinci pozisyon
    public float transitionSpeed = 2f; // Ge�i� h�z�

    private bool movingToB = true; // Hangi pozisyona gidilece�ini kontrol eder
    private Transform targetPosition; // Hedef pozisyon
    private Coroutine transitionCoroutine; // Aktif ge�i� coroutine'ini saklar

    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        // Kameray� ba�lang�� pozisyonuna ayarla
        transform.position = positionA.position;
        targetPosition = positionB; // �lk ge�i� hedefi B pozisyonu olacak
    }

    public void TogglePosition()
    {
        // Hedef pozisyonu de�i�tir
        targetPosition = movingToB ? positionB : positionA;
        movingToB = !movingToB;

        // Olas� aktif hareketi durdur
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

        // Yeni hareketi ba�lat
        transitionCoroutine = StartCoroutine(SmoothTransition());
    }

    private System.Collections.IEnumerator SmoothTransition()
    {
        canvas1.SetActive(!canvas1.activeSelf);
        canvas2.SetActive(!canvas2.activeSelf);
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, transitionSpeed * Time.deltaTime);
            yield return null;
        }

        // Hedef pozisyona tam olarak oturt
        transform.position = targetPosition.position;
        transitionCoroutine = null; // Ge�i� tamamland�
    }
}
