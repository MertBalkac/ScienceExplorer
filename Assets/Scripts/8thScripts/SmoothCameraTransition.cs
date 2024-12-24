using UnityEngine;

public class SmoothCameraTransition : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public float transitionSpeed = 2f; 

    private bool movingToB = true;
    private Transform targetPosition;
    private Coroutine transitionCoroutine;

    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        transform.position = positionA.position;
        targetPosition = positionB;
    }

    public void TogglePosition()
    {
        targetPosition = movingToB ? positionB : positionA;
        movingToB = !movingToB;

        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

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
        transform.position = targetPosition.position;
        transitionCoroutine = null;
    }
}
