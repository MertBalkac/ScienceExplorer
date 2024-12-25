using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class EarthquakeTrigger : MonoBehaviour
{
    public EarthquakeSimulation earthquakeController;
    public Animator animator;
    public GameObject kitFake;
    public GameObject kit;
    public GameObject panel;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public Animator wallCrack1;
    public Animator wallCrack2;

    public void StartButton()
    {
        earthquakeController.StartEarthquake();
        frame1.GetComponent<Rigidbody>().isKinematic = false;
        frame2.GetComponent<Rigidbody>().isKinematic = false;
        frame3.GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(AnimPlay());
        panel.SetActive(false);
    }

    IEnumerator AnimPlay()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isStart", true);
        yield return new WaitForSeconds(1.1f);
        wallCrack1.SetTrigger("PlayWallCrack");
        animator.SetBool("isCrouch", true);
        yield return new WaitForSeconds(2f);
        wallCrack2.SetTrigger("PlayWallCrack");
        kit.SetActive(true);
        kitFake.SetActive(false);
        yield return new WaitForSeconds(4f);
        animator.SetBool("isSecond", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("8.3");
    }
}
