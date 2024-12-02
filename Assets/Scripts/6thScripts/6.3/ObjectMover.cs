using System.Collections;
using UnityEngine;

public class ObjectMoverToggle : MonoBehaviour
{
    public Transform targetObject; // Hareket ettirilecek obje
    public Vector3 targetPosition; // Yeni pozisyon
    public float lerpDuration = 1f; // Lerp süresi
    public ParticleSystem gasParticleSystem; // Gaz ParticleSystem'i
    public float gasSpeedActive = 2f; // Aktif hýz
    public float gasSpeedDefault = 1f; // Varsayýlan hýz

    private bool isAtTarget = false; // Hedef pozisyonda mý?
    private bool isMoving = false;  // Harekette mi?

    private Vector3 initialPosition; // Objeyi baþlatýrkenki pozisyon

    private void Start()
    {
        // Objeyi baþlangýç pozisyonunda tut
        initialPosition = targetObject.position;
    }

    public void ToggleMoveAndSpeed()
    {
        if (!isMoving)
        {
            if (isAtTarget)
            {
                // Eski konuma geri dön
                StartCoroutine(MoveObjectCoroutine(initialPosition));
                SetGasParticleSpeed(gasSpeedDefault);
            }
            else
            {
                // Hedef konuma git
                StartCoroutine(MoveObjectCoroutine(targetPosition));
                SetGasParticleSpeed(gasSpeedActive);
            }

            // Durumu deðiþtir
            isAtTarget = !isAtTarget;
        }
    }

    private IEnumerator MoveObjectCoroutine(Vector3 target)
    {
        isMoving = true;

        // Baþlangýç pozisyonunu al
        Vector3 startPosition = targetObject.position;
        float elapsedTime = 0f;

        // Hareket ederken Lerp uygula
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpDuration;
            targetObject.position = Vector3.Lerp(startPosition, target, t);
            yield return null;
        }

        // Son pozisyonu kesin olarak ayarla
        targetObject.position = target;

        isMoving = false;
    }

    private void SetGasParticleSpeed(float speed)
    {
        // ParticleSystem'in MainModule'üne eriþ ve startSpeed ayarla
        ParticleSystem.MainModule mainModule = gasParticleSystem.main;
        mainModule.startSpeed = speed;
    }
}
