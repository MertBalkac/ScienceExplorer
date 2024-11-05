using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject CreditPanel;
    [SerializeField] bool isCreditActive=false;

    [SerializeField] GameObject SoundOnButton;
    [SerializeField] GameObject SoundOffButton;

    

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("Unites");
    }

    public void CreditButton()
    {
        if(!isCreditActive)
        {
            CreditPanel.SetActive(true);
            isCreditActive = true;
        }
        else
        {
            CreditPanel.SetActive(false);
            isCreditActive = false;
        }
    }

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




}
