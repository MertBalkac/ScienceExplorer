using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    [System.Serializable]
    public class Wall
    {
        public GameObject wallObject; // Duvar objesi
        public GameObject lightObject; // I��k objesi
        public Vector3 downPosition;  // A�a��daki pozisyon
        public Vector3 upPosition;    // Yukar�daki pozisyon
    }

    public Wall[] walls; // T�m duvarlar
    public float transitionSpeed = 2f; // Duvar hareket h�z�
    public float lightDelay = 2f; // I����n a��lma gecikmesi (saniye)

    private Coroutine currentCoroutine;
    private Coroutine lightCoroutine;

    // �lgili duvar� a�a�� indirirken di�erlerini yukar� ��kar�r
    public void MoveWallDown(int wallIndex)
    {
        // Hemen t�m ���klar� kapat
        TurnOffAllLights();

        // E�er ba�ka bir i�lem �al���yorsa durdur
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // E�er ���k a�ma i�lemi �al���yorsa durdur
        if (lightCoroutine != null)
        {
            StopCoroutine(lightCoroutine);
        }

        // Duvarlar� hareket ettir ve ���k a�may� zamanla
        currentCoroutine = StartCoroutine(MoveWallsAndLight(wallIndex));
    }

    private IEnumerator MoveWallsAndLight(int activeWallIndex)
    {
        // I���� zamanla a�may� ba�lat
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
        // Belirtilen s�re kadar bekle
        yield return new WaitForSeconds(lightDelay);

        // Sadece ilgili duvar�n �����n� a�
        TurnOnLightForWall(wallIndex);
    }

    // T�m ���klar� kapat�r
    private void TurnOffAllLights()
    {
        foreach (Wall wall in walls)
        {
            wall.lightObject.SetActive(false);
        }
    }

    // Sadece belirli bir duvar�n �����n� a�ar
    private void TurnOnLightForWall(int wallIndex)
    {
        walls[wallIndex].lightObject.SetActive(true);
    }
}
