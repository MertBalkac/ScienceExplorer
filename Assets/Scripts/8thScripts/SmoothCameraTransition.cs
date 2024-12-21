using UnityEngine;

public class SmoothCameraTransition : MonoBehaviour
{
    public Transform positionA; // Ýlk pozisyon
    public Transform positionB; // Ýkinci pozisyon
    public float transitionSpeed = 2f; // Geçiþ hýzý

    private bool movingToB = true; // Hangi pozisyona gidileceðini kontrol eder
    private Transform targetPosition; // Hedef pozisyon
    private Coroutine transitionCoroutine; // Aktif geçiþ coroutine'ini saklar

    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        // Kamerayý baþlangýç pozisyonuna ayarla
        transform.position = positionA.position;
        targetPosition = positionB; // Ýlk geçiþ hedefi B pozisyonu olacak
    }

    public void TogglePosition()
    {
        // Hedef pozisyonu deðiþtir
        targetPosition = movingToB ? positionB : positionA;
        movingToB = !movingToB;

        // Olasý aktif hareketi durdur
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

        // Yeni hareketi baþlat
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
        transitionCoroutine = null; // Geçiþ tamamlandý
    }
}
