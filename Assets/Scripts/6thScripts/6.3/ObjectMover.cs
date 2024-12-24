using System.Collections;
using UnityEngine;

public class ObjectMoverToggle : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 targetPosition;
    public float lerpDuration = 1f;
    public ParticleSystem gasParticleSystem;
    public float gasSpeedActive = 2f;
    public float gasSpeedDefault = 1f;
    private bool isAtTarget = false;
    private bool isMoving = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = targetObject.position;
    }

    public void ToggleMoveAndSpeed()
    {
        if (!isMoving)
        {
            if (isAtTarget)
            {
                StartCoroutine(MoveObjectCoroutine(initialPosition));
                SetGasParticleSpeed(gasSpeedDefault);
            }
            else
            {
                StartCoroutine(MoveObjectCoroutine(targetPosition));
                SetGasParticleSpeed(gasSpeedActive);
            }
            isAtTarget = !isAtTarget;
        }
    }

    private IEnumerator MoveObjectCoroutine(Vector3 target)
    {
        isMoving = true;
        Vector3 startPosition = targetObject.position;
        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpDuration;
            targetObject.position = Vector3.Lerp(startPosition, target, t);
            yield return null;
        }

        targetObject.position = target;
        isMoving = false;
    }

    private void SetGasParticleSpeed(float speed)
    {
        ParticleSystem.MainModule mainModule = gasParticleSystem.main;
        mainModule.startSpeed = speed;
    }
}
