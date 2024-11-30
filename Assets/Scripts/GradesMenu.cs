using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GradesMenu : MonoBehaviour
{
    [SerializeField] string TargetScene;

    public void loadScene()
    {
        if (!string.IsNullOrEmpty(TargetScene))
        {
            SceneManager.LoadScene(TargetScene);
        } else
        {
            Debug.LogError("Target scene name is not set");
        }
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
