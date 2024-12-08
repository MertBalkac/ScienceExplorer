using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    [System.Serializable]
    public class Wall
    {
        public GameObject wallObject; // Duvar objesi
        public GameObject lightObject; // Iþýk objesi
        public Vector3 downPosition;  // Aþaðýdaki pozisyon
        public Vector3 upPosition;    // Yukarýdaki pozisyon
    }

    public Wall[] walls; // Tüm duvarlar
    public float transitionSpeed = 2f; // Duvar hareket hýzý
    public float lightDelay = 2f; // Iþýðýn açýlma gecikmesi (saniye)

    private Coroutine currentCoroutine;
    private Coroutine lightCoroutine;

    // Ýlgili duvarý aþaðý indirirken diðerlerini yukarý çýkarýr
    public void MoveWallDown(int wallIndex)
    {
        // Hemen tüm ýþýklarý kapat
        TurnOffAllLights();

        // Eðer baþka bir iþlem çalýþýyorsa durdur
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // Eðer ýþýk açma iþlemi çalýþýyorsa durdur
        if (lightCoroutine != null)
        {
            StopCoroutine(lightCoroutine);
        }

        // Duvarlarý hareket ettir ve ýþýk açmayý zamanla
        currentCoroutine = StartCoroutine(MoveWallsAndLight(wallIndex));
    }

    private IEnumerator MoveWallsAndLight(int activeWallIndex)
    {
        // Iþýðý zamanla açmayý baþlat
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
        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(lightDelay);

        // Sadece ilgili duvarýn ýþýðýný aç
        TurnOnLightForWall(wallIndex);
    }

    // Tüm ýþýklarý kapatýr
    private void TurnOffAllLights()
    {
        foreach (Wall wall in walls)
        {
            wall.lightObject.SetActive(false);
        }
    }

    // Sadece belirli bir duvarýn ýþýðýný açar
    private void TurnOnLightForWall(int wallIndex)
    {
        walls[wallIndex].lightObject.SetActive(true);
    }
}
