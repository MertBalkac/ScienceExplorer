using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unites : MonoBehaviour
{
    [SerializeField] GameObject SoundOnButton;
    [SerializeField] GameObject SoundOffButton;

    public void SoundOff()
    {
        AudioListener.volume = 0f;
        SoundOffButton.SetActive(true);
        SoundOnButton.SetActive(false);
    }

    public void SoundOn()
    {
        AudioListener.volume = 1f;
        SoundOffButton.SetActive(false);
        SoundOnButton.SetActive(true);
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void sixthGradeSceneButton()
    {
        SceneManager.LoadSceneAsync("SixthGrade");
    }

    public void seventhGradeSceneButton()
    {
        SceneManager.LoadSceneAsync("SeventhGrade");
    }
    public void eighthGradeSceneButton()
    {
        SceneManager.LoadSceneAsync("EighthGrade");
    }



}
