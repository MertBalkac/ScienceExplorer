using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GradesMenu : MonoBehaviour
{
    

    public void BackToUnites()
    {
        SceneManager.LoadSceneAsync("Unites");
    }

    public void SevenTwo()
    {
        SceneManager.LoadSceneAsync("7.2");

    }

}
