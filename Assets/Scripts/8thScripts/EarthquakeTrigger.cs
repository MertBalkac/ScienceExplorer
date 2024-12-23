using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthquakeTrigger : MonoBehaviour
{
    public EarthquakeSimulation earthquakeController;
    public Animator animator;
    public GameObject kitFake;
    public GameObject kit;
    public GameObject panel;

    public void StartButton()
    {
        earthquakeController.StartEarthquake();
        StartCoroutine(AnimPlay());
        panel.SetActive(false);
    }

    IEnumerator AnimPlay()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isStart", true);
        yield return new WaitForSeconds(1.1f);
        animator.SetBool("isCrouch", true);
        yield return new WaitForSeconds(2f);
        kit.SetActive(true);
        kitFake.SetActive(false);
        yield return new WaitForSeconds(4f);
        animator.SetBool("isSecond", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("8.3");
    }
}