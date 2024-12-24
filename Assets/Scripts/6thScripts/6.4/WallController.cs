using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    [System.Serializable]
    public class Wall
    {
        public GameObject wallObject; 
        public GameObject lightObject; 
        public Vector3 downPosition; 
        public Vector3 upPosition;
    }
    public Wall[] walls; 
    public float transitionSpeed = 2f; 
    public float lightDelay = 2f; 
    private Coroutine currentCoroutine;
    private Coroutine lightCoroutine;

    public void MoveWallDown(int wallIndex)
    {
        TurnOffAllLights();
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        if (lightCoroutine != null)
        {
            StopCoroutine(lightCoroutine);
        }
        currentCoroutine = StartCoroutine(MoveWallsAndLight(wallIndex));
    }

    private IEnumerator MoveWallsAndLight(int activeWallIndex)
    {
        lightCoroutine = StartCoroutine(TurnOnLightWithDelay(activeWallIndex));

        bool allWallsReachedPosition = false;

        while (!allWallsReachedPosition)
        {
            allWallsReachedPosition = true;

            for (int i = 0; i < walls.Length; i++)
            {
                GameObject wallObject = walls[i].wallObject;
                Vector3 targetPosition = (i == activeWallIndex) ? walls[i].downPosition : walls[i].upPosition;
                wallObject.transform.position = Vector3.Lerp(wallObject.transform.position, targetPosition, Time.deltaTime * transitionSpeed);

                if (Vector3.Distance(wallObject.transform.position, targetPosition) > 0.01f)
                {
                    allWallsReachedPosition = false;
                }
            }

            yield return null;
        }
    }

    private IEnumerator TurnOnLightWithDelay(int wallIndex)
    {
        yield return new WaitForSeconds(lightDelay);
        TurnOnLightForWall(wallIndex);
    }
    private void TurnOffAllLights()
    {
        foreach (Wall wall in walls)
        {
            wall.lightObject.SetActive(false);
        }
    }

    private void TurnOnLightForWall(int wallIndex)
    {
        walls[wallIndex].lightObject.SetActive(true);
    }
}
